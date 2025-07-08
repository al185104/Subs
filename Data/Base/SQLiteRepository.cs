using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subs.Data.Base;

public class SQLiteRepository<T> : IRepository<T> where T : new()
{
    public readonly SQLiteAsyncConnection _database;

    public SQLiteRepository(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<T>().Wait();
    }

    public async Task<List<T>> GetAllAsync(int? skip = null, int? take = null, DateOnly? start = null, DateOnly? end = null)
    {
        // 1. Load all with children
        var allWithChildren = await _database.GetAllWithChildrenAsync<T>(recursive: true);

        // 2. Filter by DateOnly if possible
        if (start.HasValue || end.HasValue)
        {
            allWithChildren = allWithChildren
                .Where(item =>
                {
                    var createdProp = typeof(T).GetProperty("CreatedDate");
                    if (createdProp == null) return true;

                    var createdDate = (DateTime)createdProp.GetValue(item)!;
                    var itemDate = DateOnly.FromDateTime(createdDate);

                    return (!start.HasValue || itemDate >= start.Value) &&
                           (!end.HasValue || itemDate <= end.Value);
                })
                .ToList();
        }

        // 3. Apply skip and take in memory
        if (skip.HasValue)
            allWithChildren = allWithChildren.Skip(skip.Value).ToList();
        if (take.HasValue)
            allWithChildren = allWithChildren.Take(take.Value).ToList();

        return allWithChildren;
    }

    public Task<T> GetByIdAsync(Guid id)
    {
        return _database.FindAsync<T>(id);
    }

    public Task<int> InsertAsync(T entity)
    {
        return _database.InsertAsync(entity);
    }

    public Task<int> UpdateAsync(T entity)
    {
        return _database.UpdateAsync(entity);
    }

    public Task<int> DeleteAsync(T entity)
    {
        return _database.DeleteAsync(entity);
    }
}
