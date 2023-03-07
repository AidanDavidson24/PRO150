namespace Poke_Adventures.Models
{
    public class Routes
    {
        public static List<string> AvailableRoutes = new List<string> { "kanto-route-1", "johto-route-29", "hoenn-route-101", "sinnoh-route-201", "unova-route-1" };
        public static List<Common> CurrentRoute = new List<Common>();
        public static Common location = LocationElements.LoadLocation(ActiveRoute()[LoadLocation.AreaNum]).Areas[0];
        public static Common WildPK = LocationAreaElements.LoadLocationArea(location).Pokemon_Encounters[LoadLocation.rand.Next(0, LocationAreaElements.LoadLocationArea(location).Pokemon_Encounters.Count)].Pokemon;
        public static PokemonElements otherPokemon;

        public static void LoadRoute()
        {
            otherPokemon = PokemonElements.LoadPokemon(WildPK);
        }

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
