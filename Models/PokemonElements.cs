﻿using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;

namespace Poke_Adventures.Models
{
    public class PokemonElements
    {       

        [JsonPropertyName("abilities")]
         public List<AbilityProp> Abilities { get; set; }

        [JsonPropertyName("moves")]
         public List<MoveProp> Moves { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("url")]
        public Uri? Url { get; set; }

        public static PokemonElements LoadPokemon(int num)
        {
            string json = new WebClient().DownloadString($"https://pokeapi.co/api/v2/pokemon/{num}");
            PokemonElements pokemon = JsonConvert.DeserializeObject<PokemonElements>(json);
            return pokemon;
        }
    }

    public class AbilityProp
    {
        [JsonPropertyName("ability")]
        public Common Ability { get; set; }

        [JsonPropertyName("is_hidden")]
        public bool IsHidden { get; set; }
    }

    public class MoveProp
    {
        [JsonPropertyName("move")]
        public Common Move { get; set; }
    }

    public class Common
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public Uri? Url { get; set; }
    }

}
