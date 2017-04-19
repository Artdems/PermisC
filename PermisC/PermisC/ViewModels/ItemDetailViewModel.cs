using PermisC.Models;

namespace PermisC.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Tracteur Item { get; set; }
        public ItemDetailViewModel(Tracteur item = null)
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