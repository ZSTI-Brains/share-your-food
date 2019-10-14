using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShareYourFood
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignIn : ContentPage
    {
        public SignIn()
        {
            InitializeComponent();
            Title = "Logowanie";
        }

        async void OnSignIn(object sender, EventArgs e)
        {
            Dictionary<string, string> values = new Dictionary<string, string>
            {
                { "email", emailEntry.Text },
                { "password", passwordEntry.Text }
            };

            var content = new FormUrlEncodedContent(values);
            var client = new HttpClient();
            var response = await client.PostAsync("https://szaredko.com/share-your-food/sign-in.php", content);
            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);
        }
    }
}