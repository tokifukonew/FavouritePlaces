using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms.Maps;

namespace FavouritePlaces.CustomRenderer
{
    public class CustomMap : Map
    {
        public ObservableCollection<CustomPin> CustomPins = new ObservableCollection<CustomPin>();
    }
}
