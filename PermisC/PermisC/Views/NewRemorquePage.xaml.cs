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
        NewRemorqueViewModel viewModel;

        public NewRemorquePage(CamionDatabase database)
        {
            InitializeComponent();
            BindingContext = viewModel = new NewRemorqueViewModel(this.Navigation,database);

        }
    }
}