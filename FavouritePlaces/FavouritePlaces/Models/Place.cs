using SQLite;
using Xamarin.Forms.Maps;

namespace FavouritePlaces.Models
{
    [Table("Places")]
    public class Place
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public string PlacePosition { get; set; }
        public string ImagePath { get; set; }
        public byte[] Image { get; set; }

        public Position Position { get; set; }
        public PinType pinType { get; set; }


        public override string ToString()
        {
            return $"Место {Title} - {Description}";
        }
    }
}
