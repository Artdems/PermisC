using System.Threading.Tasks;
using System.Collections.Generic;

using Xamarin.Forms;

using PermisC.Models;
using PermisC.Views;
using PermisC.Data;





namespace PermisC.ViewModels
{
    public class RemorqueViewModel : Page
    {

        public Command LoadItemsCommand { get; set; }
        public Command RechercheItem { get; set; }
        public Command Add { get; set; }

        public INavigation _navigation;
        public CamionDatabase _database;

        private IEnumerable<Remorque> Remorque;
        public IEnumerable<Remorque> remorque { get { return Remorque; } set { Remorque = value; OnPropertyChanged(); } }

        public Tracteur _trac;



        public RemorqueViewModel(INavigation navigation, Tracteur trac, CamionDatabase database)
        {

            _trac = trac;
            _database = database;
            _navigation = navigation;
            _database.GetRemorquesAsync(this);

            Title = "Remorque";

            LoadItemsCommand = new Command(async () => await Refresh());
            RechercheItem = new Command(() => Recherche_Clicked());
            Add = new Command(() => AddItem_Clicked());

        }


        //Recharge le contenue de la liste view
        public async Task Refresh()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            _database.GetRemorquesAsync(this);
        }


        private string recherche = "";
        public string Recherche
        {
            get { return recherche; }
            set { recherche = value; }
        }


        //Recherche dans la liste view toute les immatriculation contenant la variable 'recherche'
        void Recherche_Clicked()
        {
            remorque = _database.GetRechRemorque(recherche);
        }

        async void AddItem_Clicked()
        {
            if (_database.droit.Contains("admin"))
            {
                await _navigation.PushAsync(new NewRemorquePage(_database, this));
                Refresh();
            }
            else
            {
                await DisplayAlert("Attention", "vous n'avez pas les droit pour effectué cette action", "OK");
            }
            
        }
    }
}