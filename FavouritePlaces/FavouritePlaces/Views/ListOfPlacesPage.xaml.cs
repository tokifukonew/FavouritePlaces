using FavouritePlaces.ViewModels;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FavouritePlaces.Views
{
    public partial class ListOfPlacesPage : ContentPage
    {
        public Image image = new Image();

        public ListOfPlacesPage()
        {
            InitializeComponent();


            this.BindingContext = new ListOfPlacesViewModel()
            {
                Navigation = this.Navigation
            };
        }

        private void PlaceList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                System.Diagnostics.Debug.WriteLine("SelectedItem" + e.SelectedItem.ToString());
        }

        private void PlaceList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
                System.Diagnostics.Debug.WriteLine("ItemTapped" + e.Item.ToString());
        }
    }
}