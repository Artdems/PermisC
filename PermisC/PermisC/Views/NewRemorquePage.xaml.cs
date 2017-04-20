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
        public CamionDatabase _database;
        NewRemorqueViewModel viewModel;

        public NewRemorquePage(CamionDatabase database)
        {
            InitializeComponent();
            _database = database;
            BindingContext = viewModel = new NewRemorqueViewModel(this.Navigation);

            viewModel.Item = new Remorque
            {
                Immatriculation = "",
                Essieux = "2",
            };
        }
    }
}