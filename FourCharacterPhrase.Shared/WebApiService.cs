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
        public static HttpClient Http = new HttpClient();

        public static async Task<object> PostRequest<T>(string serviceName, T sendObject)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(sendObject);
                var requestUri = "https://localhost:44370/" + serviceName;
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
    }
}
