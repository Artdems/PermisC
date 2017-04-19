
using PermisC.ViewModels;
using System;
using Xamarin.Forms;

namespace PermisC.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();
        }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
        async void Vide_Clicked(object sender, EventArgs e)
        {

        }
        async void Rem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RemorquePage());
        }

        async void Delet_Clicked(object sender, EventArgs e)
        {
            this.viewModel.delet();
            await Navigation.PopToRootAsync();
        }
    }
}
