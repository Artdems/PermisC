using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

using PermisC.Helpers;
using PermisC.Models;
using PermisC.Views;

using Xamarin.Forms;


namespace PermisC.ViewModels
{
    public class RemorqueViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Remorque> Items { get; set; }
        public ObservableRangeCollection<Remorque> Rech { get; set; }
        public Command LoadItemsCommand { get; set; }



        public RemorqueViewModel()
        {
            Title = "Remorque";
            Items = new ObservableRangeCollection<Remorque>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Remorque>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Remorque;
                Items.Add(_item);
                await DataStoreRem.AddItemAsync(_item);
            });

        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStoreRem.GetItemsAsync(true);
                Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
        private string recherche = "";
        public string Recherche
        {
            get { return recherche; }
            set { recherche = value; }
        }
    }
}