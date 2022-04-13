using AppsFactoryTestAPI.Models;

namespace AppsFactoryTestAPI.Helper
{
    /// <summary>
    /// This class will accept the parameters from the controller for searching and then send the request to API to get the result.
    /// </summary>
    public class WeatherQuery : IWeatherQuery
    {
        protected readonly IConfiguration _configuration;
        private readonly string apiKey;
        private readonly string url;

        public WeatherQuery(IConfiguration configuration)
        {
            _configuration = configuration;
            apiKey = _configuration.GetValue<string>("OpenWeatherSettings:ApiKey");
            url = _configuration.GetValue<string>("OpenWeatherSettings:URL");
        }

        /// <summary>
        /// This method will send the request to search weather via provided city name
        /// </summary>
        /// <param name="searchText">Search by city name</param>
        /// <returns></returns>
        public async Task<APIResponse> GetWeatherByCityName(string searchByCityName)
        {
            return await GetAPIResults(string.Format(url, "q", searchByCityName, apiKey));
        }
        /// <summary>
        /// This method will send the request to search weather via provided zipcode
        /// </summary>
        /// <param name="searchText">Search by zipcode</param>
        /// <returns></returns>
        public async Task<APIResponse> GetWeatherByZipCode(string searchByZipCode)
        {
            return await GetAPIResults(string.Format(url, "zip", searchByZipCode, apiKey));
        }
        /// <summary>
        /// Execute the API with relevant provided information.
        /// </summary>
        /// <param name="url">Fomatted URl with relevant values</param>
        /// <returns>return the result</returns>
        private async Task<APIResponse> GetAPIResults(string url)
        {
            HttpClient http = new HttpClient();
            var dataTypiCode = await http.GetFromJsonAsync<WeatherResponseModel>(url);//pulling json data using URL

            return new APIResponse()
            {
                Data = dataTypiCode,
                Message = ApiMessages.SuccessMessage
            };
        }
    }
}
