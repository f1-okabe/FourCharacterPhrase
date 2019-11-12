using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FourCharacterPhrase.Shared
{
    public static class WebApiService
    {
        private static HttpClient Http = new HttpClient();
        private const string baseURL = "https://fourcharacterphraseserver.azurewebsites.net/";
        public static async Task<object> PostRequest<T>(string serviceName, T sendObject)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(sendObject);
                var requestUri = baseURL + serviceName;
                var requestMessage = new HttpRequestMessage()
                {
                    Method = new HttpMethod("POST"),
                    RequestUri = new Uri(requestUri),
                    Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
                };

                Console.WriteLine("Http.SendAsync");
                Console.WriteLine(requestUri);
                Console.WriteLine(jsonString);
                HttpResponseMessage response = await Http.SendAsync(requestMessage);
                response.EnsureSuccessStatusCode(); //will throw an exception if not successful

                Console.WriteLine("response.Content.ReadAsStringAsync()");
                var responseContent = await response.Content.ReadAsStringAsync();
                return JObject.Parse(responseContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }
        }

        public static async Task<T> GetRequest<T,U>(string serviceName, U sendObject)
        {
            string jsonString = JsonConvert.SerializeObject(sendObject);
            var requestUri = $"{baseURL}{serviceName}?para={jsonString}";

            var response = await Http.GetAsync(requestUri);
            response.EnsureSuccessStatusCode(); //will throw an exception if not successful
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);
        }
    }
}
