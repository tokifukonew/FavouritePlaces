using FavouritePlaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FavouritePlaces.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectIconPage : ContentPage
    {
        public SelectIconPage()
        {
            InitializeComponent();
            BindingContext = new SelectIconViewModel();
        }
    }
}