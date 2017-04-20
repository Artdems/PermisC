using PermisC.Data;
using PermisC.Models;
using PermisC.Views;
using System;
using Xamarin.Forms;

namespace PermisC.ViewModels
{
    public class ItemDetailViewModel : NavigationPage
    {
        public CamionDatabase _database;
        public Tracteur Item { get; set; }

        public Command vide { get; set; }
        public Command delet { get; set; }
        public Command remorque { get; set; }

        public INavigation _navigation;

        public ItemDetailViewModel(Tracteur item = null, CamionDatabase database,INavigation navigation = null )
        {
            _navigation = navigation;
            _database = database;

            Title = item.Immatriculation;
            Item = item;
            vide = new Command(() => Vide_Clicked());
            delet = new Command(() => Delet());
            remorque = new Command(() => RemorquePage());
        }

        public async void Delet()
        {
            _database.DeleteTracteur(Item.ID);
            await Navigation.PopToRootAsync();
        }

        void Vide_Clicked()
        {

        }

        public async void RemorquePage()
        {
            await _navigation.PushAsync(new RemorquePage());
        }
    }
}