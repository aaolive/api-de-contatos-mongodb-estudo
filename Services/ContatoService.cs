using ContatosApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace ContatosApi.Services
{

    public class ContatoService
    {
        private readonly IMongoCollection<Contato> _contatos;

        public ContatoService(IContatosDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _contatos = database.GetCollection<Contato>(settings.ContatosCollectionName);
        }

        public List<Contato> Get() =>
            _contatos.Find(contato => true).ToList();

        public Contato Get(string id) =>
            _contatos.Find<Contato>(contato => contato.Id == id).FirstOrDefault();

        public Contato Create(Contato contato)
        {
            _contatos.InsertOne(contato);
            return contato;
        }

        public void Update(string id, Contato contatoIn) =>
            _contatos.ReplaceOne(contato => contato.Id == id, contatoIn);

        public void Remove(Contato contatoIn) =>
            _contatos.DeleteOne(contato => contato.Id == contatoIn.Id);

        public void Remove(string id) => 
            _contatos.DeleteOne(contato => contato.Id == id);
    }

}