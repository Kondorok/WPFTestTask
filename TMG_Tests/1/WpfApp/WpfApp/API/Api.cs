using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using WpfApp.Models;

namespace WpfApp.API
{
    public class Api
    {
        private readonly HttpClient Client;
        private readonly (string, string) keyHeader = ("TMG-Api-Key", "0J/RgNC40LLQtdGC0LjQutC4IQ==");
        private readonly string baseUrl = "https://tmgwebtest.azurewebsites.net/api/textstrings/";
        public Api()
        {
            Client = new HttpClient();
        }

        public async Task<ResponseMessage> GetResponse(int id)
        {
            using (var requestMessage =
                       new HttpRequestMessage(HttpMethod.Get, GetURL(id)))
            {
                requestMessage.Headers.Add(keyHeader.Item1, keyHeader.Item2);
                var result = Client.SendAsync(requestMessage);
                result.Wait();
                var data = await result.Result.Content.ReadAsStringAsync();
                ResponseMessage responseMessage = JsonConvert.DeserializeObject<ResponseMessage>(data);
                return responseMessage;
            }
        }

        protected string GetURL(int id)
        {
            return baseUrl + id;
        }
    }
}
