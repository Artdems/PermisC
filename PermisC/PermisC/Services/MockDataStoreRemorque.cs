using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PermisC.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(PermisC.Services.MockDataStoreRemorque))]
namespace PermisC.Services
{
    public class MockDataStoreRemorque : IDataStore<Remorque>
    {
        bool isInitialized;
        List<Remorque> items;

        public async Task<bool> AddItemAsync(Remorque item)
        {
            await InitializeAsync();

            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Remorque item)
        {
            await InitializeAsync();

            var _item = items.Where((Remorque arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Remorque item)
        {
            await InitializeAsync();

            var _item = items.Where((Remorque arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Remorque> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Remorque>> GetItemsAsync(bool forceRefresh = false)
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

            items = new List<Remorque>();
            var _items = new List<Remorque>
            {
                new Remorque { Id = Guid.NewGuid().ToString(), Immatriculation = "ZA-666-BB", PoidRemorque = "1500", Essieux = "2"},
                new Remorque { Id = Guid.NewGuid().ToString(), Immatriculation = "ZY-666-BB", PoidRemorque = "3600", Essieux = "2"},
                new Remorque { Id = Guid.NewGuid().ToString(), Immatriculation = "ZY-966-BB", PoidRemorque = "17000", Essieux = "2"},
                new Remorque { Id = Guid.NewGuid().ToString(), Immatriculation = "ZY-986-BB", PoidRemorque = "23000", Essieux = "3"},
                new Remorque { Id = Guid.NewGuid().ToString(), Immatriculation = "ZY-987-BB", PoidRemorque = "32000", Essieux = "3"},
                new Remorque { Id = Guid.NewGuid().ToString(), Immatriculation = "ZY-987-WB", PoidRemorque = "41000", Essieux = "3"},
                new Remorque { Id = Guid.NewGuid().ToString(), Immatriculation = "ZY-987-WX", PoidRemorque = "45000", Essieux = "3"},
                new Remorque { Id = Guid.NewGuid().ToString(), Immatriculation = "ZY-987-WV", PoidRemorque = "68000", Essieux = "3"},
                new Remorque { Id = Guid.NewGuid().ToString(), Immatriculation = "ZY-987-WS", PoidRemorque = "80000", Essieux = "3"},
            };

            foreach (Remorque item in _items)
            {
                items.Add(item);
            }

            isInitialized = true;
        }

        
    }
}
