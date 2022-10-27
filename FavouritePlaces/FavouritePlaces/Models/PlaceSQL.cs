using SQLite;


namespace FavouritePlaces.Models
{
    [Table("Places")]
    public class PlaceSQL
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public byte[] Image { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string PinIcon { get; set; }
        public string Address { get; set; }
        public PlaceSQL()
        {

        }

        public PlaceSQL(Place place)
        {
            Id = place.Id;
            Title = place.Title;
            Description = place.Description;
            Address = place.Address;
            ImagePath = place.ImagePath;
            Image = place.Image;
            Latitude = place.Position.Latitude;
            Longitude = place.Position.Longitude;
            PinIcon = place.PinIcon;
            System.Diagnostics.Debug.WriteLine(Latitude + Longitude);
        }


        public override string ToString()
        {
            return $"Место {Title} - {Description}";
        }
    }
}
