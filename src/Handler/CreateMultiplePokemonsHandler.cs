namespace PokemonG.src.Handler;

using Microsoft.AspNetCore.Mvc;
using PokemonG.src.Config;
using PokemonG.src.Entity;

public class CreateMultiplePokemonsHandler
{
    private DbMemory _db;

    internal CreateMultiplePokemonsHandler(DbMemory db)
    {
        this._db = db;
    }

    public async Task<IActionResult> HandleAsync(IEnumerable<Pokemon> pokemons)
    {
        this._db.Pokemons.AddRange(pokemons);
        await this._db.SaveChangesAsync();

        return new CreatedResult($"/pokemons/addmultiple", pokemons);
    }
}