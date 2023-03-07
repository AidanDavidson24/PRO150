using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;

namespace Poke_Adventures.Models
{
    public class LoadLocation
    {
        public static Random rand = new Random();
        public static int AreaNum = rand.Next(0, Routes.AvailableRoutes.Count - 1);


        [JsonPropertyName("results")]
        public List<Common> Results { get; set; }

        public static LoadLocation LoadAllLocations()
        {
            string json = new WebClient().DownloadString($"https://pokeapi.co/api/v2/location/?limit=1008\"");
            LoadLocation location = JsonConvert.DeserializeObject<LoadLocation>(json);
            return location;
        }
    }

    public class LocationElements
    {
        public static LocationElements LoadLocation(Common location)
        {
            string json = new WebClient().DownloadString(location.Url);
            LocationElements moveElements = JsonConvert.DeserializeObject<LocationElements>(json);
            return moveElements;
        }

        [JsonPropertyName("areas")]
        public List<Common> Areas { get; set; }
    }

    public class LocationAreaElements
    {
        public static LocationAreaElements LoadLocationArea(Common location)
        {
            string json = new WebClient().DownloadString(location.Url);
            LocationAreaElements moveElements = JsonConvert.DeserializeObject<LocationAreaElements>(json);
            return moveElements;
        }

        [JsonPropertyName("pokemon_encounters")]
        public List<EncountersProp> Pokemon_Encounters { get; set; }
    }

    public class EncountersProp
    {
        [JsonPropertyName("pokemon")]
        public Common Pokemon { get; set; }

        [JsonPropertyName("version_details")]
        public List<VersionProp> Version_Details { get; set; }
    }

    public class VersionProp
    {
        [JsonPropertyName("version")]
        public Common Version { get; set; }
    }
}
