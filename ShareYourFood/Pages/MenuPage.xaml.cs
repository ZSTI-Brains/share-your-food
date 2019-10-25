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
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();

            nameLabel.Text = App.User.FirstName + " " + App.User.LastName;
            emailLabel.Text = App.User.Email;
            pointsLabel.Text = "Posiadasz: " + App.User.Points.ToString() + " punktów";
        }

        async void OpenUserDetails(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserDetailsPage { BindingContext = new UserDetailsPage() });
        }
    }
}