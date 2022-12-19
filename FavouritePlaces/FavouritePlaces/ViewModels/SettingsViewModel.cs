using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FavouritePlaces.ViewModels
{
    public class SettingsViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private Models.Settings _settings;
        public SettingsViewModel()
        {
            _settings = new Models.Settings();

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
