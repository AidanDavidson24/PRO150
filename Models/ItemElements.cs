using System.Net;
using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Poke_Adventures.Models
{
    public class ItemElements
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("cost")]
        public string Cost { get; set; }

        [JsonPropertyName("effect_entries")]
        public List<Effectprop> Effect_Entries { get; set; }

        //[JsonPropertyName("sprites")]
        //public string Sprites { get; set; }

        public static ItemElements Items()
        {

            string json = new WebClient().DownloadString($"https://pokeapi.co/api/v2/item/poke-ball/");
            ItemElements items = JsonConvert.DeserializeObject<ItemElements>(json);
            return items;


        }

        public class ItemValues
        {
            
        }

        public class Effectprop
        {
            [JsonPropertyName("effect")]
            public string Effect { get; set; }

            [JsonPropertyName("short_effect")]
            public string Short_Effect { get; set; }
        }

        //public class ItemSprite
        //{
        //    [JsonPropertyName("sprites")]
        //    public string sprites { get; set; }
        //}
    }
}
