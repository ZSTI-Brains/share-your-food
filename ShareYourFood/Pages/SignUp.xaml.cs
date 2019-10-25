using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShareYourFood
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
            Title = "Rejestracja";
        }

        async void OnSignUp(object sender, EventArgs e)
        {
            if (passwordEntry.Text != confirmPasswordEntry.Text)
                return;

            Dictionary<string, string> values = new Dictionary<string, string>
            {
                { "first_name", firstNameEntry.Text },
                { "last_name", lastNameEntry.Text },
                { "email", emailEntry.Text },
                { "password", passwordEntry.Text }
            };

            await Web.SignUp(Web.API_URL + "sign-up.php", values);
        }
    }
}