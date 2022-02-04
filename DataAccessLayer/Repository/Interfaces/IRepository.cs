using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Interfaces
{
    public interface IRepository<T>
    {
        public Task<T> CreateAsync(T _object);

        public Task<bool> Update(T _object);

        public Task<IEnumerable<T>> GetAllAsync();

        public Task<T> GetByIdAsync(int Id);

        public Task<bool> Delete(T _object);

        public Task<T> GetByIdFullAsync(int id);

    }
}
