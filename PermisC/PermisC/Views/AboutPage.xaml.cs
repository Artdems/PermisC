
using NUnit.Framework;
using PermisC.ViewModels;
using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace PermisC.Views
{
    public partial class AboutPage : ContentPage
    {
        AboutViewModel viewModel;

        public AboutPage()
        {
            InitializeComponent();
            BindingContext =  viewModel = new AboutViewModel();
        }

        public AboutPage(AboutViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        void Valider_Clicked(object sender, EventArgs e)
        {
            viewModel.Verif();
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
