using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;

namespace ShareYourFood
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
            var position = new Position(49.673971, 20.079831);

            var map = new Xamarin.Forms.Maps.Map(
                MapSpan.FromCenterAndRadius(position, Distance.FromMiles(0.5f)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            foreach (EatingHouse eh in App.EatingHouses)
            {
                position = new Position(eh.latitude, eh.longitude);
                var pin = new Pin { Label = eh.name, Position = position };
                map.Pins.Add(pin);
            }

            var stack = new StackLayout { Spacing = 0 };
            var button = new Button { Text = "LOL" };
            stack.Children.Add(button);
            stack.Children.Add(map);
            Content = stack;
        }

        public void SetPins()
        {
            foreach (EatingHouse eh in App.EatingHouses)
            {

            }
        }
    }
}