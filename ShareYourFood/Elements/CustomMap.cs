using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace ShareYourFood.Elements
{
    public class CustomMap : Map
    {
        public CustomMap() : base() { }
        public CustomMap(MapSpan ms) : base(ms) { }

        public IList<CustomPin> CustomPins { get; set; }
    }
}
