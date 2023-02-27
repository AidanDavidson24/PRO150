
namespace Poke_Adventures.Models
{
    public class TrainerModel
    {          
        // Trainer Team
        public static List<CharacterPokemon> TrainerTeam = new List<CharacterPokemon> { };

        // randomize team based on difficulty
        public static void RandomizeTeam(string difficulty)
        {
            int min = 0;
            int max = 0;
            switch(difficulty)
            {
                case "Easy":
                    min = PlayerModel.avglvl - 3;
                    max = PlayerModel.avglvl + 2;
                    // pool = player pool
                    RandomPokemon(min, max);
                    break;

                case "Medium":
                    min = PlayerModel.avglvl;
                    max = PlayerModel.avglvl + 5;
                    // pool = player pool
                    RandomPokemon(min, max);
                    break;

                case "Hard":
                    min = PlayerModel.avglvl + 1;
                    max = PlayerModel.avglvl + 8;
                    // pool = player pool + 1
                    RandomPokemon(min, max);
                    break;
            }
        }

        public static void RandomPokemon(int lvlMin, int lvlMax)
        {
            TrainerTeam.Clear();

            Random rand = new Random();
            var allPokemon = Pokemon.LoadAllPokemon();

            // gets three random pokemon
            for (int i = 0; i < 3; i++)
            {
                int level = rand.Next(lvlMin, lvlMax);
                var pokemonIndex = rand.Next(allPokemon.Results.Count);
                var pokemonName = PokemonElements.LoadPokemon(pokemonIndex);


                CharacterPokemon pokemon = new CharacterPokemon(pokemonName.Name, level);

                TrainerTeam.Add(pokemon);
            }

        }
    }
}
