using PermisC.Helpers;
using PermisC.Models;
using PermisC.Services;

using Xamarin.Forms;

namespace PermisC.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        /// <summary>
        /// Get the azure service instance
        /// </summary>
        public IDataStore<Tracteur> DataStore => DependencyService.Get<IDataStore<Tracteur>>();
        public IDataStore<Remorque> DataStoreRem => DependencyService.Get<IDataStore<Remorque>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        /// <summary>
        /// Private backing field to hold the title
        /// </summary>
        string title = string.Empty;
        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}

