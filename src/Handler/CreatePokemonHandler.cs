namespace PokemonG.src.Handler;

using Microsoft.AspNetCore.Mvc;
using PokemonG.src.Config;
using PokemonG.src.Entity;

public class CreatePokemonHandler
{
    private DbMemory _db;

    internal CreatePokemonHandler(DbMemory db){
        this._db = db;
    }

    public async Task<IActionResult> HandleAsync(Pokemon pokemon)
    {
        this._db.Pokemons.Add(pokemon);
        await this._db.SaveChangesAsync();

        return new CreatedResult($"/pokemons/post", pokemon);
    }
}