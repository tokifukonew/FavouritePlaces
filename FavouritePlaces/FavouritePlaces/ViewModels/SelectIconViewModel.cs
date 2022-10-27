using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FavouritePlaces.ViewModels
{
    public class SelectIconViewModel
    {
        private string[] _namesIcons = new string[]
        {
            "Home",
            "Gas station",
            "Restaurant",
            "Bus station",
            "Building",
            "Swimming pool",
            "Fastfood",
            "Book",
            "Shop",
            "Toilet",
            "Flag",
            "Fountain",
            "Trash",
            "Park",
            "Tree",
        };
        public Command OnImageButton00ClickedCommand { get; }
        public Command OnImageButton01ClickedCommand { get; }
        public Command OnImageButton02ClickedCommand { get; }
        public Command OnImageButton03ClickedCommand { get; }
        public Command OnImageButton04ClickedCommand { get; }
        public Command OnImageButton10ClickedCommand { get; }
        public Command OnImageButton11ClickedCommand { get; }
        public Command OnImageButton12ClickedCommand { get; }
        public Command OnImageButton13ClickedCommand { get; }
        public Command OnImageButton14ClickedCommand { get; }
        public Command OnImageButton20ClickedCommand { get; }
        public Command OnImageButton21ClickedCommand { get; }
        public Command OnImageButton22ClickedCommand { get; }
        public Command OnImageButton23ClickedCommand { get; }
        public Command OnImageButton24ClickedCommand { get; }


        public SelectIconViewModel()
        {
            OnImageButton00ClickedCommand = new Command(OnImageButton00Clicked);
            OnImageButton01ClickedCommand = new Command(OnImageButton01Clicked);
            OnImageButton02ClickedCommand = new Command(OnImageButton02Clicked);
            OnImageButton03ClickedCommand = new Command(OnImageButton03Clicked);
            OnImageButton04ClickedCommand = new Command(OnImageButton04Clicked);
            OnImageButton10ClickedCommand = new Command(OnImageButton10Clicked);
            OnImageButton11ClickedCommand = new Command(OnImageButton11Clicked);
            OnImageButton12ClickedCommand = new Command(OnImageButton12Clicked);
            OnImageButton13ClickedCommand = new Command(OnImageButton13Clicked);
            OnImageButton14ClickedCommand = new Command(OnImageButton14Clicked);
            OnImageButton20ClickedCommand = new Command(OnImageButton20Clicked);
            OnImageButton21ClickedCommand = new Command(OnImageButton21Clicked);
            OnImageButton22ClickedCommand = new Command(OnImageButton22Clicked);
            OnImageButton23ClickedCommand = new Command(OnImageButton23Clicked);
            OnImageButton24ClickedCommand = new Command(OnImageButton24Clicked);
        }

        private async void OnImageButton00Clicked()
        {
            MessagingCenter.Send<Application, String>(Application.Current, "SelectIcon", _namesIcons[0]);
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        private async void OnImageButton01Clicked()
        {
            MessagingCenter.Send<Application, String>(Application.Current, "SelectIcon", _namesIcons[1]);
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        private async void OnImageButton02Clicked()
        {
            MessagingCenter.Send<Application, String>(Application.Current, "SelectIcon", _namesIcons[2]);
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        private async void OnImageButton03Clicked()
        {
            MessagingCenter.Send<Application, String>(Application.Current, "SelectIcon", _namesIcons[3]);
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        private async void OnImageButton04Clicked()
        {
            MessagingCenter.Send<Application, String>(Application.Current, "SelectIcon", _namesIcons[4]);
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        private async void OnImageButton10Clicked()
        {
            MessagingCenter.Send<Application, String>(Application.Current, "SelectIcon", _namesIcons[5]);
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        private async void OnImageButton11Clicked()
        {
            MessagingCenter.Send<Application, String>(Application.Current, "SelectIcon", _namesIcons[6]);
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        private async void OnImageButton12Clicked()
        {
            MessagingCenter.Send<Application, String>(Application.Current, "SelectIcon", _namesIcons[7]);
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        private async void OnImageButton13Clicked()
        {
            MessagingCenter.Send<Application, String>(Application.Current, "SelectIcon", _namesIcons[8]);
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        private async void OnImageButton14Clicked()
        {
            MessagingCenter.Send<Application, String>(Application.Current, "SelectIcon", _namesIcons[9]);
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        private async void OnImageButton20Clicked()
        {
            MessagingCenter.Send<Application, String>(Application.Current, "SelectIcon", _namesIcons[10]);
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        private async void OnImageButton21Clicked()
        {
            MessagingCenter.Send<Application, String>(Application.Current, "SelectIcon", _namesIcons[11]);
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        private async void OnImageButton22Clicked()
        {
            MessagingCenter.Send<Application, String>(Application.Current, "SelectIcon", _namesIcons[12]);
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        private async void OnImageButton23Clicked()
        {
            MessagingCenter.Send<Application, String>(Application.Current, "SelectIcon", _namesIcons[13]);
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        private async void OnImageButton24Clicked()
        {
            MessagingCenter.Send<Application, String>(Application.Current, "SelectIcon", _namesIcons[14]);
            await App.Current.MainPage.Navigation.PopModalAsync();
        }

    }
}
