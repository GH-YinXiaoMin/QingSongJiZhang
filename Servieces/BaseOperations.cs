using MongoDB.Driver;
using QingSongJiZhang.Models;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;

namespace QingSongJiZhang.Servieces;

public class BaseOperations<T>
{
    private readonly IMongoCollection<T> _baseOperation;
    public BaseOperations(IOptions<DataBaseAttribute> config,string CollectionName)
    {
        var mongoClient = new MongoClient(
        config.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            config.Value.DatabaseName);

        _baseOperation = mongoDatabase.GetCollection<T>(CollectionName);
    }

    public async Task<List<T>> RetrieveAllAsync()
    {
        return await _baseOperation.Find(_ => true).ToListAsync();
    }

    public async Task<T> RetrieveOneAsync(Expression<Func<T,bool>>filter)
    {
        return await _baseOperation.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<bool> CreatOneAsync(T t)
    {
        try
        {
            await _baseOperation.InsertOneAsync(t);     
            return true;
        }
        catch (Exception)
        {
            return false;
            throw;
        }
    }

    public async Task<bool> UpdateOneAsync(FilterDefinition<T> filter,UpdateDefinition<T> update)
    {
        try
        {
            await _baseOperation.UpdateOneAsync(filter, update);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
        
    }

    public async Task<bool> DeleteOneAsync(FilterDefinition<T> filter)
    {
        try
        {
            await _baseOperation.DeleteOneAsync(filter);
            return true;
        }
        catch (Exception)
        {
            return false;
            throw;
        }
    }

}
