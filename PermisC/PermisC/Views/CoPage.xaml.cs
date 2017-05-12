using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PermisC.ViewModels;
using PermisC.Data;

namespace PermisC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoPage : ContentPage
    {
        CoViewModel viewModel;

        public CoPage(CamionDatabase _database)
        {
            InitializeComponent();

            BindingContext = viewModel = new CoViewModel(_database, this.Navigation);
        }
    }
}
