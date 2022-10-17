﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FavouritePlaces.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPlacePage : ContentPage
    {
        public AddPlacePage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.AddPlacePageViewModel();
        }
    }
}