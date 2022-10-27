using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms.Maps;

namespace FavouritePlaces.ViewModels
{
    public class ViewPlaceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Models.Place _place;
        readonly ObservableCollection<Models.Place> _locations;
        public IEnumerable Locations => _locations;
        public ViewPlaceViewModel()
        {

        }
        public ViewPlaceViewModel(Models.Place place)
        {
            _place = place;
            _locations = new ObservableCollection<Models.Place>();
            _locations.Clear();
            _locations.Add(place);
        }


        public string Title
        {
            get { return _place.Title; }
            set
            {
                _place.Title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Address
        {
            get { return _place.Address; }
            set
            {
                _place.Address = value;
                OnPropertyChanged("Address");
            }
        }
        public string Description
        {
            get { return _place.Description; }
            set
            {
                _place.Description = value;
                OnPropertyChanged("Description");
            }
        }
        public byte[] Image
        {
            get { return _place.Image; }
            set
            {
                _place.Image = value;
                OnPropertyChanged("Image");
            }
        }

        public Position Position
        {
            get { return _place.Position; }
            set
            {
                _place.Position = value;
                OnPropertyChanged("Position");
            }
        }

        public string PinIcon
        {
            get { return _place.PinIcon; }
            set
            {
                _place.PinIcon = value;
                OnPropertyChanged("PinIcon");
            }
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
