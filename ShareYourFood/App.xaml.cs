using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShareYourFood
{
    public partial class App : Application
    {
        public static bool Logged { get; set; }
        public static string FolderPath { get; private set; }
        public static User User { get; set; }
        public static IList<EatingHouse> EatingHouses { get; set; }
        public static IList<ProductOffer> ProductOffers { get; set; }

        public App()
        {
            InitializeComponent();

            Logged = false;
            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            MainPage = new NavigationPage(new MainPage());

            Web.GetHousesInfo(Web.API_URL + "get-eating-houses-info.php");
            Web.GetProductOffers(Web.API_URL + "get-product-offers.php");
        }

        public static async void GoToPreviousPage()
        {
            await Current.MainPage.Navigation.PopAsync();
        }

        public static async void GoToMapPage()
        {
            await Current.MainPage.Navigation.PushAsync(new MapPage { BindingContext = new MapPage() });
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
