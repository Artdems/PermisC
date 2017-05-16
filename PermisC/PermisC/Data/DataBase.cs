using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

using PermisC.Models;
using PermisC.ViewModels;

using SQLite.Net;




namespace PermisC.Data
{
    public class CamionDatabase
    {
        private SQLiteConnection _connection;
        private bool IsOnline;
        private string entre;
        public string droit;
        private Api api = new Api();
        private Boolean _isConnect;
        



        public CamionDatabase(Boolean isConnect)
        {
            droit = "utilisateur";

            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<Tracteur>();
            _connection.CreateTable<Remorque>();
            _connection.CreateTable<User>();
            _isConnect = isConnect;
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
           

        }

        //remplis la base de donné distant avec les nouvel entré de tracteur de la base de donné local, vide la base de donné local
        //et la reremplis avec la base de donné distante en fonction de l'entreprise de l'utilisateur actuelr
        public async Task GetTracteursAsync(ItemsViewModel viewModel)
        {

            

            var json = api.GET("getTracteurs", "getTracteurs",_isConnect);
            if (!string.IsNullOrWhiteSpace(json))
            {
                foreach (Tracteur t in _connection.Table<Tracteur>().Where(t => t.Entreprise.Contains(entre)))
                {
                    var existe = api.GET("getTracteurImmat&Immat=" + t.Immatriculation, "getTracteurImmat", _isConnect);
                    if (existe.Contains("null"))
                    {
                        var response = api.GET("AddTracteur&Immat=" + t.Immatriculation + "&Poid=" + t.PoidTracteur + "&Ess=" + t.Essieux, "AddTracteur", _isConnect);
                    }
                    await Task.Delay(1);
                }

                DeleteAllTract();
                Boolean immat = false;
                Boolean poid = false;
                Boolean ess = false;
                Tracteur item = new Tracteur();

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

            viewModel.tracteur = (from t in _connection.Table<Tracteur>().Where(t => t.Entreprise.Contains(entre))
                                  select t).ToList();
            viewModel.IsBusy = false;
        }


        //récupére les tracteur dont l'immatriculation correspond a la recherche sur la base de donné local
        public IEnumerable<Tracteur> GetRechTracteurs(string rech)
        {
            return (from t in _connection.Table<Tracteur>().Where(t => t.Immatriculation.Contains(rech) && t.Entreprise.Contains(entre))
                    select t).ToList();
        }


        //récupére un tracteur sur la base donné distante en fonction de sont immatriculation
        public Tracteur GetTracteurImmat(String immat)
        {
            return _connection.Table<Tracteur>().FirstOrDefault(t => t.Immatriculation.Contains(immat) && t.Entreprise.Contains(entre));
        }

        //récuppére un tracteur de la base de donné local grace a sont ID
        public Tracteur GetTracteur(int id)
        {
            return _connection.Table<Tracteur>().FirstOrDefault(t => t.ID == id && t.Entreprise.Contains(entre));
        }


        //supprime un tracteur de la base de donné local
        public void DeleteTracteur(Tracteur item)
        {
            var response = api.GET("DeleteTracteur&immat="+item.Immatriculation, "DeleteTracteur",_isConnect);
            _connection.Delete<Tracteur>(item.ID);
        }

        //ajoute un tracteur uniquement sur la base donné local
        public void AddLocalTracteur(Tracteur item)
        {
            item.Entreprise = entre;
            _connection.Insert(item);
        }


        //ajoute un tracteur sur la base de donné local et distant
        public void AddTracteur(Tracteur item)
        {
            item.Entreprise = entre;
            var response = api.GET("AddTracteur&Immat="+item.Immatriculation+"&Poid="+item.PoidTracteur+"&Ess="+item.Essieux, "AddTracteur",_isConnect);
            _connection.Insert(item);
        }

        //supprime toute les remorque de la base de donné local
        public void DeleteAllTract()
        {
            _connection.DeleteAll<Tracteur>();
        }

        //suprime toute les remorque de la base de donné local
        public void DeleteAllRem()
        {
            _connection.DeleteAll<Remorque>() ;
        }


        //remplis la base de donné distant avec les nouvel entré de la base de donné local, vide la base de donné local
        //et la reremplis avec la base de donné distante en fonction de l'entreprise de l'utilisateur actuele
        public async Task GetRemorquesAsync(RemorqueViewModel viewModel)
        {
            var json = api.GET("getRemorques", "getRemorques",_isConnect);
            if (!string.IsNullOrWhiteSpace(json))
            {
                foreach (Remorque t in _connection.Table<Remorque>())
                {
                    var existe = api.GET("getRemorqueImmat&Immat=" + t.Immatriculation, "getRemorqueImmat", _isConnect);
                    if (existe.Contains("null"))
                    {
                        var response = api.GET("AddRemorque&Immat=" + t.Immatriculation + "&Poid=" + t.PoidRemorque + "&Ess=" + t.Essieux, "AddRemorque", _isConnect);
                    }
                    await Task.Delay(1);
                }
                DeleteAllRem();
                Boolean immat = false;
                Boolean poid = false;
                Boolean ess = false;
                Remorque item = new Remorque();

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

            viewModel.remorque = (from t in _connection.Table<Remorque>()
                                  select t).ToList();
            viewModel.IsBusy = false;
        }


        //rencherche des remoque dont l'immatriculation correspond a la recherche sur la base de donné local
        public IEnumerable<Remorque> GetRechRemorque(string rech)
        {
            return (from t in _connection.Table<Remorque>().Where(t => t.Immatriculation.Contains(rech) && t.Entreprise.Contains(entre))
                    select t).ToList();
        }

        //récuppére une remorque sur la base de donné distante en fonction de sont immatriculation
        public Remorque GetRemorqueImmat(String immat)
        {
            return _connection.Table<Remorque>().FirstOrDefault(t => t.Immatriculation.Contains(immat) && t.Entreprise.Contains(entre));
        }


        //récupére une remorque de la base de donné local avec son ID
        public Remorque GetRemorque(int id)
        {
            return _connection.Table<Remorque>().FirstOrDefault(t => t.ID == id && t.Entreprise.Contains(entre));
        }

        //supprime une remorque de la base de donné local et distant
        public void DeleteRemorque(Remorque item)
        {
            var response = api.GET("DeleteRemorque&immat="+item.Immatriculation, "DeleteRemorque",_isConnect);
            _connection.Delete<Remorque>(item.ID);
        }

        //ajoute une remorque uniquement a la base de donné local
        public void AddLocalRemorque(Remorque item)
        {
            item.Entreprise = entre;
            _connection.Insert(item);
        }


        //Ajoute un remorque a la base deonné local et distante
        public void AddRemorque(Remorque item)
        {
            item.Entreprise = entre;
            var response = api.GET("AddRemorque&Immat="+item.Immatriculation+"&Poid="+item.PoidRemorque+"&Ess="+item.Essieux, "AddRemorque",_isConnect);
            _connection.Insert(item);
        }

        //vérifie si l'utilisateur existe deja dans la base donné local
        public User GetUserName(string name)
        {
            return _connection.Table<User>().FirstOrDefault(t => t.Name.Contains(name));
        }


        //ajoute un utilisateur dans la base de donné local
        public void AddUser(User user)
        {
            _connection.Insert(user);
        }


        //récupére l'utilisateur sur la base de donné distant, met a jour la variable entreprise et la variable droit
        public Boolean GetUser(User user)
        {
            api.connect(user.Name, user.MDP);
            var response = api.GET("GetUser", "GetUser", _isConnect);
            if (response.Contains("false"))
            {
                api.connect("", "");
                return false;
                entre = "null";
                
            }
            else if (_isConnect)
            {
                Boolean ent = false;
                Boolean droi = false;

                string[] données = response.Split('[', '{', '}', '"', ',', ':');
                foreach (string donnée in données)
                {

                    if (!string.IsNullOrWhiteSpace(donnée))
                    {
                        if (ent)
                        {
                            ent = false;
                            user.Entreprise = donnée;
                        }
                        else if (droi)
                        {
                            droi = false;
                            user.Droit = donnée;
                        }
                        else if (donnée.Contains("entreprise"))
                        {
                            ent = true;
                        }
                        else if (donnée.Contains("droit"))
                        {
                            droi = true;
                        }
                    }
                }
                entre =user.Entreprise;
                droit = user.Droit;
                AddUser(user);
                return true;
            }
            else
            {
                return false;
            }
        }


        //enregistre le user et le mdp le l'utilisateur courant, pour permetre le hashage des url et la securisation de l'api
        public void connect(User user)
        {
            api.connect(user.Name,user.MDP);
            entre = user.Entreprise;
            droit = user.Droit;
        }
    }
}