using crudapi.Data;
using crudapi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace crudapi.Services;

public class UserService
{
    private readonly IMongoCollection<User> _users;

    public UserService(IOptions<UsersDatabaseSettings> options)
    {
        var mongoClient = new MongoClient(options.Value.ConnectionString);
        var database = mongoClient.GetDatabase(options.Value.DatabaseName);
        _users = database.GetCollection<User>(options.Value.CollectionName);
    }

    // Gets all users
    public async Task<List<User>> Get()
    {
        Console.WriteLine();
        return await _users.Find(u => true).ToListAsync();
    }

    // Get a single user
    public async Task<User> Get(string id)
    {
        return await _users.Find(s => s._id == id).FirstOrDefaultAsync();
    }

    public async Task<User> Create(User u)
    {
        await _users.InsertOneAsync(u);
        return u;
    }

    public async Task<User> Update(string id, User u)
    {
        await _users.ReplaceOneAsync(user => user._id == id, u);
        return u;
        
    }

    public async Task Delete(string id)
    {
        await _users.DeleteOneAsync(su => su._id == id);
    }
}