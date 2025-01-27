﻿using FavouritePlaces.CustomRenderer;
using FavouritePlaces.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace FavouritePlaces.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPlacePage : ContentPage
    {
        public AddPlacePage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.AddPlacePageViewModel()
            {
                TitlePage = "Добавить новое место"
            };
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(55.7555821, 37.6182021), Distance.FromKilometers(50)));
        }
        public AddPlacePage(Models.Place place)
        {
            InitializeComponent();
            BindingContext = new ViewModels.AddPlacePageViewModel(place)
            {
                TitlePage = "Редактирование места"
            };
            map.MoveToRegion(MapSpan.FromCenterAndRadius(place.Position, Distance.FromKilometers(0.2)));
        }

        void OnMapClickedAdd(object sender, MapClickedEventArgs e)
        {
            MessagingCenter.Send<Application, Position>(Application.Current, "SelectLocation", e.Position);
        }
    }
}