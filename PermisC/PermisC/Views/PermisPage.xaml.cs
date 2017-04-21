using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PermisC.ViewModels;
using PermisC.Models;

namespace PermisC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PermisPage : ContentPage
    {
        Permis viewModel;
        public PermisPage(Tracteur trac)
        {
            InitializeComponent();

            BindingContext = viewModel = new Permis(trac);
        }

        public PermisPage(Tracteur trac, Remorque rem)
        {
            InitializeComponent();

            BindingContext = viewModel = new Permis(trac,rem);
        }
    }
}
