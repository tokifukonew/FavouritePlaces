using FavouritePlaces.CustomRenderer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace FavouritePlaces.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();

            ObservableCollection<CustomPin> customPins = new ObservableCollection<CustomPin>();
            customMap.CustomPins = customPins;


            MessagingCenter.Subscribe<Application, CustomPin>(Application.Current, "SelectItem", (sender, arg) =>
            {
                customPins.Add(arg);
                CreateMap();
            });
            MessagingCenter.Subscribe<Application, List<CustomPin>>(Application.Current, "SelectItems", (sender, args) =>
            {
                foreach (var arg in args)
                    customPins.Add(arg);
                CreateMap();
                //Content = customMap;
            });


            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(55.8295498, 37.6300322), Distance.FromKilometers(50.0)));
            BindingContext = new FavouritePlaces.ViewModels.MapViewModel()
            {
            };
        }

        void CreateMap()
        {
            StackLayout stackLayout = new StackLayout();
            stackLayout.Padding = new Thickness(20, 20);
            stackLayout.Children.Add(customMap);
            Content = stackLayout;
        }
        void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"MapClick: {e.Position.Latitude}, {e.Position.Longitude}");
        }
    }
}