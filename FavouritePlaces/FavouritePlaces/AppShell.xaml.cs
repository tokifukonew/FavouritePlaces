using FavouritePlaces.ViewModels;
using FavouritePlaces.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FavouritePlaces
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));
            Routing.RegisterRoute(nameof(ListOfPlacesPage), typeof(ListOfPlacesPage));
        }

    }
}
