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

    public class Routes
    {
        static Random rand = new Random();
        public static List<string> AvailableRoutes = new List<string> { "kanto-route-1", "johto-route-29", "hoenn-route-101", "sinnoh-route-201", "unova-route-1", "kalos-route-1", "alola-route-1" };
        public static List<Common> CurrentRoute = new List<Common>();
        public static int AreaNum = rand.Next(0, AvailableRoutes.Count - 1);
        public static Common location = LocationElements.LoadLocation(ActiveRoute()[AreaNum]).Areas[0];
        public static Common WildPK = LocationAreaElements.LoadLocationArea(location).Pokemon_Encounters[0].Pokemon;

        public static List<Common> ActiveRoute()
        {
            var pokemon = LoadLocation.LoadAllLocations();

            foreach (var poke in AvailableRoutes)
            {
                foreach (var mans in pokemon.Results)
                {
                    if (mans.Name == poke)
                    {
                        CurrentRoute.Add(mans);
                    }
                }
            }

            return CurrentRoute;
        }
    }
}