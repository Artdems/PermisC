using System;
using System.Collections.Generic;

using Xamarin.Forms;

using PermisC.Models;
using PermisC.Views;
using PermisC.Data;

namespace PermisC.ViewModels
{
    public class ItemsViewModel :BaseViewModel
    {

        public Command LoadItemsCommand { get; set; }
        public Command RechercheItem { get; set; }
        public Command Add { get; set; }

        public INavigation _navigation;
        public CamionDatabase _database;

        //string title = string.Empty;public string Title
        //{
        //    get { return title; }
        //    set { title = value; }
        //}

        private IEnumerable<Tracteur> Tracteur;
        public IEnumerable<Tracteur> tracteur { get { return Tracteur; } set { Tracteur = value; OnPropertyChanged(); } }




        public ItemsViewModel(INavigation navigation,Boolean isConnect)
        {




            CamionDatabase database = new CamionDatabase(isConnect);

            _navigation = navigation;
            _database = database;
            _database.GetTracteursAsync(this);

            Title = "Véhicule répértorier";


            LoadItemsCommand = new Command(() => Refresh());
            RechercheItem = new Command(() => Recherche_Clicked());
            Add = new Command(() => AddItem_Clicked());

        }


        //Permet de recharger la ListView a l'aide de la base de donné
        public void Refresh()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            _database.GetTracteursAsync(this);
        }

        private string recherche = "";
        public string Recherche
        {
            get { return recherche; }
            set { recherche = value; }
        }

        //Recherche dans la base de donné toute les entré dont l'immatriculation contient la variable recherche
        void Recherche_Clicked()
        {
            tracteur = _database.GetRechTracteurs(recherche);
        }


        //Permet d'ajouté une nouvelle entré a la base de donné
        async void AddItem_Clicked()
        {
            await _navigation.PushAsync(new NewItemPage(_database, this));
        }






    }
}