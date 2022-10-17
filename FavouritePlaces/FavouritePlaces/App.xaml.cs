using FavouritePlaces.Services;
using FavouritePlaces.Views;
using FavouritePlaces.Models;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FavouritePlaces
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "places.db";
        public static PlaceRepository database;
        public static PlaceRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new PlaceRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                    System.Diagnostics.Debug.WriteLine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
