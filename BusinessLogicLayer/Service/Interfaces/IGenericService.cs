using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service.Interfaces
{
    public interface IGenericService<T>
    {
        Task<T> CreateAsync(T entityToCreate);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdFullAsync(int id);
        Task<bool> UpdateAsync(T entityToUpdate);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<T>> GetListAsync();
        
    }
}
