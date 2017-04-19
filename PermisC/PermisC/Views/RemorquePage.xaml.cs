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

            BindingContext = viewModel = new RemorqueViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Remorque;
            if (item == null)
                return;

            await Navigation.PushAsync(new RemorqueDetailPage(new RemorqueDetailViewModel(item,viewModel)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewRemorquePage(viewModel,viewModel._database));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.LoadItemsCommand.Execute(null);
        }

        void Recherche_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(viewModel.Recherche);
        }



    }
}
