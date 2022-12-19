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
    public partial class InitPage : ContentPage
    {
        public InitPage()
        {
            InitializeComponent();
            InitAnimation();
            Skip(1);
        }
        private async void Skip(int seconds)
        {
            await Task.Delay(seconds * 1000);
            await Navigation.PushAsync(new AppShell());
        }

        private async void InitAnimation()
        {
            await image.RotateTo(360, 1000);
            image.Rotation = 0;
        }
    }
}