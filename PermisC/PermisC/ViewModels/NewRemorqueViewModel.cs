using System.Text.RegularExpressions;

using Xamarin.Forms;

using PermisC.Data;
using PermisC.Models;


namespace PermisC.ViewModels
{
    public class NewRemorqueViewModel : BaseViewModel
    {

        public Command moins { get; set; }
        public Command plus { get; set; }
        public Command save { get; set; }

        public INavigation _navigation;
        public CamionDatabase _database;
        public RemorqueViewModel _viewModel;

        public NewRemorqueViewModel(INavigation navigation, CamionDatabase database, RemorqueViewModel viewModel)
        {
            _database = database;
            _navigation = navigation;
            _viewModel = viewModel;

            moins = new Command(() => Moins());
            plus = new Command(() => Plus());
            save = new Command(() => Save(database));

            Item = new Remorque
            {
                Immatriculation = "",
                Essieux = "2",
            };
        }

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


        //Permet de vérifié si les valeur rentré par l'utilisateur son correcte et d'enregistré l'entré dans la base de donné si les valeur sont correcte.
        public void Save(CamionDatabase database)
        {
            Remorque_Metadata Meta = new Remorque_Metadata();

            Erreur = Meta.Remorque(Item, Erreur, database);

            if (Erreur == "")
            {
                _viewModel.Refresh();
                _navigation.PopAsync();
            }
        }

        //Ces deux fonction permet l'incrémentation du nombre d'essieux a l'aide de bouton
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
