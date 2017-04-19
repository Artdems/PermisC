using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PermisC.Models
{
    public class Tracteur : BaseDataObject
    {
        string immatriculation;
        public string Immatriculation
        {
            get { return immatriculation; }
            set
            {
                immatriculation = value;
                OnPropertyChanged();
            }
        }

        string poidTracteur;
        public string PoidTracteur
        {
            get { return poidTracteur; }
            set
            {
                poidTracteur = value;
                OnPropertyChanged();
            }
        }

        string essieux;
        public string Essieux
        {
            get { return essieux; }
            set
            {
                essieux = value;
                OnPropertyChanged();
            }
        }
    }
}