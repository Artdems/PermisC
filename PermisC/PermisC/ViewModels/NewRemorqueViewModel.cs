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
    public class NewRemorqueViewModel : BaseViewModel
    {
        Remorque item;
        public Remorque Item
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

        public Boolean Save(RemorqueDatabase database)
        {
            Boolean sauver = false;
            var RegImmat = Regex.IsMatch(Item.Immatriculation, "[A-Z]{2}[-][0-9]{3}[-][A-Z]{2}");
            var RegPoid = Regex.IsMatch(Item.PoidRemorque, "[0-9]*.[0-9]*");
            if (RegImmat)
            {
                if (RegPoid)
                {
                    database.AddRemorque(Item);
                    sauver = true;
                }
                else
                {
                    Erreur = "Le poid de la remorque doit etre un chiffre";
                }
            }
            else
            {
                Erreur = "L'immatriculation doit etre de la frome 'AA-666-BB'";
            }

            return sauver;
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
