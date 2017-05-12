using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PermisC.Data;
using Xamarin.Forms;
using PermisC.Models;

namespace PermisC.ViewModels
{
    class CoViewModel : BaseViewModel
    {
        private CamionDatabase _database;

        string erreur;
        public string Erreur
        {
            get { return erreur; }
            set
            {
                erreur = value;
                OnPropertyChanged();
            }
        }

        public Command Connection { get; set; }

        User utilisateur;
        public User Utilisateur
        {
            get { return utilisateur; }
            set
            {
                utilisateur = value;
                OnPropertyChanged();
            }
        }

        INavigation _navigation;



        public CoViewModel(CamionDatabase database, INavigation navigation)
        {
            _database = database;
            Utilisateur = new User
            {
                Name = "",
                MDP = "",
            };

            Connection = new Command(() => testConnection());
            _navigation = navigation;
        }


        public void testConnection()
        {
            User existe = _database.GetUserName(Utilisateur.Name);

            if (existe != null && existe.MDP == Utilisateur.MDP)
            {
                Utilisateur = existe;
                _database.connect(Utilisateur);
                _navigation.PopAsync();

            }
            else
            {
                if (_database.GetUser(Utilisateur))
                {
                    _database.connect(Utilisateur);
                    _navigation.PopAsync();
                }
                else
                {
                    Erreur = "Identifiant ou mots de passe\nincorrecte";
                }
            }
        }
    }
}
