using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace FavouritePlaces.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewPlacePage : ContentPage
    {
        public ViewPlacePage()
        {
            InitializeComponent();
        }
        public ViewPlacePage(Models.Place place)
        {
            InitializeComponent();
            BindingContext = new ViewModels.ViewPlaceViewModel(place);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(place.Position, Distance.FromKilometers(0.2)));
        }

    }
}