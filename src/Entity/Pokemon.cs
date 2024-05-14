namespace PokemonG.src.Entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pokemon
{

    public int Id { get; set; }
    [Required(ErrorMessage = "Must have Name")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Must have Type")]
    public string? Type { get; set; }
    public List<Powers> Skills { get; set; } = new List<Powers>();

    
}

public class Powers
{
    public string? id { get; set; }
    public int Attack1 { get; set; }
    public int Attack2 { get; set; }

    public int Attack3 { get; set; }
    public int Attack4 { get; set; }
    public double Defense { get; set; }
}






