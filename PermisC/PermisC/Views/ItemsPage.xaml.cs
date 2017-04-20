using System;

using PermisC.Models;
using PermisC.ViewModels;

using Xamarin.Forms;
using Android.Widget;

namespace PermisC.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel(this.Navigation);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Tracteur;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item,viewModel,this.Navigation)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }



    }
}
