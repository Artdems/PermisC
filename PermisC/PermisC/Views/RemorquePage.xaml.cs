using System;

using PermisC.Models;
using PermisC.ViewModels;

using Xamarin.Forms;

namespace PermisC.Views
{
    public partial class RemorquePage : ContentPage
    {
        RemorqueViewModel viewModel;

        public RemorquePage(Tracteur trac)
        {
            InitializeComponent();

            BindingContext = viewModel = new RemorqueViewModel(this.Navigation,trac);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Remorque;
            if (item == null)
                return;

            await Navigation.PushAsync(new RemorqueDetailPage(new RemorqueDetailViewModel(item, viewModel,this.Navigation,viewModel._trac)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }



    }
}
