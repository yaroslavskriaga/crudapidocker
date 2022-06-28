using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace crudapi.Models;

[BsonIgnoreExtraElements]
public class User
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string _id { get; set; }

    public User()
    {
        _id = ObjectId.GenerateNewId().ToString();
    }

    [BsonElement("name")]
    public string? Name { get; set; }

    [BsonElement("firstName")]
    public string? FirstName { get; set; }

    [BsonElement("phone")]
    public string? Phone { get; set; }

    [BsonElement("street")]
    public string? Street { get; set; }

    [BsonElement("city")]
    public string? City { get; set; }
    
    [BsonElement("postalcode")]
    public string? PostalCode { get; set; }
    
    [BsonElement("country")]
    public string? Country { get; set; }
    
    [BsonElement("birthday")]
    public string? Birthday { get; set; }
    
    [BsonElement("gender")]
    public string? Gender { get; set; }
    
    [BsonElement("nationality")]
    public string? Nationality { get; set; }
}

