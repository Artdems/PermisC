using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

using Xamarin.Forms;

using SQLite.Net;

using PermisC.Models;
using PermisC.ViewModels;

//using PCLCrypto;

namespace PermisC.Data
{
    public class CamionDatabase
    {
        private SQLiteConnection _connection;
        private bool IsOnline;
        private HttpClient Client = new HttpClient();
        private string user = "client";
        private string mdp = "6wdeuv";



        public CamionDatabase()
        {
            Client.BaseAddress = new Uri("http://192.168.10.183/API/api.php?action=");
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<Tracteur>();
            _connection.CreateTable<Remorque>();
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        //private static string hash_hmacSha1(string data, string key)
        //{
        //    byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        //    byte[] dataBytes = Encoding.UTF8.GetBytes(data);

        //    var algorithm = WinRTCrypto.MacAlgorithmProvider.OpenAlgorithm(MacAlgorithm.HmacSha1);

        //    CryptographicHash hasher = algorithm.CreateHash(keyBytes);
        //    hasher.Append(dataBytes);

        //    byte[] mac = hasher.GetValueAndReset();

        //    StringBuilder sBuilder = new StringBuilder();
        //    for (int i = 0; i < mac.Length; i++)
        //    {
        //        sBuilder.Append(mac[i].ToString("X2"));
        //    }

        //    return sBuilder.ToString().ToLower();
        //}

        public async Task GetTracteursAsync(ItemsViewModel viewModel)
        {
            string signature = user + mdp;
            //Debug.WriteLine(hash_hmacSha1(signature, mdp));

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            var response = Client.GetAsync("getTracteurs").Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrWhiteSpace(json))
                {
                    DeleteAllTract();
                    Boolean immat = false;
                    Boolean poid = false;
                    Boolean ess = false;
                    Tracteur item = new Tracteur();

                    Debug.WriteLine("debut foreach");

                    string[] tracts = json.Split('[', '{', '}', '"', ',', ':');
                    foreach (string tract in tracts)
                    {
                        if (!string.IsNullOrWhiteSpace(tract))
                        {
                            if (immat)
                            {
                                immat = false;
                                item.Immatriculation = tract;
                            }
                            else if (poid)
                            {
                                poid = false;
                                item.PoidTracteur = tract;
                            }
                            else if (ess)
                            {
                                ess = false;
                                item.Essieux = tract;
                                AddLocalTracteur(item);
                            }
                            else if (tract.Contains("Immatriculation"))
                            {
                                immat = true;
                            }
                            else if (tract.Contains("PoidTracteur"))
                            {
                                poid = true;
                            }
                            else if (tract.Contains("Essieux"))
                            {
                                ess = true;
                            }
                        }
                    }
                }
            }

            viewModel.tracteur = (from t in _connection.Table<Tracteur>()
                                  select t).ToList();
            viewModel.IsBusy = false;
        }



        public IEnumerable<Tracteur> GetRechTracteurs(string rech)
        {
            return (from t in _connection.Table<Tracteur>().Where(t => t.Immatriculation.Contains(rech))
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

        public void DeleteTracteur(Tracteur item)
        {
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            var response = Client.GetAsync("DeleteTracteur&immat={item.Immatriculation}").Result;
            _connection.Delete<Tracteur>(item.ID);
        }
        public void AddLocalTracteur(Tracteur item)
        {

            _connection.Insert(item);
        }

        public void AddTracteur(Tracteur item)
        {
            int id = _connection.Table<Tracteur>().Count();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            var response = Client.GetAsync("AddTracteur&Immat={item.Immatriculation}&Poid={item.PoidTracteur}&Ess={item.Essieux}").Result;
            _connection.Insert(item);
        }

        //public IEnumerable<Remorque> GetRemorques()
        //{
        //    return (from t in _connection.Table<Remorque>()
        //            select t).ToList();
        //}

        //public IEnumerable<Remorque> GetRechRemorque(string rech)
        //{
        //    return (from t in _connection.Table<Remorque>().Where(t => t.Immatriculation.Contains(rech))
        //            select t).ToList();
        //}

        //public Remorque GetRemorque(int id)
        //{
        //    return _connection.Table<Remorque>().FirstOrDefault(t => t.ID == id);
        //}

        //public Remorque GetRemorqueImmat(String immat)
        //{
        //    return _connection.Table<Remorque>().FirstOrDefault(t => t.Immatriculation.Contains(immat));
        //}

        //public void DeleteRemorque(int id)
        //{
        //    _connection.Delete<Remorque>(id);
        //}

        //public void AddRemorque(Remorque item)
        //{

        //    _connection.Insert(item);
        //}

        public void DeleteAllTract()
        {
            _connection.DeleteAll<Tracteur>();
        }

        public void DeleteAllRem()
        {
            _connection.DeleteAll<Remorque>();
        }

        public async Task GetRemorquesAsync(RemorqueViewModel viewModel)
        {
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            var response = Client.GetAsync("getRemorques").Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrWhiteSpace(json))
                {
                    DeleteAllRem();
                    Boolean immat = false;
                    Boolean poid = false;
                    Boolean ess = false;
                    Remorque item = new Remorque();

                    Debug.WriteLine("debut foreach");

                    string[] rems = json.Split('[', '{', '}', '"', ',', ':');
                    foreach (string rem in rems)
                    {
                        if (!string.IsNullOrWhiteSpace(rem))
                        {
                            if (immat)
                            {
                                immat = false;
                                item.Immatriculation = rem;
                            }
                            else if (poid)
                            {
                                poid = false;
                                item.PoidRemorque = rem;
                            }
                            else if (ess)
                            {
                                ess = false;
                                item.Essieux = rem;
                                AddLocalRemorque(item);
                            }
                            else if (rem.Contains("Immatriculation"))
                            {
                                immat = true;
                            }
                            else if (rem.Contains("PoidRemorque"))
                            {
                                poid = true;
                            }
                            else if (rem.Contains("Essieux"))
                            {
                                ess = true;
                            }
                        }
                    }
                }
            }

            viewModel.remorque = (from t in _connection.Table<Remorque>()
                                  select t).ToList();
            viewModel.IsBusy = false;
        }



        public IEnumerable<Remorque> GetRechRemorque(string rech)
        {
            return (from t in _connection.Table<Remorque>().Where(t => t.Immatriculation.Contains(rech))
                    select t).ToList();
        }

        public Remorque GetRemorqueImmat(String immat)
        {
            return _connection.Table<Remorque>().FirstOrDefault(t => t.Immatriculation.Contains(immat));
        }

        public Remorque GetRemorque(int id)
        {
            return _connection.Table<Remorque>().FirstOrDefault(t => t.ID == id);
        }

        public void DeleteRemorque(Remorque item)
        {
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            var response = Client.GetAsync("DeleteRemorque&immat={item.Immatriculation}").Result;
            _connection.Delete<Remorque>(item.ID);
        }
        public void AddLocalRemorque(Remorque item)
        {

            _connection.Insert(item);
        }

        public void AddRemorque(Remorque item)
        {
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            var response = Client.GetAsync("AddRemorque&Immat={item.Immatriculation}&Poid={item.PoidRemorque}&Ess={item.Essieux}").Result;
            _connection.Insert(item);
        }
    }
}