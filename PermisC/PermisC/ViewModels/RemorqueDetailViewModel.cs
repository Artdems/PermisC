using PermisC.Models;
using System;
using Xamarin.Forms;

namespace PermisC.ViewModels
{
    public class RemorqueDetailViewModel : BaseViewModel
    {
        RemorqueViewModel test;
        public Command delet { get; set; }
        public Command conduir { get; set; }
        public Remorque Item { get; set; }

        public INavigation _navigation;

        public RemorqueDetailViewModel(Remorque item = null, RemorqueViewModel Rem = null, INavigation navigation = null)
        {
            test = Rem;
            Title = item.Immatriculation;
            Item = item;
            delet = new Command(() => Delet());
            conduir = new Command(() => Conduire());
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }

        public void Delet()
        {
            test._database.DeleteRemorque(Item.ID);
            _navigation.PopToRootAsync();
        }

        public void Conduire()
        {

        }
    }
}