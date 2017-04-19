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

    public class RemorqueDatabase
    {
        private SQLiteConnection _connection;

        public RemorqueDatabase()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<Remorque>();
        }

        public IEnumerable<Remorque> GetRemorques()
        {
            return (from t in _connection.Table<Remorque>()
                    select t).ToList();
        }

        public Remorque GetRemorque(int id)
        {
            return _connection.Table<Remorque>().FirstOrDefault(t => t.ID == id);
        }

        public void DeleteRemorque(int id)
        {
            _connection.Delete<Remorque>(id);
        }

        public void AddRemorque(Remorque item)
        {

            _connection.Insert(item);
        }
    }
}