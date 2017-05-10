using PermisC.Data;
using PermisC.Models;
using PermisC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PermisC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModifRemorquePage : ContentPage
    {
        ModifRemorqueViewModel viewModel;

        public ModifRemorquePage(CamionDatabase database, RemorqueDetailViewModel _viewModel, Remorque item)
        {
            InitializeComponent();
            BindingContext = viewModel = new ModifRemorqueViewModel(this.Navigation, database, _viewModel, item);


        }
    }
}
