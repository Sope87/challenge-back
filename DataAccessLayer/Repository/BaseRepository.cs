using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Repository.Interfaces;

namespace DataAccessLayer.Repository
{

    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected SystemAntorcha_DBContext _dbContext;
        public BaseRepository(SystemAntorcha_DBContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public virtual async Task<T> CreateAsync(T _object)
        {
            var obj = await _dbContext.Set<T>().AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public virtual async Task<bool> Delete(T _object)
        {
            _dbContext.Set<T>().Remove(_object);
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
          
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Set<T>().ToListAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public virtual async Task<T> GetByIdAsync(int Id)
        {
            
            return await _dbContext.Set<T>().FindAsync(Id);
        }

        public virtual async Task<bool> Update(T _object)
        {
            _dbContext.Set<T>().Update(_object);
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        
        public virtual  Task<T> GetByIdFullAsync(int id)
        {
            throw new NotImplementedException();
        }
    }

}
