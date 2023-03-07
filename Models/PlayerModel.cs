namespace Poke_Adventures.Models
{
    public class PlayerModel
    {
        public static List<CharacterPokemon> PlayerTeam = new List<CharacterPokemon> { };

        public static void AddPokemon(string name, int lvl)
        {
            CharacterPokemon pokemon = new CharacterPokemon(name, lvl);

            PlayerTeam.Add(pokemon);
        }

        public static int GetAverageLevel()
        {
            int averagelvl = 0;
            for (int i = 0; i < PlayerTeam.Count; i++)
            {
                averagelvl += PlayerTeam[i].Level;
            }

            return averagelvl / PlayerTeam.Count;
        }
    }
    public class CharacterPokemon
    {
        public CharacterPokemon(string name, int lvl)
        {
            Name = name;
            Level = lvl;
        }

        public string Name;
        public int Level;
    }
}   