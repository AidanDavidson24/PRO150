namespace Poke_Adventures.Models
{
    public class PlayerModel
    {
        static Random rand = new Random();
        public static List<string> PlayerTeam = new List<string> { "bulbasaur", "squirtle" };
        public static List<string> AvailableRoutes = new List<string> { "kanto-route-1","johto-route-29", "hoenn-route-101", "sinnoh-route-201", "unova-route-1", "kalos-route-1", "alola-route-1" };
        public static List<Common> PTeam = new List<Common>();
        public static List<Common> CurrentRoute = new List<Common>();
        public static int AreaNum = rand.Next(0, AvailableRoutes.Count-1);
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

        public static List<Common> Team()
        {
            var pokemon = Pokemon.LoadAllPokemon();

            foreach (var poke in PlayerTeam)
            {
                foreach (var mans in pokemon.Results)
                {
                    if (mans.Name == poke && PTeam.Count() != 6)
                    {
                        PTeam.Add(mans);
                    }
                }
            }
            return PTeam;
        }
    }
}
