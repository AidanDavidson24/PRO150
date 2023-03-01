namespace Poke_Adventures.Models
{
    public class Routes
    {
        public static List<string> AvailableRoutes = new List<string> { "kanto-route-1", "johto-route-29", "hoenn-route-101", "sinnoh-route-201", "unova-route-1" };
        public static List<Common> CurrentRoute = new List<Common>();
        public static Common WildPK = null;

        public static int LoadRoute()
        {
            Random rand = new Random();
            int AreaNum = rand.Next(0, AvailableRoutes.Count - 1);
            Common location = LocationElements.LoadLocation(ActiveRoute()[4]).Areas[0];
            WildPK = LocationAreaElements.LoadLocationArea(location).Pokemon_Encounters[rand.Next(0, LocationAreaElements.LoadLocationArea(location).Pokemon_Encounters.Count)].Pokemon;
            
            return AreaNum;
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
