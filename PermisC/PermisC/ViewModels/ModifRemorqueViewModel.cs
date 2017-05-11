using Xamarin.Forms;

using PermisC.Data;
using PermisC.Models;


namespace PermisC.ViewModels
{
    public class ModifRemorqueViewModel : BaseViewModel
    {
        public Command plus { get; set; }
        public Command moins { get; set; }
        public Command save { get; set; }

        public INavigation _navigation;
        RemorqueDetailViewModel _viewModel;

        Remorque sauve;


        public ModifRemorqueViewModel(INavigation navigation, CamionDatabase database, RemorqueDetailViewModel viewModel, Remorque _item)
        {
            _navigation = navigation;
            _viewModel = viewModel;

            plus = new Command(() => Plus());
            moins = new Command(() => Moins());
            save = new Command(() => Save(database));

            Item = _item;
            sauve = _item;


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


        //détruit la version précédente de l'item, vérifie que le nouvel item a bien les bonne caractéristique et le sauvgarde.
        //si le nouvelle item na pas les bonne caractéristique, c'est l'ancien qui est réstoré
        public void Save(CamionDatabase database)
        {
            Remorque_Metadata Meta = new Remorque_Metadata();

            database.DeleteRemorque(sauve);

            Erreur = Meta.Remorque(Item, Erreur, database);

            if (Erreur == "")
            {
                
                _navigation.PopAsync();
            }
            else
            {
                database.AddRemorque(sauve);
            }
        }


        //Ces deux fonction permete d'incrémenté et de décrémenté le nombre d'essieux a l'aide de bouton
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
