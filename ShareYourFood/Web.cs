using System.Collections.Generic;
using System.Net.Http;

namespace ShareYourFood
{
    class Web
    {
        private static HttpClient client = new HttpClient();

        public async static string Post(string url, Dictionary<string, string> v = null)
        {
            var content = new FormUrlEncodedContent(v);
            var response = await client.PostAsync(url, content);
            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }
    }
}
