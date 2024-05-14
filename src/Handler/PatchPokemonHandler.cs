namespace PokemonG.src.Handler;

using Microsoft.AspNetCore.Mvc;
using PokemonG.src.Config;
using PokemonG.src.Entity;

public class PatchPokemonHandler
{
    private DbMemory _db;

    internal PatchPokemonHandler(DbMemory db)
    {
        this._db = db;
    }

    public async Task<ActionResult> HandleAsync(int id, Pokemon newPokemon, HttpContext context)
    {
        var pokemon = await this._db.Pokemons.FindAsync(id);
        if (pokemon == null)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return new CreatedResult($"/pokemons/changevalue/fail", pokemon);
        }
        if (newPokemon.Name != null)
        {
            pokemon.Name = newPokemon.Name;
        }
        if (newPokemon.Type != null)
        {
            pokemon.Type = newPokemon.Type;
        }

        await this._db.SaveChangesAsync();
        return new CreatedResult($"/pokemons/changevalue", pokemon);
    }
}