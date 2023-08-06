using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace QingSongJiZhang.Models;

public class RecordWithoutId
{
    public string Type { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;    
    public string Description { get; set; } = string.Empty;
    public double price { get; set; } = 0;
}

public class Record : RecordWithoutId
{
    [BsonId][BsonRepresentation(BsonType.ObjectId)]public string Id { get; set; } = string.Empty;

}
