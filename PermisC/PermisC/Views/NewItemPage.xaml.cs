using System;

using PermisC.Models;

using Xamarin.Forms;
using System.Text.RegularExpressions;
using PermisC.ViewModels;
using PermisC.Data;

namespace PermisC.Views
{
    public partial class NewItemPage : ContentPage
    {
        public ItemsViewModel _parent;
        public TracteurDatabase _database;
        NewItemViewModel viewModel;

        public NewItemPage(ItemsViewModel parent, TracteurDatabase database)
        {
            InitializeComponent();
            _parent = parent;
            _database = database;
            BindingContext = viewModel = new NewItemViewModel();

            viewModel.Item = new Tracteur
            {
                Immatriculation = "",
                Essieux = "2",
            };
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            Boolean sauver = viewModel.Save(_database);
            if (sauver)
            {
                await Navigation.PopToRootAsync();
                _parent.Refresh();
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