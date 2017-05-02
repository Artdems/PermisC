using PermisC.Models;
using PermisC.ViewModels;
using PermisC.Data;

using Xamarin.Forms;

namespace PermisC.Views
{
    public partial class RemorquePage : ContentPage
    {
        RemorqueViewModel viewModel;

        public RemorquePage(Tracteur trac, CamionDatabase database)
        {
            InitializeComponent();

            BindingContext = viewModel = new RemorqueViewModel(this.Navigation, trac, database);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Remorque;
            if (item == null)
                return;

            await Navigation.PushAsync(new RemorqueDetailPage(new RemorqueDetailViewModel(item, viewModel, this.Navigation, viewModel._trac)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }



    }
}
