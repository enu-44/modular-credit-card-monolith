using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Transaction.Domain;

public class GuidSerializer : SerializerBase<Guid>
{
    public override Guid Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var bsonString = BsonStringSerializer.Instance.Deserialize(context);
        return Guid.Parse(bsonString.ToString());
    }

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Guid value)
    {
        var bsonDoc = BsonString.Create(value.ToString());
        BsonStringSerializer.Instance.Serialize(context, bsonDoc);
    }
}
