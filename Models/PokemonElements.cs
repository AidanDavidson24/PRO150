using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;

namespace Poke_Adventures.Models
{
    //ALL VARIABLES MUST BE NAMED THE SAME AS THE JSON PROPERTY
    public class PokemonElements
    {
        [JsonPropertyName("abilities")]
        public List<AbilityProp> Abilities { get; set; }

        [JsonPropertyName("base_experience")]
        public int base_experience { get; set; }

        [JsonPropertyName("base_experience")]
        public int baseEXP { get; set; }

        [JsonPropertyName("moves")]
        public List<MoveProp> Moves { get; set; }

        [JsonPropertyName("sprites")]
        public SpritesProp Sprites { get; set; }

        [JsonPropertyName("stats")]
        public List<StatsProp> Stats { get; set; }

        [JsonPropertyName("types")]
        public List<TypesProp> Types { get; set; }

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
        
        [JsonPropertyName("slot")]
        public int Slot { get; set; }
    }

    public class MoveProp
    {
        [JsonPropertyName("move")]
        public Common Move { get; set; }
    }

    public class SpritesProp
    {
        [JsonPropertyName("back_default")]
        public string? Back_Default { get; set; }

        [JsonPropertyName("back_female")]
        public string? Back_Female { get; set; }

        [JsonPropertyName("front_default")]
        public string? Front_Default { get; set; }

        [JsonPropertyName("front_female")]
        public string? Front_Female { get; set; }
    }

    public class StatsProp
    {
        [JsonPropertyName("base_stat")]
        public int Base_Stat { get; set; }

        [JsonPropertyName("stat")]
        public Common Stat { get; set; }

    }

    public class TypesProp
    {
        [JsonPropertyName("type")]
        public Common Type { get; set; }
    }

    public class Common
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public Uri? Url { get; set; }

        [JsonPropertyName("id")]    
        public int ID { get; set; }
    }

}