﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;

using ShareYourFood.Elements;

namespace ShareYourFood
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public Xamarin.Forms.Maps.Map map;

        private ImageButton menuButton;

        public MapPage()
        {
            InitializeComponent();

            var position = new Position(49.673971, 20.079831);
            map = new CustomMap(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(0.5f)))
            {
                WidthRequest = Application.Current.MainPage.Width,
                IsShowingUser = true
            };
            InitPins();       
            GridLayout.Children.Add(map, 0, 1);
            Grid.SetColumnSpan(map, 3);
            
            if (App.Logged)
            {
                menuButton = new ImageButton
                {
                    Source = "menu_icon.png",
                    Padding = new Thickness(0, 18),
                    BackgroundColor = Color.Transparent
                };
                menuButton.Clicked += OnMenu;
                GridLayout.Children.Add(menuButton, 2, 0);
            }

            GetLocation();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!App.Logged && menuButton != null)
            {
                GridLayout.Children.Remove(menuButton);
                menuButton = null;
            }
        }

        public void InitPins()
        {
            foreach (EatingHouse eh in App.EatingHouses)
            {
                var position = new Position(eh.latitude, eh.longitude);
                var pin = new Pin { Label = eh.name, Address = eh.address, Position = position };
                map.Pins.Add(pin);
            }
        }

        public async void GetLocation()
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            var position = new Position(location.Latitude, location.Longitude);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(2.5)));
        }

        async void OnMenu(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuPage() { BindingContext = new MenuPage() });
        }
    }
}