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
        public Command Add { get; set; }

        public INavigation _navigation;
        public CamionDatabase _database;

        private System.Collections.Generic.IEnumerable<PermisC.Models.Remorque> Remorque;
        public System.Collections.Generic.IEnumerable<PermisC.Models.Remorque> remorque { get { return Remorque; } set { Remorque = value; OnPropertyChanged(); } }

        public Tracteur _trac;



        public RemorqueViewModel(INavigation navigation, Tracteur trac)
        {
            CamionDatabase database = new CamionDatabase();

            _trac = trac;
            _database = database;
            _navigation = navigation;
            remorque = _database.GetRemorques();

            Title = "Remorque";

            LoadItemsCommand = new Command(async () => await Refresh());
            RechercheItem = new Command(() => Recherche_Clicked());
            Add = new Command(() => AddItem_Clicked());

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

        async void AddItem_Clicked()
        {
            await _navigation.PushAsync(new NewRemorquePage(_database));
        }
    }
}