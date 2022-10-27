using System.Windows.Input;
using Xamarin.Forms;
using FavouritePlaces.Views;
using System.Collections.ObjectModel;
using FavouritePlaces.Models;
using System.Collections.Generic;
using FavouritePlaces.CustomRenderer;
using System.ComponentModel;
using System;

namespace FavouritePlaces.ViewModels
{
    public class ListOfPlacesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; internal set; }

        public ICommand AddPlaceCommand { get; }
        public ICommand ListViewItemSelectedCommand { get; }


        public ObservableCollection<Models.Place> Places { get; set; }

        public ListOfPlacesViewModel()
        {
            AddPlaceCommand = new Command(AddPlace);
            ListViewItemSelectedCommand = new Command(ListViewItemSelected);
            Places = new ObservableCollection<Models.Place>();

            var PlacesFromDatabase = App.Database.GetItems();
            List<CustomPin> PlacesForMap = new List<CustomPin>();
            foreach (var place in PlacesFromDatabase)
            {
                Places.Add(new Place(place));
                PlacesForMap.Add(new CustomPin(place));
            }

            MessagingCenter.Send <Application, List<CustomPin> > (Application.Current, "SelectItems", PlacesForMap);
            MessagingCenter.Subscribe<Application, Models.Place>(Application.Current, "AddPlace", (sender, arg) =>
            {
                Places.Add(arg);
                //App.Database.SaveItem(arg);
            });
        }

        public Place placeSelected;

        public Place PlaceSelected
        {
            get { return placeSelected; }
            set
            {
                placeSelected = value;
                OnPropertyChanged("ItemSelected");
            }
        }


        public async void AddPlace()
        {
            await Navigation.PushModalAsync(new AddPlacePage());
        }
        private async void ListViewItemSelected()
        {
            await Navigation.PushModalAsync(new ViewPlacePage(placeSelected));
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
