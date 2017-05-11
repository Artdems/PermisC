using Xamarin.Forms;

using PermisC.Data;
using PermisC.Models;
using PermisC._meta;


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

        //Verifi les entré de l'utilisateur et sauvgarde l'items dans la base de donné si les entré sont correcte
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
