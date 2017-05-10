using Xamarin.Forms;

using PermisC.ViewModels;
using PermisC.Data;
using PermisC.Models;

namespace PermisC.Views
{
    public partial class ModifItemPage : ContentPage
    {
        ModifItemViewModel viewModel;

        public ModifItemPage(CamionDatabase database, ItemDetailViewModel _viewModel,Tracteur item)
        {
            InitializeComponent();
            BindingContext = viewModel = new ModifItemViewModel(this.Navigation, database, _viewModel,item);


        }
    }
}