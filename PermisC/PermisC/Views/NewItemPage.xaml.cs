using System;

using PermisC.Models;

using Xamarin.Forms;
using System.Text.RegularExpressions;
using PermisC.ViewModels;

namespace PermisC.Views
{
    public partial class NewItemPage : ContentPage
    {
        NewItemViewModel viewModel;

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new NewItemViewModel();

            viewModel.Item = new Tracteur
            {
                Immatriculation = "",
                Essieux = "2",
            };
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            Boolean sauver = viewModel.Save();
            if (sauver)
            {
                await Navigation.PopToRootAsync();
            }
        }
        void Moins_Clicked(object sender, EventArgs e)
        {
            viewModel.Moins();

        }
        void Plus_Clicked(object sender, EventArgs e)
        {
            viewModel.Plus();

        }
    }
}