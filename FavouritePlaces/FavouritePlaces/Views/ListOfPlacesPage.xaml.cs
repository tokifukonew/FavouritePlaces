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
        byte[] data;
        public ObservableCollection<Models.Place> Places { get; set; }

        public ListOfPlacesPage()
        {
            InitializeComponent();


            Places = new ObservableCollection<Models.Place>();
            /*
            {
                new Models.Place {Title="ВДНХ", Description="DescriptionPlace1", PlacePosition="PlacePositionPlace1", /*ImagePath="Resources/Place1.jpg"},
                //new Models.Place {Title="TitlePlace2", Description="DescriptionPlace2", PlacePosition="PlacePositionPlace2", ImagePath="Resources/Place1.jpg"},
                //new Models.Place {Title="TitlePlace2", Description="DescriptionPlace3", PlacePosition="PlacePositionPlace3", ImagePath="Resources/Place1.jpg"},
                //new Models.Place {Title="TitlePlace2", Description="DescriptionPlace4", PlacePosition="PlacePositionPlace4", ImagePath="Resources/Place1.jpg"}
            };*/
            //Models.Place placeVDNKH = new Models.Place { Id = 2, Title = "ВДНХ", Description = "DescriptionPlace1", PlacePosition = "PlacePositionPlace1", ImagePath = "Resources/Place1.jpg" };
            //App.Database.SaveItem(placeVDNKH);
            this.BindingContext = new ListOfPlacesViewModel()
            {
                Navigation = this.Navigation
            };
        }

        async void PlaceList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                System.Diagnostics.Debug.WriteLine(e.SelectedItem.ToString());
            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                image.Source = ImageSource.FromStream(() => stream);
                System.Diagnostics.Debug.WriteLine(image.Source.ToString());
                //Content = image;
                Models.Place newPlace = new Models.Place { Title = "ВДНХ11", Description = "DescriptionPlace11", PlacePosition = "PlacePositionPlace11", Image = streamToByteArray(stream) };
                //this.Content = image;
                //Places.Add(newPlace);
                App.Database.SaveItem(newPlace);
            }
                foreach(var place in Places)
                {
                    System.Diagnostics.Debug.WriteLine(place.Title);
                }
        }

        private void PlaceList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(e.Item != null)
                System.Diagnostics.Debug.WriteLine(e.Item.ToString());
        }

        async void OnButtonClicked(object sender, System.EventArgs e)
        {
            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                image.Source = ImageSource.FromStream(() => stream);
                System.Diagnostics.Debug.WriteLine(image.Source.ToString());
                //Content = image;
                Models.Place newPlace = new Models.Place { Title = "ВДНХ11", Description = "DescriptionPlace11", PlacePosition = "PlacePositionPlace11", Image = streamToByteArray(stream) };
                //this.Content = image;
                Places.Add(newPlace);
                App.Database.SaveItem(newPlace);
            }
            foreach (var place in Places)
            {
                System.Diagnostics.Debug.WriteLine(place.Title);
            }
        }

        public static byte[] streamToByteArray(Stream input)
        {
            MemoryStream ms = new MemoryStream();
            input.CopyTo(ms);
            return ms.ToArray();
        }

    }
}