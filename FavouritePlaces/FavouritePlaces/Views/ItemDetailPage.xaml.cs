using FavouritePlaces.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FavouritePlaces.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}