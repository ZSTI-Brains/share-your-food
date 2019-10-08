using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace ShareYourFood
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void SignIn(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignIn
            {
                BindingContext = new SignIn()
            });
        }

        async void SignUp(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp
            {
                BindingContext = new SignUp()
            });
        }
    }
}
