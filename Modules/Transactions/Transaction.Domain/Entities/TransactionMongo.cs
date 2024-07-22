using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Transaction.Domain;

public class TransactionMongo
{
    [BsonId]
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("cardNumber")]
    public string CardNumber { get; set; }

    [BsonElement("type")]
    public string Type { get; set; }

    [BsonElement("description")]
    public string Description { get; set; }

    [BsonElement("amount")]
    public double Amount { get; set; }

    [BsonElement("date")]
    public DateTime Date { get; set; }
}
