using PermisC.Data;
using PermisC.Models;
using PermisC.Views;

using Xamarin.Forms;

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

        public void Delet()
        {
            _database.DeleteTracteur(Item);
            _viewModel.Refresh();
            _navigation.PopToRootAsync();
        }

        void Vide_Clicked()
        {
            _navigation.PushAsync(new PermisPage(Item));
        }

        public async void RemorquePage()
        {
            await _navigation.PushAsync(new RemorquePage(Item, _database));
        }

        public async void ModifPage()
        {
            await _navigation.PushAsync(new ModifItemPage(_database, this, Item));
        }
    }
}