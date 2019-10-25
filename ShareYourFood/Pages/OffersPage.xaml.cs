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
    public partial class OffersPage : ContentPage
    {
        public OffersPage()
        {
            InitializeComponent();

            foreach (ProductOffer po in App.ProductOffers)
            {
                var grid = new Grid();

                grid.RowDefinitions.Add(new RowDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(6, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                var n = new Label { Text = po.name, TextColor = Color.FromHex("333333") };
                var on = new Label { Text = po.offeror_name, TextColor = Color.FromHex("333333") };
                var d = new Label { Text = po.discount.ToString(), TextColor = Color.FromHex("333333") };

                grid.Children.Add(n, 0, 0);
                grid.Children.Add(on, 1, 0);
                grid.Children.Add(d, 2, 0);

                OffersLayout.Children.Add(grid);
            }
        }
    }
}