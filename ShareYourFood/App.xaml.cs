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

        public App()
        {
            InitializeComponent();
            Logged = false;
            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            MainPage = new NavigationPage(new MainPage());
            Web.GetHousesInfo("https://szaredko.com/share-your-food/get-eating-houses-info.php");
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
