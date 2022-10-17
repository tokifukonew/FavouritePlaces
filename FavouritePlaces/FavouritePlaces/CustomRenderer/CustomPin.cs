using Xamarin.Forms.Maps;

namespace FavouritePlaces.CustomRenderer
{
    public class CustomPin : Pin
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string IconType
        {
            get; set;
        }
    }
}
