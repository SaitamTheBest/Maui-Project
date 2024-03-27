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
                using HttpResponseMessage response = await _httpClient.GetAsync("https://api.sampleapis.com/beers/ale");
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

        public async Task<string> getName(int id)
        {
            try
            {
                string responseBody = await getApiData();

                JsonDocument jsonDocument = JsonDocument.Parse(responseBody);

                foreach (var element in jsonDocument.RootElement.EnumerateArray())
                {
                    if (element.GetProperty("id").GetInt32() == id)
                    {
                        string name = element.GetProperty("name").GetString();
                        return name;
                    }
                }
                return "Error 404 : not found";
            }
            catch (Exception e)
            {
                return "Erreur lors de la récupération du name : " + e.Message;
            }
        }

        public async Task<string> getImage(int id)
        {
            try
            {
                string responseBody = await getApiData();

                JsonDocument jsonDocument = JsonDocument.Parse(responseBody);

                foreach (var element in jsonDocument.RootElement.EnumerateArray())
                {
                    if (element.GetProperty("id").GetInt32() == id)
                    {
                        string image = element.GetProperty("image").GetString();
                        return image;
                    }
                }
                return "Error 404 : not found";
            }
            catch (Exception e)
            {
                return "Erreur lors de la récupération du image : " + e.Message;
            }
        }
    }
}
