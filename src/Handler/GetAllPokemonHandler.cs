namespace PokemonG.src.Handler;

using Microsoft.EntityFrameworkCore;
using PokemonG.src.Config;
using PokemonG.src.Entity;
using System.Collections.Generic;

public class GetAllPokemonHandler
{
    private DbMemory _db;

    internal GetAllPokemonHandler(DbMemory db)
    {
        this._db = db;
    }

    public IEnumerable<Pokemon> Handle()
    {
        return this._db.Pokemons.Include(pokemon => pokemon.Skills).ToList<Pokemon>();
    }

}