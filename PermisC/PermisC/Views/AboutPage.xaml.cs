
using PermisC.ViewModels;

using Xamarin.Forms;

namespace PermisC.Views
{
    public partial class AboutPage : ContentPage
    {
        AboutViewModel viewModel;

        public AboutPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AboutViewModel();
        }
    }
}
