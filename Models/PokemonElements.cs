using Newtonsoft.Json;
using System;
using System.Net;
using System.Text.Json.Serialization;

namespace Poke_Adventures.Models
{
    //ALL VARIABLES MUST BE NAMED THE SAME AS THE JSON PROPERTY
    public class Pokemon
    {
        [JsonPropertyName("results")]
        public List<Common> Results { get; set; }

        public static Pokemon LoadAllPokemon()
        {
            string json = new WebClient().DownloadString($"https://pokeapi.co/api/v2/pokemon/?limit=1008\"");
            Pokemon pokemon = JsonConvert.DeserializeObject<Pokemon>(json);
            return pokemon;
        }

        public static int GetBulbHP()
        {
            //int bulbHP = PokemonModel.MakePokemon(1)[1];
            int bulbHP = 30;
            return bulbHP;
        }
        public static int GetCharHP()
        {
            //int charHP = PokemonModel.MakePokemon(4)[1];
            int charHP = 30;
            return charHP;
        }
    }



    public class PokemonElements
    {
        [JsonPropertyName("abilities")]
        public List<AbilityProp> Abilities { get; set; }

        [JsonPropertyName("base_experience")]
        public float? base_experience { get; set; }

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

        //public static PokemonElements LoadPokemon(Common pokemon)
        //{
        //    string json = new WebClient().DownloadString(pokemon.Url);
        //    PokemonElements PEpokemon = JsonConvert.DeserializeObject<PokemonElements>(json);
        //    return PEpokemon;
        //}
        public static PokemonElements LoadPokemon(int num)
        {
            string json = new WebClient().DownloadString($"https://pokeapi.co/api/v2/pokemon/{num}");
            PokemonElements PEpokemon = JsonConvert.DeserializeObject<PokemonElements>(json);
            return PEpokemon;
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
