using Xamarin.Forms;

using PermisC.Data;
using PermisC.Models;
using PermisC._meta;


namespace PermisC.ViewModels
{
    public class ModifItemViewModel : BaseViewModel
    {
        public Command plus { get; set; }
        public Command moins { get; set; }
        public Command save { get; set; }

        public INavigation _navigation;
        ItemDetailViewModel _viewModel;

        Tracteur sauve;


        public ModifItemViewModel(INavigation navigation, CamionDatabase database, ItemDetailViewModel viewModel,Tracteur _item)
        {
            _navigation = navigation;
            _viewModel = viewModel;

            plus = new Command(() => Plus());
            moins = new Command(() => Moins());
            save = new Command(() => Save(database));

            Item = _item;
            sauve = _item;


           
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

        //détruit la version précédente de l'item, vérifie que le nouvel item a bien les bonne caractéristique et le sauvgarde.
        //si le nouvelle item na pas les bonne caractéristique, c'est l'ancien qui est réstoré
        public void Save(CamionDatabase database)
        {
            _Metadata Meta = new _Metadata();

            database.DeleteTracteur(sauve);
            Erreur = Meta.meta(Erreur, database, null, Item);

            if (Erreur == "")
            {
                _navigation.PopAsync();
            }
            else
            {
                database.AddTracteur(sauve);
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
