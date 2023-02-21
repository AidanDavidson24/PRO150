using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;

namespace Poke_Adventures.Models
{
    public class AbilityElements
    {
        public static AbilityElements LoadAbility(Common ability)
        {
            string json = new WebClient().DownloadString(ability.Url);
            AbilityElements abilityElements = JsonConvert.DeserializeObject<AbilityElements>(json);
            return abilityElements;
        }

        [JsonPropertyName("effect_entries")]
        public List<EffectProp> Effect_Entries { get; set; }
    }
}
