using System.Net.Http.Json;

namespace MatiasDevezeApp
{
    public class ApiService
    {
        private HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://api.sampleapis.com/beers/")
        };

        public async Task<List<Beer>> FetchData()
        {
            return await _httpClient.GetFromJsonAsync<List<Beer>>("ale");
        }
    }
}