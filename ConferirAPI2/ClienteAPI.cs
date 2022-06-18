using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConferirAPI2
{
    public class ClienteAPI
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        [BsonElement("Nome")]
        public string? Nome { get; set; } = string.Empty;
        [BsonElement("CPF")]
        public string? CPF { get; set; } = string.Empty;
        [BsonElement("Email")]
        public string? Email { get; set; } = string.Empty;
        [BsonElement("Status")]
        public Bool? Status { get; set; } = true

        [BsonElement("Telefone")];
        public string? Telefone { get; set; } = string.Empty;
        [BsonElement("Endereco")]
        public string? Endereco { get; set; } = string.Empty;
        public object Document { get; internal set; }
    }
}
