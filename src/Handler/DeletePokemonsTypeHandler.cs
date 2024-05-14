namespace PokemonG.src.Handler;

using Microsoft.AspNetCore.Mvc;
using PokemonG.src.Config;
using PokemonG.src.Entity;

public class DeletePokemonsTypeHandler
{
    private DbMemory _db;

    internal DeletePokemonsTypeHandler(DbMemory db)
    {
        this._db = db;
    }

    public async Task<ActionResult> HandleAsync(IEnumerable<Pokemon> pokemons)
    {
        this._db.Pokemons.RemoveRange(pokemons);
        await this._db.SaveChangesAsync();

        return new CreatedResult($"/pokemons/delete/type/", pokemons);
    }
}