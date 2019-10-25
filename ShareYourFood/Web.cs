using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace ShareYourFood
{
    public class Web
    {
        public const string API_URL = "https://szaredko.com/share-your-food/";

        private static string responseString;
        private static HttpClient client = new HttpClient();

        public static async Task SignIn(string url, Dictionary<string, string> v)
        {
            await Post(url, v);
            var msg = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);
            
            if (!msg.ContainsKey("email_correct"))
            {
                var u = new User 
                { 
                    FirstName   = msg["first_name"],
                    LastName    = msg["last_name"],
                    Email       = msg["email"],
                    Password    = msg["password"],
                    Points      = int.Parse(msg["points"])
                };

                App.User = u;
                App.Logged = true;    
            }
        }

        public static async Task SignUp(string url, Dictionary<string, string> v)
        {
            await Post(url, v);
            var msg = JsonConvert.DeserializeObject<Dictionary<string, bool>>(responseString);

            if (msg != null && IsSignUpOK(msg))
            {
                await Application.Current.MainPage.Navigation.PushAsync(new MainPage() 
                {
                    BindingContext = new MainPage()
                });
            }
        }

        public async static void GetHousesInfo(string url)
        {
            var response = await client.GetAsync(url);
            var responseString = await response.Content.ReadAsStringAsync(); 
            App.EatingHouses = JsonConvert.DeserializeObject<IList<EatingHouse>>(responseString);
        }

        public async static void GetProductOffers(string url)
        {
            var response = await client.GetAsync(url);
            var responseString = await response.Content.ReadAsStringAsync();
            App.ProductOffers = JsonConvert.DeserializeObject<IList<ProductOffer>>(responseString);
        }

        public async static Task Post(string url, Dictionary<string, string> v)
        {
            var content = new FormUrlEncodedContent(v);
            var response = await client.PostAsync(url, content);
            responseString = await response.Content.ReadAsStringAsync();
        }

        private static bool IsSignUpOK(Dictionary<string, bool> v)
        {
            return v["first_name_correct"] && v["last_name_correct"] && v["email_correct"] && v["password_correct"];
        }
    }
}
