using System.Text.Json;

namespace MatiasDevezeApp
{
    class ApiService{
        private HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<String> getApiData()
        {
            try
            {
                using HttpResponseMessage response = await _httpClient.GetAsync("http://www.contoso.com/");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                JsonDocument json = JsonDocument.Parse(responseBody);

                return responseBody.ToString();
            }
            catch (HttpRequestException e)
            {
                return "Message :{0} "+e.Message;
            }
        }

        public async Task<string> getSetup(int id)
        {
            try
            {
                string responseBody = await getApiData();

                JsonDocument jsonDocument = JsonDocument.Parse(responseBody);

                foreach (var element in jsonDocument.RootElement.EnumerateArray())
                {
                    if (element.GetProperty("id").GetInt32() == id)
                    {
                        string setup = element.GetProperty("setup").GetString();
                        return setup;
                    }
                }
                return "Error 404 : not found";
            }
            catch (Exception e)
            {
                return "Erreur lors de la récupération du setup : " + e.Message;
            }
        }

        public async Task<string> getPunchline(int id)
        {
            try
            {
                string responseBody = await getApiData();

                JsonDocument jsonDocument = JsonDocument.Parse(responseBody);

                foreach (var element in jsonDocument.RootElement.EnumerateArray())
                {
                    if (element.GetProperty("id").GetInt32() == id)
                    {
                        string punchline = element.GetProperty("punchline").GetString();
                        return punchline;
                    }
                }
                return "Error 404 : not found";
            }
            catch (Exception e)
            {
                return "Erreur lors de la récupération du setup : " + e.Message;
            }
        }
    }
}
