using SQLite.Net.Attributes;

using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace PermisC.Models
{
    public class Tracteur : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

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

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}