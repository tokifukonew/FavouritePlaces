using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using Xamarin.Forms;

namespace FavouritePlaces.Models
{
    public class PlaceRepository
    {
        SQLiteConnection database;
        public PlaceRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Place>();
        }
        public IEnumerable<Place> GetItems()
        {
            return database.Table<Place>().ToList();
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
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
        public static byte[] ConvertStreamtoByte(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
