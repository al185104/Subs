using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subs.Data.Base;

public interface IRepository<T> where T : new()
{
    Task<List<T>> GetAllAsync(int? skip = null, int? take = null, DateOnly? start = null, DateOnly? end = null);
    Task<T> GetByIdAsync(Guid id);
    Task<int> InsertAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(T entity);
}
