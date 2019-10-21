using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace ShareYourFood.Elements
{
    class CustomMap : Map
    {
        public IList<CustomPin> CustomPins { get; set; }
    }
}
