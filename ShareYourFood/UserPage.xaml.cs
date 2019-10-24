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
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();

            string name = App.User.FirstName + " " + App.User.LastName;
            nameLabel.Text = "Witaj, " + name + "!";
            emailLabel.Text = App.User.Email;
            pointsLabel.Text = App.User.Points.ToString();
        }
    }
}