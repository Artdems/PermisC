using System;

using PermisC.Models;

using Xamarin.Forms;
using System.Text.RegularExpressions;
using PermisC.ViewModels;

namespace PermisC.Views
{
    public partial class NewRemorquePage : ContentPage
    {
        NewRemorqueViewModel viewModel;

        public NewRemorquePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new NewRemorqueViewModel();

            viewModel.Item = new Remorque
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
                await Navigation.PopAsync();
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