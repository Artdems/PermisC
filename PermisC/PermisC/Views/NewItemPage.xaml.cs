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
        NewItemViewModel viewModel;

        public NewItemPage(CamionDatabase database)
        {
            InitializeComponent();
            BindingContext = viewModel = new NewItemViewModel(this.Navigation,database);

            
        }
    }
}