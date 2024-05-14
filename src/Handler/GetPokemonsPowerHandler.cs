namespace PokemonG.src.Handler;

using Microsoft.EntityFrameworkCore;
using PokemonG.src.Config;
using PokemonG.src.Entity;
using System.Collections.Generic;

public class GetPokemonsPowerHandler
{
    private DbMemory _db;

    internal GetPokemonsPowerHandler(DbMemory db)
    {
        this._db = db;
    }

    public IEnumerable<Pokemon> Handle(int attack)
    {
        var pokemons = this._db.Pokemons.Include(pokemon => pokemon.Skills.Where(Powers => (Powers.Attack1 +  Powers.Attack2 + Powers.Attack3 + Powers.Attack4)/4 > attack)).ToList();
        return pokemons.Where(pokemon => pokemon.Skills.Count != 0).ToList();
    }
}