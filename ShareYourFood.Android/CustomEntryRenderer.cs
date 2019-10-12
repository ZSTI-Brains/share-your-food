using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ShareYourFood.Renderers;
using ShareYourFood.Renderer.Android;
using Android.Content;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace ShareYourFood.Renderer.Android
{
    class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                
            }
        }
    }
}
