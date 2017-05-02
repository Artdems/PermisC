using System.Collections.Generic;

using PermisC.Models;
using PermisC.Views;
using PermisC.Data;

using Xamarin.Forms;

namespace PermisC.ViewModels
{
    public class ItemsViewModel : NavigationPage
    {

        public Command LoadItemsCommand { get; set; }
        public Command RechercheItem { get; set; }
        public Command Add { get; set; }

        public INavigation _navigation;
        public CamionDatabase _database;

        private IEnumerable<Tracteur> Tracteur;
        public IEnumerable<Tracteur> tracteur { get { return Tracteur; } set { Tracteur = value; OnPropertyChanged(); } }




        public ItemsViewModel(INavigation navigation)
        {




            CamionDatabase database = new CamionDatabase();

            _navigation = navigation;
            _database = database;
            _database.GetTracteursAsync(this);

            Title = "Véhicle répértorier";


            LoadItemsCommand = new Command(() => Refresh());
            RechercheItem = new Command(() => Recherche_Clicked());
            Add = new Command(() => AddItem_Clicked());

        }

        public void Refresh()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            _database.GetTracteursAsync(this);
        }

        private string recherche = "";
        public string Recherche
        {
            get { return recherche; }
            set { recherche = value; }
        }


        void Recherche_Clicked()
        {
            tracteur = _database.GetRechTracteurs(recherche);
        }

        async void AddItem_Clicked()
        {
            await _navigation.PushAsync(new NewItemPage(_database, this));
        }








    }
}