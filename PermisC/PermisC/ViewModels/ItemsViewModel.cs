using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

using PermisC.Helpers;
using PermisC.Models;
using PermisC.Views;
using PermisC.Data;

using Xamarin.Forms;


namespace PermisC.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Tracteur> Rech { get; set; }
        public Command LoadItemsCommand { get; set; }
        public TracteurDatabase _database;
        private System.Collections.Generic.IEnumerable<PermisC.Models.Tracteur> Tracteur;
        public System.Collections.Generic.IEnumerable<PermisC.Models.Tracteur> tracteur { get { return Tracteur; } set { Tracteur = value; OnPropertyChanged(); } }




        public ItemsViewModel()
        {
            TracteurDatabase database = new TracteurDatabase();
            _database = database;
            Title = "Véhicle répértorier";
            tracteur = _database.GetTracteurs();
            //Items = new ObservableRangeCollection<Tracteur>();
            LoadItemsCommand = new Command(async () => await Refresh());


            /*MessagingCenter.Subscribe<NewItemPage, Tracteur>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Tracteur;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });*/
            
        }

        public async Task Refresh()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            tracteur = _database.GetTracteurs();

            IsBusy = false;
        }

        private string recherche = "";
        public string Recherche
        {
            get { return recherche; }
            set { recherche = value; }
        }
        

    }
}