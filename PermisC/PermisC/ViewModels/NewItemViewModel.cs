using PermisC.Data;
using PermisC.Models;
using PermisC._meta;

using Xamarin.Forms;

namespace PermisC.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        public Command plus { get; set; }
        public Command moins { get; set; }
        public Command save { get; set; }

        public INavigation _navigation;
        ItemsViewModel _viewModel;


        public NewItemViewModel(INavigation navigation, CamionDatabase database, ItemsViewModel viewModel)
        {
            _navigation = navigation;
            _viewModel = viewModel;

            plus = new Command(() => Plus());
            moins = new Command(() => Moins());
            save = new Command(() => Save(database));

            Item = new Tracteur
            {
                Immatriculation = "",
                Essieux = "2",
            };
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
            Tracteur_Metadata Meta = new Tracteur_Metadata();

            Erreur = Meta.Tracteur(Item, Erreur, database);

            if (Erreur == "")
            {
                _viewModel.Refresh();
                _navigation.PopAsync();
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
