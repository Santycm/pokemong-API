namespace PokemonG.src.Handler;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonG.src.Config;
using PokemonG.src.Entity;

public class DeletePokemonHandler
{
    private DbMemory _db;

    internal DeletePokemonHandler(DbMemory db)
    {
        this._db = db;
    }

    public async Task<ActionResult> HandleAsync(Pokemon pokemon)
    {
        this._db.Pokemons.Remove(pokemon);
        await this._db.SaveChangesAsync();

        return new CreatedResult($"/pokemons/delete/id/", pokemon);
    }
}