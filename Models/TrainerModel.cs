using System.Security.Cryptography.X509Certificates;

namespace Poke_Adventures.Models
{
    public class TrainerModel
    {
        public static PokemonElements PKE = new PokemonElements();

        public List<int> PokemonStats()
        {
            
            List<int> pokemon = PokemonModel.MakePokemon(1);
            return pokemon;
        }

        public PokemonElements Pokemon()
        {
            var PK = PokemonElements.LoadPokemon(1);
            return PK;
        }

        public List<Common> AddPokemon()
        {
            List<Common> pokemonParty = new List<Common>();

            return pokemonParty;
        }
    }
}
