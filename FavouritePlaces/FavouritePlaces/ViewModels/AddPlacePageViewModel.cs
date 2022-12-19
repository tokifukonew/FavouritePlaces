using FavouritePlaces.Models;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace FavouritePlaces.ViewModels
{
    public  class AddPlacePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Image image = new Image();
        private Models.Place _place;
        private string _oldTitle;
        private bool _edit;

        readonly ObservableCollection<Place> _locations;
        public IEnumerable Locations => _locations;

        public Command SelectImageCommand { get; set;  }
        public Command SelectIconCommand { get; set; }
        public Command SaveCommand { get;  set; }
        public Command ViewImageCommand { get; set; }

        public string TitlePage { get; set; }

        public AddPlacePageViewModel()
        {
            _edit = false;
            _locations = new ObservableCollection<Place>();
            _place = new Models.Place();
            Create();
        }

        public AddPlacePageViewModel(Models.Place place)
        {
            _edit = true;
            _locations = new ObservableCollection<Models.Place>();
            _place = place;
            _oldTitle = place.Title;
            _locations.Clear();
            _locations.Add(place);
            Create();
        }

        private void Create()
        {
            SelectImageCommand = new Command(SelectImage);
            SelectIconCommand = new Command(SelectIcon);
            SaveCommand = new Command(Save, ValidateSave);
            ViewImageCommand = new Command(ViewImage, ValidateViewImage);
            MessagingCenter.Subscribe<Application, Xamarin.Forms.Maps.Position>(Application.Current, "SelectLocation", (sender, arg) =>
            {
                _locations.Clear();
                if (!String.IsNullOrWhiteSpace(Title)
                && !String.IsNullOrWhiteSpace(Address)
                && !String.IsNullOrWhiteSpace(Description))
                {
                    _locations.Add(new Place(Title, Address, arg, Description));
                    Position = arg;
                }
                else
                    Position = arg;
            });
            MessagingCenter.Subscribe<Application, String>(Application.Current, "SelectIcon", (sender, arg) =>
            {
                PinIcon = arg;
            });

            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
            this.PropertyChanged +=
                (_, __) => ViewImageCommand.ChangeCanExecute();
        }


        private async void Save()
        {
            if(String.IsNullOrEmpty(PinIcon))
            {
                bool answer = await Application.Current.MainPage.DisplayAlert("Выбрать иконку места?", "Не выбрана иконка для отображения на карте", "Да", "Нет");
                if(answer)
                {
                    await App.Current.MainPage.Navigation.PushModalAsync(new Views.SelectIconPage());
                    return;
                }
                else
                {
                    _place.PinIcon = "Building";
                    MessagingCenter.Send<Application, Models.Place>(Application.Current, "AddPlace", _place);
                    await App.Current.MainPage.Navigation.PopModalAsync();
                    return;
                }
            }
            else
            {
                if (_edit)
                {
                    MessagingCenter.Send<Application, Models.Place>(Application.Current, "AddPlace", _place);
                    MessagingCenter.Send<Application, String>(Application.Current, "DeletePlace", _oldTitle);
                    await App.Current.MainPage.Navigation.PopModalAsync();
                    await App.Current.MainPage.Navigation.PopModalAsync();
                    return;
                    //await App.Current.MainPage.Navigation.PopModalAsync();
                    //for (var i = 1; i < 2; i++)
                    //{
                    //    mainPage.Navigation.RemovePage(mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
                    //}
                    //App.Current.MainPage.Navigation.RemovePage(App.Current.MainPage.Navigation.NavigationStack[App.Current.MainPage.Navigation.NavigationStack.Count - 1]);
                }
                else
                {
                    MessagingCenter.Send<Application, Models.Place>(Application.Current, "AddPlace", _place);
                    await App.Current.MainPage.Navigation.PopModalAsync();
                    return;
                }
            }
        }
        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(Title)
                && !String.IsNullOrWhiteSpace(Address)
                && !String.IsNullOrWhiteSpace(Description)
                && !String.IsNullOrWhiteSpace(Position.Longitude.ToString())
                && !String.IsNullOrWhiteSpace(Position.Latitude.ToString());
        }
        private async void SelectIcon()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new Views.SelectIconPage());
        }
        private async void ViewImage()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new Views.ViewImagePage(Image));
        }
        private bool ValidateViewImage()
        {
            if (Image != null)
                return true;
            return false;
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
        public string Address
        {
            get { return _place.Address; }
            set
            {
                _place.Address = value;
                OnPropertyChanged("Address");
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

        public Position Position
        {
            get { return _place.Position; }
            set
            {
                _place.Position = value;
                OnPropertyChanged("Position");
            }
        }

        public string PinIcon
        {
            get { return _place.PinIcon; }
            set
            {
                _place.PinIcon = value;
                OnPropertyChanged("PinIcon");
            }
        }
        private async void SelectImage()
        {
            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                image.Source = ImageSource.FromStream(() => stream);
                Image = streamToByteArray(stream);
            }
        }
        private async void Back()
        {
            await App.Current.MainPage.Navigation.PopModalAsync();
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
