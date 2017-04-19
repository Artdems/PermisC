using PermisC.Models;

namespace PermisC.ViewModels
{
    public class RemorqueDetailViewModel : BaseViewModel
    {
        public Remorque Item { get; set; }
        public RemorqueDetailViewModel(Remorque item = null)
        {
            Title = item.Immatriculation;
            Item = item;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}