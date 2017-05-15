using PermisC.Models;
using PermisC.ViewModels;
using System;
using Xamarin.Forms;

namespace PermisC.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage(Boolean isConnect)
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel(this.Navigation,isConnect);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Tracteur;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item, viewModel, this.Navigation)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        private void Entry_ChildAdded(object sender, ElementEventArgs e)
        {

        }
    }
}
