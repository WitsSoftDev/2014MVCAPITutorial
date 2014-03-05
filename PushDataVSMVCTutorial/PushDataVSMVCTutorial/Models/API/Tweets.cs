using Newtonsoft.Json;

namespace PushDataVSMVCTutorial.Models.API
{
    public class Tweets
    {
        [JsonProperty(PropertyName = "id")]
        public System.Data.DataTable Ids { get; set; }
    }
}