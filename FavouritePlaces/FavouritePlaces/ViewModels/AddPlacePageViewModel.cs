using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;

namespace FavouritePlaces.ViewModels
{
    public  class AddPlacePageViewModel : INotifyPropertyChanged
    {
        public Image image = new Image();
        private Models.Place _place;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SelectImageCommand { get; }
        public ICommand BackCommand { get; }
        public AddPlacePageViewModel()
        {
            SelectImageCommand = new Command(SelectImage);
            BackCommand = new Command(Back);
            _place = new Models.Place();
        }
        
        public string Title
        {
            get { return _place.Title; }
            set
            {
                _place.Title = value;
                OnPropertyChanged("Title"); 
            }
        }

        public string Description
        {
            get { return _place.Description; }
            set
            {
                _place.Description = value;
                OnPropertyChanged("Description");
            }
        }

        public byte[] Image
        { 
            get { return _place.Image; } 
            set
            {
                _place.Image = value;
                OnPropertyChanged("Image");
            }
        }

        public async void SelectImage()
        {
            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                image.Source = ImageSource.FromStream(() => stream);
                //Content = image;
                //Models.Place newPlace = new Models.Place { Title = "ВДНХ11", Description = "DescriptionPlace11", PlacePosition = "PlacePositionPlace11", Image = streamToByteArray(stream) };
                //this.Content = image;
                //Places.Add(newPlace);
                //App.Database.SaveItem(newPlace);
                Image = streamToByteArray(stream);
                //PropertyChanged(this, new PropertyChangedEventArgs("Image"));
            }
        }
        public async void Back()
        {
            MessagingCenter.Send<Application, Models.Place>(Application.Current, "AddPlace", _place);
            await App.Current.MainPage.Navigation.PopModalAsync();
        }

        public bool CreatePlace()
        {

            return false;
        }

        public static byte[] streamToByteArray(Stream input)
        {
            MemoryStream ms = new MemoryStream();
            input.CopyTo(ms);
            return ms.ToArray();
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
