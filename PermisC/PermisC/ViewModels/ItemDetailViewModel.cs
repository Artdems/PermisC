using PermisC.Models;

namespace PermisC.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        ItemsViewModel test;
        public Tracteur Item { get; set; }
        public ItemDetailViewModel(Tracteur item = null, ItemsViewModel Trac = null )
        {
            test = Trac;
            Title = item.Immatriculation;
            Item = item;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }

        public void delet()
        {
            test._database.DeleteTracteur(Item.ID);
        }
    }
}