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
    public class RemorqueViewModel : BaseViewModel
    {

        public Command LoadItemsCommand { get; set; }
        public Command RechercheItem { get; set; }

        public CamionDatabase _database;
        private System.Collections.Generic.IEnumerable<PermisC.Models.Remorque> Remorque;
        public System.Collections.Generic.IEnumerable<PermisC.Models.Remorque> remorque { get { return Remorque; } set { Remorque = value; OnPropertyChanged(); } }



        public RemorqueViewModel()
        {
            CamionDatabase database = new CamionDatabase();
            Title = "Remorque";
            _database = database;
            remorque = _database.GetRemorques();
            //Items = new ObservableRangeCollection<Remorque>();
            LoadItemsCommand = new Command(async () => await Refresh());
            RechercheItem = new Command(() => Recherche_Clicked());

            /*MessagingCenter.Subscribe<NewItemPage, Remorque>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Remorque;
                Items.Add(_item);
                await DataStoreRem.AddItemAsync(_item);
            });*/

        }

        public async Task Refresh()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            remorque = _database.GetRemorques();
            IsBusy = false;
        }
        private string recherche = "";
        public string Recherche
        {
            get { return recherche; }
            set { recherche = value; }
        }
        void Recherche_Clicked()
        {
            remorque = _database.GetRechRemorque(recherche);
        }
    }
}