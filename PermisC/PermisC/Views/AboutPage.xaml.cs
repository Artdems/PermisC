
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
    }
}
