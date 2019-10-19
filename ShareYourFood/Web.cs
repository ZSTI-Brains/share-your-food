using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShareYourFood
{
    class Web
    {
        private static HttpClient client = new HttpClient();

        public async static void GetHousesInfo(string url)
        {
            var response = await client.GetAsync(url);
            var responseString = await response.Content.ReadAsStringAsync(); 
            App.EatingHouses = JsonConvert.DeserializeObject<IList<EatingHouse>>(responseString);
        }

        public async static Task Post(string url, Dictionary<string, string> v = null)
        {
            var content = new FormUrlEncodedContent(v);
            var response = await client.PostAsync(url, content);
            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);
        }
    }
}
