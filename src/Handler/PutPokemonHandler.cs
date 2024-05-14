namespace PokemonG.src.Handler;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonG.src.Config;
using PokemonG.src.Entity;

public class PutPokemonHandler
{
    private DbMemory _db;

    internal PutPokemonHandler(DbMemory db)
    {
        this._db = db;
    }

    public async Task<ActionResult> HandleAsync(int id, Pokemon newpokemon)
    {
        var pokemon = await this._db.Pokemons.FindAsync(id);
        if (pokemon == null)
        {
            return new CreatedResult($"/pokemons/edit/{id}/fail", pokemon);
        }
        
        this._db.Update(pokemon).CurrentValues.SetValues(newpokemon);
        await this._db.SaveChangesAsync();

        return new CreatedResult($"/pokemons/edit/", pokemon);
    }
}