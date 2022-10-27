using FavouritePlaces.Models;
using System;
using Xamarin.Forms.Maps;

namespace FavouritePlaces.CustomRenderer
{
    public class CustomPin : Pin
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string IconType { get; set; }

        public CustomPin()
        {

        }
        public CustomPin(PlaceSQL place)
        {
            Label = place.Title;
            Name = place.Title;
            IconType = place.PinIcon;
            Position = new Position(place.Latitude, place.Longitude);
            Address = place.Address;
            Url = "http://xamarin.com/about/";
        }

        public CustomPin(Place place)
        {
            Label = place.Title;
            Name = place.Title;
            IconType = place.PinIcon;
            Position = place.Position;
            Address = place.Address;
            Url = "http://xamarin.com/about/";
        }
    }
}
