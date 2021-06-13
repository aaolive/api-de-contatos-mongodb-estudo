using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ContatosApi.Models
{
    public class Contato
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; }

        public string Telefone { get; set; }
    }
}