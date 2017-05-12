using System.ComponentModel;
using System.Runtime.CompilerServices;

using SQLite.Net.Attributes;


namespace PermisC.Models
{

    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        string mdp;
        public string MDP
        {
            get { return mdp; }
            set
            {
                mdp = value;
                OnPropertyChanged();
            }
        }

        string entreprise;
        public string Entreprise
        {
            get { return entreprise; }
            set
            {
                entreprise = value;
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