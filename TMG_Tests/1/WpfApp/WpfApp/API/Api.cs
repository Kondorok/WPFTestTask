using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.Models;

/*
 Class for making request to the server and getting response as object of the model class.
 */


namespace WpfApp.API
{
    public class Api
    {
        //HttpClient object for connecting
        private readonly HttpClient Client;
        //Turple for pair (key:value) for heading 
        private readonly (string, string) keyHeader = ("TMG-Api-Key", "0J/RgNC40LLQtdGC0LjQutC4IQ==");

        private readonly string baseUrl = "https://tmgwebtest.azurewebsites.net/api/textstrings/";
        public Api()
        {
            Client = new HttpClient();
        }

        public async Task<ResponseMessage> GetResponse(int id) // Make async request with string index
        {
            using (var requestMessage =
                       new HttpRequestMessage(HttpMethod.Get, baseUrl + id))
            {
                requestMessage.Headers.Add(keyHeader.Item1, keyHeader.Item2);
                var result = await Client.SendAsync(requestMessage);
                if (result.StatusCode != HttpStatusCode.OK) MessageBox.Show($"Bad response for {id} string. Error {result.StatusCode}");
                var data = await result.Content.ReadAsStringAsync();
                //Deserialize JSON to object of the model class
                ResponseMessage responseMessage = JsonConvert.DeserializeObject<ResponseMessage>(data);
                return responseMessage;
            }
        }

    }
}
