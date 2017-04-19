
using PermisC.ViewModels;
using System;
using Xamarin.Forms;

namespace PermisC.Views
{
    public partial class RemorqueDetailPage : ContentPage
    {
        int i = 0;
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
    }
}
