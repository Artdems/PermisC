using System.ComponentModel;
using System.Runtime.CompilerServices;

using SQLite.Net.Attributes;



namespace PermisC.Models
{
    public class Remorque : INotifyPropertyChanged
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