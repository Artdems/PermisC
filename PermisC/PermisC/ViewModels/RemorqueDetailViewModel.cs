using PermisC.Models;

namespace PermisC.ViewModels
{
    public class RemorqueDetailViewModel : BaseViewModel
    {
        RemorqueViewModel test;
        public Remorque Item { get; set; }
        public RemorqueDetailViewModel(Remorque item = null, RemorqueViewModel Rem = null)
        {
            test = Rem;
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
            test._database.DeleteRemorque(Item.ID);
        }
    }
}