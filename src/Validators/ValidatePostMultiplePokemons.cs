namespace PokemonG.src.Validators;

using PokemonG.src.Entity;

public class ValidatePostMultiplePokemons
{
    IEnumerable<Pokemon> pokemons { get; set; }
    public ValidatePostMultiplePokemons(IEnumerable<Pokemon> pokemons)
    {
        this.pokemons = pokemons;
    }

    public bool IsValid()
    {
        foreach (Pokemon pokemon in this.pokemons)
        {
            if (pokemon.Name == null || pokemon.Name == "")
            {
                return false;
            }
            if (pokemon.Type == null || pokemon.Name == "")
            {
                return false;
            }

            //Asignacion aleatoria de habilidades en caso de que no se haya llenado
            if (pokemon.Skills.Count == 0)
            {
                Random rnd = new Random();
                double valueMin = 1;
                double valueMax = 30;
                pokemon.Skills = new List<Powers>() { new Powers() { id = $"POW{rnd.Next(0, 100)}AND{rnd.Next(0, 10)}", Attack1 = rnd.Next(0, 40), Attack2 = rnd.Next(0, 40), Attack3 = rnd.Next(0, 40), Attack4 = rnd.Next(0, 40), Defense = Math.Round((valueMin + rnd.NextDouble() * (valueMax - valueMin)), 2) } };
            }

            //En caso de que se haya llenado manualmente validar los limites de los valores permitidos
            if (pokemon.Skills.Count != 0)
            {
                if (pokemon.Skills.Where(
                 skill => skill.Attack1 > 40 || skill.Attack2 > 40 || skill.Attack3 > 40 || skill.Attack4 > 40 ||
                 skill.Defense > 30 || skill.Defense < 1).ToList().Count() > 0)
                {
                    return false;
                }

            }
        }

        return true;
    }
}