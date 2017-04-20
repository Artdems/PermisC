using System;

using PermisC.Models;
using PermisC.ViewModels;

using Xamarin.Forms;

namespace PermisC.Views
{
    public partial class RemorquePage : ContentPage
    {
        RemorqueViewModel viewModel;

        public RemorquePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new RemorqueViewModel(this.Navigation);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Remorque;
            if (item == null)
                return;

            await Navigation.PushAsync(new RemorqueDetailPage(new RemorqueDetailViewModel(item,viewModel._database)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }



    }
}
