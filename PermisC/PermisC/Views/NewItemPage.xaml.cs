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
        public CamionDatabase _database;
        NewItemViewModel viewModel;

        public NewItemPage(CamionDatabase database)
        {
            InitializeComponent();
            _database = database;
            BindingContext = viewModel = new NewItemViewModel(this.Navigation);

            viewModel.Item = new Tracteur
            {
                Immatriculation = "",
                Essieux = "2",
            };
        }
    }
}