using PermisC.Data;
using PermisC.Models;

using System.Text.RegularExpressions;

using Xamarin.Forms;

namespace PermisC.ViewModels
{
    public class NewRemorqueViewModel : BaseViewModel
    {

        public Command moins { get; set; }
        public Command plus { get; set; }
        public Command save { get; set; }

        public INavigation _navigation;
        public CamionDatabase _database;
        public RemorqueViewModel _viewModel;

        public NewRemorqueViewModel(INavigation navigation, CamionDatabase database, RemorqueViewModel viewModel)
        {
            _database = database;
            _navigation = navigation;
            _viewModel = viewModel;

            moins = new Command(() => Moins());
            plus = new Command(() => Plus());
            save = new Command(() => Save());

            Item = new Remorque
            {
                Immatriculation = "",
                Essieux = "2",
            };
        }

        Remorque item;
        public Remorque Item
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
            Remorque_Metadata Meta = new Remorque_Metadata();

            Erreur = Meta.Remorque(Item, Erreur, database);

            if (Erreur == "")
            {
                _viewModel.Refresh();
                _navigation.PopAsync();
            }
        }

        public void Save()
        {
            var RegImmat = Regex.IsMatch(Item.Immatriculation, "[A-Z]{2}[-][0-9]{3}[-][A-Z]{2}");
            if (RegImmat)
            {
                int Num;
                var RegPoid = int.TryParse(Item.PoidRemorque, out Num);
                if (RegPoid)
                {

                    Remorque existant = null;
                    if ((existant = _database.GetRemorqueImmat(Item.Immatriculation)) == null)
                    {
                        _database.AddRemorque(Item);
                        _navigation.PopAsync();
                    }
                    else
                    {
                        Erreur = "Cette imatriculation a deja été enregistré";
                    }
                }
                else
                {
                    Erreur = "Le poid de la remorque doit etre un chiffre";
                }
            }
            else
            {
                Erreur = "L'immatriculation doit etre de la frome 'AA-666-BB'";
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
