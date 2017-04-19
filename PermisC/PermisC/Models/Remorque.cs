using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PermisC.Models
{
    public class Remorque : BaseDataObject
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

        string poidRemorque;
        public string PoidRemorque
        {
            get { return poidRemorque; }
            set
            {
                poidRemorque = value;
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