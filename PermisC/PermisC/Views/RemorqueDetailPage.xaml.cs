
using PermisC.ViewModels;
using System;
using Xamarin.Forms;

namespace PermisC.Views
{
    public partial class RemorqueDetailPage : ContentPage
    {
        
        RemorqueDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public RemorqueDetailPage()
        {
            InitializeComponent();
        }

        public RemorqueDetailPage(RemorqueDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
        async void Conduire_Clicked(object sender, EventArgs e)
        {
        }

        async void Delet_Clicked(object sender, EventArgs e)
        {
            this.viewModel.delet();
            await Navigation.PopToRootAsync();
        }
    }
}
