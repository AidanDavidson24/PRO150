using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;

namespace Poke_Adventures.Models
{
    public class TypeElements
    {
        public static TypeElements LoadType(Common type)
        {
            string json = new WebClient().DownloadString(type.Url);
            TypeElements typeElements = JsonConvert.DeserializeObject<TypeElements>(json);
            return typeElements;
        }

        [JsonPropertyName("damage_relations")]
        public RelationsProp Damage_Relations { get; set; }

    }

    public class RelationsProp
    {
        [JsonPropertyName("no_damage_to")]
        public List<Common>? No_Damage_To { get; set; }

        [JsonPropertyName("half_damage_to")]
        public List<Common> Half_Damage_To { get; set; }

        [JsonPropertyName("double_damage_to")]
        public List<Common> Double_Damage_To { get; set; }

        [JsonPropertyName("no_damage_from")]
        public List<Common> No_Damage_From { get; set; }


        [JsonPropertyName("half_damage_from")]
        public List<Common> Half_Damage_From { get; set; }


        [JsonPropertyName("double_damage_from")]
        public List<Common> Double_Damage_From { get; set; }
    }
}
