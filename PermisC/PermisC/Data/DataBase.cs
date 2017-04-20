using System;
using SQLite.Net;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

using PermisC.Models;
 
namespace PermisC.Data
{
    public class CamionDatabase
    {
        private SQLiteConnection _connection;

        public CamionDatabase()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<Tracteur>();
            _connection.CreateTable<Remorque>();
        }

        public IEnumerable<Tracteur> GetTracteurs()
        {
            return (from t in _connection.Table<Tracteur>()
                    select t).ToList();
        }

        public IEnumerable<Tracteur> GetRechTracteurs(string rech)
        {
            return(from t in _connection.Table<Tracteur>().Where(t => t.Immatriculation.Contains(rech))
                  select t).ToList();
        }

        public Tracteur GetTracteurImmat(String immat)
        {
            return _connection.Table<Tracteur>().FirstOrDefault(t => t.Immatriculation.Contains(immat));
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

        public IEnumerable<Remorque> GetRemorques()
        {
            return (from t in _connection.Table<Remorque>()
                    select t).ToList();
        }

        public IEnumerable<Remorque> GetRechRemorque(string rech)
        {
            return (from t in _connection.Table<Remorque>().Where(t => t.Immatriculation.Contains(rech))
                    select t).ToList();
        }

        public Remorque GetRemorque(int id)
        {
            return _connection.Table<Remorque>().FirstOrDefault(t => t.ID == id);
        }

        public Remorque GetRemorqueImmat(String immat)
        {
            return _connection.Table<Remorque>().FirstOrDefault(t => t.Immatriculation.Contains(immat));
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