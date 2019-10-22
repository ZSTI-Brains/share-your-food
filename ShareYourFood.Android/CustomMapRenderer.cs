using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Maps.Model;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;

using ShareYourFood.Elements;
using ShareYourFood.Android;
using ShareYourFood.Droid;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace ShareYourFood.Android
{
    public class CustomMapRenderer : MapRenderer
    {
        public CustomMapRenderer(Context context) : base(context) { }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            marker.SetTitle(pin.Label);
            marker.SetSnippet(pin.Address);
            marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.pin));

            return marker;
        }
    }
}