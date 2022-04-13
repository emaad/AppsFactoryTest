namespace AppsFactoryTestAPI.Helper
{
    public interface IWeatherQuery
    {
         Task<APIResponse> GetWeatherByCityName(string searchByCityName);
         Task<APIResponse> GetWeatherByZipCode(string searchByZipCode);
    }
}
