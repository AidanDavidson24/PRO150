namespace Poke_Adventures.Models
{
    public class PlayerModel
    {
        public static List<CharacterPokemon> PlayerTeam = new List<CharacterPokemon> { };

        public static int avglvl = GetAverageLevel();

        public static void AddPokemon(string name, int lvl)
        {
            CharacterPokemon mon = new CharacterPokemon(name, lvl);

            PlayerTeam.Add(mon);
        }

        public static int GetAverageLevel()
        {
            int averagelvl = 0;
            for (int i = 1; i < PlayerTeam.Count; i++)
            {
                averagelvl += PlayerTeam[i - 1].Level;
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
