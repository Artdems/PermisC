using System;

using PermisC.Models;

using Xamarin.Forms;
using System.Text.RegularExpressions;
using PermisC.ViewModels;
using PermisC.Data;

namespace PermisC.Views
{
    public partial class NewRemorquePage : ContentPage
    {
        public RemorqueViewModel _parent;
        public CamionDatabase _database;
        NewRemorqueViewModel viewModel;

        public NewRemorquePage(RemorqueViewModel parent, CamionDatabase database)
        {
            InitializeComponent();
            _parent = parent;
            _database = database;
            BindingContext = viewModel = new NewRemorqueViewModel();

            viewModel.Item = new Remorque
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
                await Navigation.PopAsync();
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