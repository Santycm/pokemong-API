namespace PokemonG.src.Handler;

using Microsoft.EntityFrameworkCore;
using PokemonG.src.Config;
using PokemonG.src.Entity;
using System.Collections.Generic;

public class GetPokemonsByRangeDefenseHandler
{
    private DbMemory _db;

    internal GetPokemonsByRangeDefenseHandler(DbMemory db)
    {
        this._db = db;
    }

    public IEnumerable<Pokemon> Handle(double dmin, double dmax)
    {
        var pokemons = this._db.Pokemons.Include(pokemon => pokemon.Skills.Where(skill => skill.Defense >= dmin && skill.Defense <= dmax)).ToList();
        return pokemons.Where(pokemon => pokemon.Skills.Count != 0).ToList();
    }
}