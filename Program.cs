using Microsoft.EntityFrameworkCore;

using PokemonG.src.Config;
using PokemonG.src.Entity;
using PokemonG.src.Handler;
using PokemonG.src.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbMemory>(opt => opt.UseInMemoryDatabase("PokemonList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

//Obtener todos los Pokemones
app.MapGet("/pokemons/getall", (DbMemory db) =>
{
    try
    {
        GetAllPokemonHandler handle = new GetAllPokemonHandler(db);
        var pokemons = handle.Handle();
        return Results.Ok(pokemons);
    }
    catch (Exception e)
    {
        return Results.Problem(e.Message);
    }
});

//Traer un Pokemon por id
app.MapGet("/pokemons/getid/{id:int}", (int id, DbMemory db, HttpContext context) =>
{
    try
    {
        GetAPokemonHandler handle = new GetAPokemonHandler(db);
        var pokemons = handle.Handle(id);
        return Results.Ok(pokemons);
    }
    catch (Exception e)
    {
        return Results.Problem(e.Message);
    }
});

//Traer todo los Pokemones que pertenecen a un tipo
app.MapGet("/pokemons/gettype/{type}", (string type, DbMemory db, HttpContext context) =>
{
    try
    {
        GetPokemonByTypeHandler handle = new GetPokemonByTypeHandler(db);
        var pokemons = handle.Handle(type);
        return Results.Ok(pokemons);
    }
    catch (Exception e)
    {
        return Results.Problem(e.Message);
    }
});

//Traer todos los Pokemones que el promedio de la suma de sus ataques es mayor al valor requerido
app.MapGet("/pokemons/getpowered/{attack:int}", (int attack, DbMemory db, HttpContext context) =>
{
    try
    {
        GetPokemonsPowerHandler handle = new GetPokemonsPowerHandler(db);
        var pokemons = handle.Handle(attack);
        return Results.Ok(pokemons);
    }
    catch (Exception e)
    {
        return Results.Problem(e.Message);
    }
});

//Traer todo los Pokemones que su defensa este en un rango ingresado en la url
app.MapGet("/pokemons/defmin/{dmin:double}/defmax/{dmax:double}", (double dmin, double dmax, DbMemory db, HttpContext context) =>
{
    try
    {
        GetPokemonsByRangeDefenseHandler handle = new GetPokemonsByRangeDefenseHandler(db);
        var pokemons = handle.Handle(dmin, dmax);
        return Results.Ok(pokemons);
    }
    catch (Exception e)
    {
        return Results.Problem(e.Message);
    }
});

//Crear un Pokemon
app.MapPost("/pokemons/post", async (HttpContext context, DbMemory db) =>
{
    try
    {
        Pokemon? pokemon = await context.Request.ReadFromJsonAsync<Pokemon>();

        if (pokemon == null)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }
        
        ValidatePostAPokemon validatePostAPokemon = new ValidatePostAPokemon(pokemon);
        if (validatePostAPokemon.IsValid())
        {
            CreatePokemonHandler handler = new CreatePokemonHandler(db);
            await handler.HandleAsync(pokemon);
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }
    }
    catch (Exception e)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsync(e.Message);
        return;
    }
});

//Crear multiples Pokemones
app.MapPost("/pokemons/addmultiple", async (HttpContext context, DbMemory db) =>
{
    try
    {
        var pokemons = await context.Request.ReadFromJsonAsync<List<Pokemon>>();

        if (pokemons == null)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }

        ValidatePostMultiplePokemons validatePostMultiplePokemons = new ValidatePostMultiplePokemons(pokemons);
        if (validatePostMultiplePokemons.IsValid())
        {
            CreateMultiplePokemonsHandler handler = new CreateMultiplePokemonsHandler(db);
            await handler.HandleAsync(pokemons);
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }
    }
    catch (Exception e)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsync(e.Message);
        return;
    }
});

//Eliminar un Pokemon por id
app.MapDelete("/pokemons/delete/id/{id:int}", async (int id, DbMemory db, HttpContext context) =>
{
    try
    {
        var pokemon = db.Pokemons.FirstOrDefault(pokemon => pokemon.Id == id);
        if (pokemon == null)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }
        DeletePokemonHandler handler = new DeletePokemonHandler(db);
        await handler.HandleAsync(pokemon);
    }
    catch (Exception e)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsync(e.Message);
        return;
    }
});

//Eliminar todos los Pokemones de un tipo
app.MapDelete("/pokemons/delete/type/{type}", async (string type, DbMemory db, HttpContext context) =>
{
    try
    {
        var pokemons = db.Pokemons.Where(pokemon => pokemon.Type == type).ToList<Pokemon>();
        if (pokemons == null)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }
        DeletePokemonsTypeHandler handler = new DeletePokemonsTypeHandler(db);
        await handler.HandleAsync(pokemons);
    }
    catch (Exception e)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsync(e.Message);
        return;
    }
});

//Editar un Pokemon por id (Solo se permite editar el nombre y el tipo)
app.MapPut("/pokemons/edit/{id:int}", async (int id, DbMemory db, HttpContext context) =>
{
    try
    {
        var newpokemon = await context.Request.ReadFromJsonAsync<Pokemon>();
        if (newpokemon == null)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }
        PutPokemonHandler handler = new PutPokemonHandler(db);
        await handler.HandleAsync(id, newpokemon);
    }
    catch (Exception e)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsync(e.Message);
        return;
    }
});

//Editar parcialmente los atributos del Pokemon por id (solo se puede cambiar el nombre y tipo)
app.MapPatch("/pokemons/changevalue/{id:int}", async (HttpContext context, DbMemory db, int id) =>
{
    try
    {
        var newPokemon = await context.Request.ReadFromJsonAsync<Pokemon>();
        if(newPokemon == null)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }

        PatchPokemonHandler handler = new PatchPokemonHandler(db);
        await handler.HandleAsync(id, newPokemon, context);
    }
    catch (Exception e)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsync(e.Message);
        return;
    }

});

app.Run();

