using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PermisC.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(PermisC.Services.MockDataStore))]
namespace PermisC.Services
{
    public class MockDataStore : IDataStore<Tracteur>
    {
        bool isInitialized;
        List<Tracteur> items;

        public async Task<bool> AddItemAsync(Tracteur item)
        {
            await InitializeAsync();

            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Tracteur item)
        {
            await InitializeAsync();

            var _item = items.Where((Tracteur arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Tracteur item)
        {
            await InitializeAsync();

            var _item = items.Where((Tracteur arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Tracteur> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Tracteur>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(items);
        }

        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }


        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;

            items = new List<Tracteur>();
            var _items = new List<Tracteur>
            {
                new Tracteur { Id = Guid.NewGuid().ToString(), Immatriculation = "AA-666-BB", PoidTracteur = "1500", Essieux = "2"},
                new Tracteur { Id = Guid.NewGuid().ToString(), Immatriculation = "AB-666-BB", PoidTracteur = "3600", Essieux = "2"},
                new Tracteur { Id = Guid.NewGuid().ToString(), Immatriculation = "AB-766-BB", PoidTracteur = "17000", Essieux = "2"},
                new Tracteur { Id = Guid.NewGuid().ToString(), Immatriculation = "AB-786-BB", PoidTracteur = "23000", Essieux = "3"},
                new Tracteur { Id = Guid.NewGuid().ToString(), Immatriculation = "AB-789-BB", PoidTracteur = "32000", Essieux = "3"},
                new Tracteur { Id = Guid.NewGuid().ToString(), Immatriculation = "AB-789-CB", PoidTracteur = "41000", Essieux = "3"},
                new Tracteur { Id = Guid.NewGuid().ToString(), Immatriculation = "AB-789-CD", PoidTracteur = "45000", Essieux = "3"},
                new Tracteur { Id = Guid.NewGuid().ToString(), Immatriculation = "AB-789-CE", PoidTracteur = "68000", Essieux = "3"},
                new Tracteur { Id = Guid.NewGuid().ToString(), Immatriculation = "AB-789-CF", PoidTracteur = "80000", Essieux = "3"},
            };

            foreach (Tracteur item in _items)
            {
                items.Add(item);
            }

            isInitialized = true;
        }

        
    }
}
