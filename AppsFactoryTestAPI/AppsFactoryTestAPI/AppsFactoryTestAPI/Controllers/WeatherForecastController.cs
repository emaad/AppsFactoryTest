using AppsFactoryTestAPI.Helper;
using Microsoft.AspNetCore.Mvc;

namespace AppsFactoryTestAPI.Controllers
{
    /// <summary>
    /// Controller will be used to retrieve the request and then resturn the desire goal.
    /// </summary>
    [ApiController]
    [Route("/api/weather/forecast")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherQuery _weatherQuery;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherQuery weatherQuery)
        {
            _logger = logger;
            _weatherQuery = weatherQuery;
        }
        /// <summary>
        /// This method is created for sending the request to calling method  to get the response .
        /// </summary>
        /// <param name="searchType">Used to know which option selected. Search by City or Zipcode</param>
        /// <param name="searchText">Search criteria provided by the user</param>
        /// <returns></returns>
        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult> Get(int? searchType, string searchText)
        {
            try
            {
                if (string.IsNullOrEmpty(searchText))//Just on safe side checking the parameter have value or not.
                {
                    return BadRequest(new APIResponse()
                    {
                        Errors = new string[] { "Search criteria required." },
                        Message=ApiMessages.ErrorMessage
                    });
                }
                if (!searchType.HasValue || (searchType != 1 && searchType != 2))//Just on safe side checking the parameter have value or not, selected options are valid.
                {
                    return BadRequest(new APIResponse()
                    {
                        Errors = new string[] { "Search criteria required." },
                        Message = ApiMessages.ErrorMessage
                    });
                }


                if (searchType == 1)
                    return Ok(await _weatherQuery.GetWeatherByCityName(searchText));// Search by city name
                else
                    return Ok(await _weatherQuery.GetWeatherByZipCode(searchText));// Search by zip code
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());//Log error details
                //return error details
                return BadRequest(new APIResponse()
                {
                    Errors = new string[] { ex.Message },
                    Message = ex.Message
                });
            }
        }
    }
}