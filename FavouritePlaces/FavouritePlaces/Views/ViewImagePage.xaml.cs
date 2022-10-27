using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FavouritePlaces.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewImagePage : ContentPage
    {
        public ViewImagePage()
        {
            InitializeComponent();
        }
        public ViewImagePage(byte[] viewImage)
        {
            InitializeComponent();
            var imageSource = ImageSource.FromStream(() => new MemoryStream(viewImage));
            ViewImage.Source = imageSource;
            System.Diagnostics.Debug.WriteLine(ViewImage.Source);
        }
    }
}