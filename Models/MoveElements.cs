using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;

namespace Poke_Adventures.Models
{
    public class MoveElements
    {
        public static MoveElements LoadMove(Common move)
        {
            string json = new WebClient().DownloadString(move.Url);
            MoveElements moveElements = JsonConvert.DeserializeObject<MoveElements>(json);
            return moveElements;
        }

        [JsonPropertyName("accuracy")]
        public int? Accuracy { get; set; }

        [JsonPropertyName("pp")]
        public int PP { get; set; }

        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        [JsonPropertyName("power")]
        public int? Power { get; set; }

        [JsonPropertyName("damage_class")]
        public Common Damage_Class { get; set; }

        [JsonPropertyName("id")]
        public int ID { get; set; }
        
        [JsonPropertyName("effect_entries")]
        public List<EffectProp> Effect_Entries { get; set; }

        [JsonPropertyName("meta")]
        public MetaProp Meta { get; set; }

        [JsonPropertyName("type")]
        public Common Type { get; set; }
    }

    public class EffectProp
    {
        [JsonPropertyName("effect")]
        public string Effect { get; set; }

        [JsonPropertyName("short_effect")]
        public string Short_Effect { get; set; }
    }

    public class MetaProp
    {
        [JsonPropertyName("ailment")]
        public Common Ailment { get; set; }

        [JsonPropertyName("min_hits")]
        public int? Min_Hits { get; set; }

        [JsonPropertyName("max_hits")]
        public int? Max_Hits { get; set; }

        [JsonPropertyName("min_turns")]
        public int? Min_Turns { get; set; }

        [JsonPropertyName("max_turns")]
        public int? Max_Turns { get; set; }

        [JsonPropertyName("drain")]
        public int Drain { get; set; }

        [JsonPropertyName("healing")]
        public int Healing { get; set; }

        [JsonPropertyName("crit_rate")]
        public int Crit_Rate { get; set; }

        [JsonPropertyName("ailment_chance")]
        public int Ailment_Chance { get; set; }

        [JsonPropertyName("flinch_chance")]
        public int Flinch_Chance { get; set; }

        [JsonPropertyName("stat_chance")]
        public int Stat_Chance { get; set; }
    }
}
