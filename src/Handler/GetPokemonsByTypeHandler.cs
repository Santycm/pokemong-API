namespace PokemonG.src.Handler;

using Microsoft.EntityFrameworkCore;
using PokemonG.src.Config;
using PokemonG.src.Entity;
using System.Collections.Generic;

public class GetPokemonByTypeHandler
{
    private DbMemory _db;

    internal GetPokemonByTypeHandler(DbMemory db)
    {
        this._db = db;
    }

    public IEnumerable<Pokemon> Handle(string type)
    {
        return this._db.Pokemons.Where(pokemon => pokemon.Type == type).Include(pokemon => pokemon.Skills).ToList<Pokemon>();
    }

    
}