using System.Reflection.Emit;

namespace Poke_Adventures.Models
{
    public class PokemonModel
    {
        public static int MakePokemon(Random rand)
        {
            int HP = 1;
            int IV = rand.Next(0, 31);
            int EV = rand.Next(0, 255);
            int level = 10;
            return HP = ((2 * PokemonElements.LoadPokemon(1).Stats[0].Base_Stat + IV + (EV / 4) * level) / 100) + level + 10;
        }
    }
}
