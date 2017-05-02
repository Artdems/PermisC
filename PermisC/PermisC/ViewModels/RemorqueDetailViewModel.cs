using PermisC.Data;
using PermisC.Models;
using PermisC.Views;

using Xamarin.Forms;

namespace PermisC.ViewModels
{
    public class RemorqueDetailViewModel : BaseViewModel
    {
        public CamionDatabase _database;
        public INavigation _navigation;
        public RemorqueViewModel _viewModel;
        public Tracteur _trac;

        public Command delet { get; set; }
        public Command conduir { get; set; }
        public Remorque Item { get; set; }

        public RemorqueDetailViewModel(Remorque item = null, RemorqueViewModel viewModel = null, INavigation navigation = null, Tracteur trac = null)
        {
            _trac = trac;
            _database = viewModel._database;
            _viewModel = viewModel;
            _navigation = navigation;

            Title = item.Immatriculation;
            Item = item;

            delet = new Command(() => Delet());
            conduir = new Command(() => Conduire());
        }

        public void Delet()
        {
            _database.DeleteRemorque(Item);
            _viewModel.Refresh();
            _navigation.PopToRootAsync();
        }

        public void Conduire()
        {
            _navigation.PushAsync(new PermisPage(_trac, Item));
        }
    }
}