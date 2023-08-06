using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace QingSongJiZhang.Models;

public class RecordWithoutId
{
    public string SpecificType { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; } 
    public double Price { get; set; }

    public RecordWithoutId()
    {
        SpecificType = string.Empty;
        Name = string.Empty;
        Description = string.Empty;
        Price = 0;
    }
}

public class Record : RecordWithoutId
{
    [BsonId] public ObjectId Id { get; set; }

    public Record(string specificType,string name, string description, double price)
    {
        SpecificType = specificType;
        Name = name;
        Description = description;
        Price= price;
        Id = ObjectId.GenerateNewId();
    }
    public Record(RecordWithoutId newRecord)
    {
        SpecificType=newRecord.SpecificType;
        Name = newRecord.Name;
        Description = newRecord.Description;
        Price = newRecord.Price;
        Id = ObjectId.GenerateNewId();
    }
}
