using Xamarin.Forms.Maps;

namespace FavouritePlaces.Models
{
    public class Place
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public byte[] Image { get; set; }
        public string PinIcon { get; set; }
        public Position Position { get; set; }
        public string Address { get; set; }

        public Place()
        {

        }

        public Place(string title, string description, Position position, string address)
        {
            Title = title;
            Description = description;
            ImagePath = null;
            Image = null;
            PinIcon = "Building";
            Position = position;
            Address = address;
        }

        public Place(PlaceSQL placeSQL)
        {
            Id = placeSQL.Id;
            Title = placeSQL.Title;
            Description = placeSQL.Description;
            Image = placeSQL.Image;
            ImagePath = placeSQL.ImagePath;
            Position = new Position(placeSQL.Latitude, placeSQL.Longitude);
            PinIcon = placeSQL.PinIcon;
            Address = placeSQL.Address;
        }

        public override string ToString()
        {
            return $"Место {Title} - {Description}";
        }
    }
}
