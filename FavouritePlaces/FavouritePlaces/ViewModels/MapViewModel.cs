﻿using FavouritePlaces.CustomRenderer;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace FavouritePlaces.ViewModels
{
    public class MapViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MapViewModel()
        {
            ListOfPlacesViewModel listOfPlacesViewModel = new ListOfPlacesViewModel();
        }




        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
