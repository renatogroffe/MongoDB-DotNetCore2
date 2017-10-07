using System.Linq;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace APICatalogo
{
    public class CatalogoContext
    {
        private IConfiguration _configuration;

        public CatalogoContext(IConfiguration config)
        {
            _configuration = config;
        }

        public T ObterItem<T>(string codigo)
        {
            MongoClient client = new MongoClient(
                _configuration.GetConnectionString("ConexaoCatalogo"));
            IMongoDatabase db = client.GetDatabase("DBCatalogo");

            var filter = Builders<T>.Filter.Eq("Codigo", codigo);

            return db.GetCollection<T>("Catalogo")
                .Find(filter).FirstOrDefault();
        }
    }
}