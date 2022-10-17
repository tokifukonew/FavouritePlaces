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
                customMap.CustomPins.Add(arg);
                Content = customMap;
            });
            MessagingCenter.Subscribe<Application, List<CustomPin>>(Application.Current, "SelectItems", (sender, args) =>
            {
                foreach (var arg in args)
                    customPins.Add(arg);
                StackLayout stackLayout = new StackLayout();
                stackLayout.Padding = new Thickness(20, 20);
                Button button = new Button();
                button.Text = "ADD";
                button.SetBinding(Button.CommandProperty, "ADDCommand");
                stackLayout.Children.Add(customMap);
                stackLayout.Children.Add(button);
                Content = stackLayout;
                //Content = customMap;
            });


            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(37.79752, -122.40183), Distance.FromMiles(1.0)));
            BindingContext = new FavouritePlaces.ViewModels.MapViewModel()
            {
            };
        }
        void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"MapClick: {e.Position.Latitude}, {e.Position.Longitude}");
        }
    }
}