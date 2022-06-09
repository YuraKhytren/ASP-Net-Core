using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9ASPNetCore.Domain.Interfaces
{
    public interface IRepository<T>
    {
       Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task SaveAsync(T model);
        Task DeleteAsync(int id);
    }
}
