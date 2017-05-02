using Xamarin.Forms;

using PermisC.ViewModels;
using PermisC.Data;

namespace PermisC.Views
{
    public partial class NewRemorquePage : ContentPage
    {
        NewRemorqueViewModel viewModel;

        public NewRemorquePage(CamionDatabase database, RemorqueViewModel _viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel = new NewRemorqueViewModel(this.Navigation, database, _viewModel);

        }
    }
}