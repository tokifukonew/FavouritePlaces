using System.Collections.Generic;
using SQLite;

namespace FavouritePlaces.Models
{
    public class PlaceRepository
    {
        SQLiteConnection database;
        private PlaceSQL _placeSQL;
        public PlaceRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<PlaceSQL>();
        }
        public IEnumerable<PlaceSQL> GetItems()
        {
            return database.Table<PlaceSQL>().ToList();
        }
        public Place GetItem(int id)
        {

            return database.Get<Place>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Place>(id);
        }
        public int SaveItem(Place item)
        {
            if(item.Id != 0)
            {
                _placeSQL = new PlaceSQL(item);
                database.Update(_placeSQL);
                return _placeSQL.Id;
            }
            else
            {
                _placeSQL = new PlaceSQL(item);
                return database.Insert(_placeSQL);
            }
        }
    }
}
