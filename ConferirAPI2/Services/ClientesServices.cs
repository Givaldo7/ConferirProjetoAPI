using ConferirAPI2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ConferirAPI2.Services
{
    public class ClientesServices
    {
        private readonly IMongoCollection<ClienteAPI> _ProdutoCollection;

        public ClientesServices(IOptions<ProdutoDatabaseSettings> clienteServices)
        {

            var mongoclient = new MongoClient(clienteServices.Value.ConnectionString);
            var mongoDatabase = mongoclient.GetDatabase(clienteServices.Value.DatabaseName);

            _ProdutoCollection = mongoDatabase.GetCollection<ClienteAPI>
                (clienteServices.Value.ProdutoCollectionName);
        }

        public async Task<List<ClienteAPI>> GetAsync() =>
            await _ProdutoCollection.Find(x => true).ToListAsync();

        public async Task<ClienteAPI> GetAsync(string id) =>
            await _ProdutoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(ClienteAPI clientes) =>
            await _ProdutoCollection.InsertOneAsync(clientes);

        public async Task UpdateAsync(string id, ClienteAPI clientes) =>
            await _ProdutoCollection.ReplaceOneAsync(x => x.Id == id, clientes);

        public async Task RemoveAsync(string id) =>
            await _ProdutoCollection.DeleteOneAsync(x => x.Id == id);






    }
}
