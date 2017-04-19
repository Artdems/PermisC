using System;
using SQLite.Net;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

using PermisC.Models;
 
namespace PermisC.Data
{
    public class TracteurDatabase
    {
        private SQLiteConnection _connection;

        public TracteurDatabase()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<Tracteur>();
        }

        public IEnumerable<Tracteur> GetTracteurs()
        {
            return (from t in _connection.Table<Tracteur>()
                    select t).ToList();
        }

        public Tracteur GetTracteur(int id)
        {
            return _connection.Table<Tracteur>().FirstOrDefault(t => t.ID == id);
        }

        public void DeleteTracteur(int id)
        {
            _connection.Delete<Tracteur>(id);
        }

        public void AddTracteur(Tracteur item)
        {

            _connection.Insert(item);
        }
    }
}