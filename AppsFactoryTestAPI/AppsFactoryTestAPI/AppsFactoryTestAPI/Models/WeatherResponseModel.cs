using Newtonsoft.Json;

namespace AppsFactoryTestAPI.Models
{
    /// <summary>
    /// Class created to get the values from the API
    /// </summary>
    public class WeatherResponseModel
    {
        [JsonProperty("list")]
        public List<WeatherResponse> list { get; set; }
    }
    /// <summary>
    /// nested classed created to deserialize the data into the proper list and parameters.
    /// Only required parameters pulled.
    /// </summary>
    public class WeatherResponse
    {
        [JsonProperty("dt")]
        public int dt { get; set; }
        public class MainAttributeClass
        {
            [JsonProperty("temp")]
            public decimal temp { get; set; }
            [JsonProperty("feels_like")]
            public decimal feels_like { get; set; }
            [JsonProperty("temp_min")]
            public decimal temp_min { get; set; }
            [JsonProperty("temp_max")]
            public decimal temp_max { get; set; }
            [JsonProperty("pressure")]
            public decimal pressure { get; set; }
            [JsonProperty("sea_level")]
            public decimal sea_level { get; set; }
            [JsonProperty("grnd_level")]
            public decimal grnd_level { get; set; }
            [JsonProperty("humidity")]
            public decimal humidity { get; set; }
            [JsonProperty("temp_kf")]
            public decimal temp_kf { get; set; }
        }
        public MainAttributeClass main { get; set; }

        public class WindClass
        {

            [JsonProperty("speed")]
            public decimal speed { get; set; }
            [JsonProperty("deg")]
            public decimal deg { get; set; }
            [JsonProperty("gust")]
            public decimal gust { get; set; }
        }

        [JsonProperty("wind")]
        public WindClass wind { get; set; }

        [JsonProperty("dt_txt")]
        public string dt_txt { get; set; }
    }
}