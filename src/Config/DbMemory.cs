namespace PokemonG.src.Config;

using Microsoft.EntityFrameworkCore;
using PokemonG.src.Entity;

class DbMemory : DbContext
{
    public DbMemory(DbContextOptions<DbMemory> options) : base(options) {}

    public DbSet<Pokemon> Pokemons => Set<Pokemon>();
}