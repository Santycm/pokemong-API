namespace PokemonG.src.Handler;

using Microsoft.EntityFrameworkCore;
using PokemonG.src.Config;
using PokemonG.src.Entity;
using System.Collections.Generic;

public class GetAPokemonHandler
{
    private DbMemory _db;

    internal GetAPokemonHandler(DbMemory db)
    {
        this._db = db;
    }

    public IEnumerable<Pokemon> Handle(int id)
    {
        return this._db.Pokemons.Where(pokemon => pokemon.Id == id).Include(pokemon => pokemon.Skills).ToList<Pokemon>();
    }
}