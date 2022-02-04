using BusinessLogicLayer.Service.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class StudentService : IGenericService<Student>
    {
        private readonly IRepository<Student> _repositoryStudent;
        public StudentService(IRepository<Student> repositoryStudent)
        {
            _repositoryStudent = repositoryStudent;
        }
        public async Task<Student> CreateAsync(Student entityToCreate)
        {
            return await _repositoryStudent.CreateAsync(entityToCreate);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entityToDelete = await _repositoryStudent.GetByIdAsync(id);
                if (entityToDelete != null)
                {
                    await _repositoryStudent.Delete(entityToDelete);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _repositoryStudent.GetByIdAsync(id);
        }

        public async Task<Student> GetByIdFullAsync(int id)
        {
            return await _repositoryStudent.GetByIdFullAsync(id);
        }

        public async Task<IEnumerable<Student>> GetListAsync()
        {
            return await _repositoryStudent.GetAllAsync();
        }

        public async Task<bool> UpdateAsync(Student entityToUpdate)
        {
            try
            {
                await _repositoryStudent.Update(entityToUpdate);
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
    }
}
