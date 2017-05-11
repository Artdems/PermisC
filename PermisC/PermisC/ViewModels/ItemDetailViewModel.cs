using Xamarin.Forms;

using PermisC.Data;
using PermisC.Models;
using PermisC.Views;


namespace PermisC.ViewModels
{
    public class ItemDetailViewModel : NavigationPage
    {

        public Tracteur Item { get; set; }


        public Command vide { get; set; }
        public Command delet { get; set; }
        public Command remorque { get; set; }
        public Command modif { get; set; }

        public CamionDatabase _database;
        public INavigation _navigation;
        public ItemsViewModel _viewModel;

        public ItemDetailViewModel(Tracteur item = null, ItemsViewModel viewModel = null, INavigation navigation = null)
        {
            _navigation = navigation;
            _database = viewModel._database;
            _viewModel = viewModel;

            Title = item.Immatriculation;
            Item = item;
            vide = new Command(() => Vide_Clicked());
            delet = new Command(() => Delet());
            remorque = new Command(() => RemorquePage());
            modif = new Command(() => ModifPage());
        }


        //Permet de supprimé l'entré séléctionné et de renvoyer a a listeview
        public void Delet()
        {
            _database.DeleteTracteur(Item);
            _viewModel.Refresh();
            _navigation.PopToRootAsync();
        }


        //Permet de voir les condition requise pour conduire se tracteur sans remorque
        void Vide_Clicked()
        {
            _navigation.PushAsync(new PermisPage(Item));
        }


        //Permet de choisir un remorque a ajouter avec le tracteur
        public async void RemorquePage()
        {
            await _navigation.PushAsync(new RemorquePage(Item, _database));
        }


        //Permet de modifié l'entré de la base séléctionné
        public async void ModifPage()
        {
            await _navigation.PushAsync(new ModifItemPage(_database, this, Item));
        }
    }
}