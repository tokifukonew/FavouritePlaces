using System.Windows.Input;
using Xamarin.Forms;
using FavouritePlaces.Views;
using System.Collections.ObjectModel;

namespace FavouritePlaces.ViewModels
{
    public class ListOfPlacesViewModel
    {
        public INavigation Navigation { get; internal set; }

        public ICommand AddPlaceCommand { get; }

        public ObservableCollection<Models.Place> Places { get; set; }

        public ListOfPlacesViewModel()
        {
            AddPlaceCommand = new Command(AddPlace);
            Places = new ObservableCollection<Models.Place>();
            MessagingCenter.Subscribe<Application, Models.Place>(Application.Current, "AddPlace", (sender, arg) =>
            {
                Places.Add(arg);
            });
        }

        public async void AddPlace()
        {
            await Navigation.PushModalAsync(new AddPlacePage());
        }

    }
}
