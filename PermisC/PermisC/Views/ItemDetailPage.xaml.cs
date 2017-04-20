
using PermisC.ViewModels;
using System;
using Xamarin.Forms;

namespace PermisC.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;


        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}
