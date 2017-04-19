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
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Tracteur> Items { get; set; }
        public ObservableRangeCollection<Tracteur> Rech { get; set; }
        public Command LoadItemsCommand { get; set; }
        
        

        public ItemsViewModel()
        {
            Title = "Véhicle répértorier";
            Items = new ObservableRangeCollection<Tracteur>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Tracteur>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Tracteur;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
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
                var items = await DataStore.GetItemsAsync(true);
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