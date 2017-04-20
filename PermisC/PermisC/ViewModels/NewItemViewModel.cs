using PermisC.Data;
using PermisC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PermisC.ViewModels
{
    class NewItemViewModel : BaseViewModel
    {
        public Command plus { get; set; }
        public Command moins { get; set; }

        public INavigation _navigation;

        public NewItemViewModel(INavigation navigation)
        {
            _navigation = navigation;
            plus = new Command(() => Plus());
            moins = new Command(() => Moins());
        }
        Tracteur item;
        public Tracteur Item
        {
            get { return item; }
            set
            {
                item = value;
                OnPropertyChanged();
            }
        }
        string erreur = "";
        public string Erreur
        {
            get { return erreur; }
            set
            {
                erreur = value;
                OnPropertyChanged();
            }
        }

        public void Save(CamionDatabase database)
        {
            Tracteur existant = null;
            int Num;
            var RegImmat = Regex.IsMatch(Item.Immatriculation, "[A-Z]{2}[-][0-9]{3}[-][A-Z]{2}");
            var RegPoid = int.TryParse(Item.PoidTracteur, out Num);
            if (RegImmat)
            {
                if (RegPoid)
                {
                    if ((existant = database.GetTracteurImmat(Item.Immatriculation)) == null)
                    {
                        database.AddTracteur(Item);
                        _navigation.PopToRootAsync();
                    }
                    else
                    {
                        Erreur = "Cette imatriculation a deja été enregistré";
                    }
                }
                else
                {
                    Erreur = "Le poid du tracteur doit etre un chiffre";
                }
            }
            else
            {
                Erreur = "L'immatriculation doit etre de la frome 'AA-666-BB'";
            }
        }

        public void Moins()
        {
            int essieux;
            essieux = int.Parse(Item.Essieux);
            if (essieux > 2)
            {
                essieux--;
            }
            Item.Essieux = essieux.ToString();
        }

        public void Plus()
        {
            int essieux;
            essieux = int.Parse(Item.Essieux);
            essieux++;
            Item.Essieux = essieux.ToString();
        }
    }
}
