using System.Net;
using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Poke_Adventures.Models
{
    public class AllItems
    {
        [JsonPropertyName("results")]
        public List<Common> Results { get; set; }

        public static AllItems LoadAllItems()
        {
            string json = new WebClient().DownloadString($"https://pokeapi.co/api/v2/item/?limit=2050");
            AllItems items = JsonConvert.DeserializeObject<AllItems>(json);
            return items;
        }
    }

    public class ItemElements
    {
        public static ItemElements LoadItem(Common item)
        {
            string json = new WebClient().DownloadString(item.Url);
            ItemElements ItemEle = JsonConvert.DeserializeObject<ItemElements>(json);
            return ItemEle;
        }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("effect_entries")]
        public List<Effectprop> Effect_Entries { get; set; }

        [JsonPropertyName("sprites")]
        public ItemSprite Sprites { get; set; }

        

        public class ItemValues
        {
            public int potionHealing = 20;
            public int superpotionHealing = 50;
            public int hyperpotionHealing = 200;
            public int maxpotionHealing = 2000;
        }

        public class Effectprop
        {
            [JsonPropertyName("effect")]
            public string Effect { get; set; }

            [JsonPropertyName("short_effect")]
            public string Short_Effect { get; set; }
        }

        public class ItemSprite
        {
            [JsonPropertyName("default")]
            public string Defualt { get; set; }
        }
    }
}