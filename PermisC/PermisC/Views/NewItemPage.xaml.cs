using Xamarin.Forms;

using PermisC.ViewModels;
using PermisC.Data;

namespace PermisC.Views
{
    public partial class NewItemPage : ContentPage
    {
        NewItemViewModel viewModel;

        public NewItemPage(CamionDatabase database, ItemsViewModel _viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel = new NewItemViewModel(this.Navigation, database, _viewModel);


        }
    }
}