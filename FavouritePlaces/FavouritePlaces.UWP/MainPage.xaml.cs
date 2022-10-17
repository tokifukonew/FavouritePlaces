using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace FavouritePlaces.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init("BKFEBEJQmWbm09fq7rZa~Gt5j-u_KxwFdi7kv9fnLpg~Aspi2i4k1pRKAsslXqCOh0L3RicE5MS38cwwNqzyBIDvKB-QJrhYdGDgLQricB59");
            Windows.Services.Maps.MapService.ServiceToken = "BKFEBEJQmWbm09fq7rZa~Gt5j-u_KxwFdi7kv9fnLpg~Aspi2i4k1pRKAsslXqCOh0L3RicE5MS38cwwNqzyBIDvKB-QJrhYdGDgLQricB59";
            LoadApplication(new FavouritePlaces.App());
        }
    }
}
