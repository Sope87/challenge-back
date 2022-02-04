using BusinessLogicLayer.Service.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Service
{
    public class ProfessorService : IGenericService<Professor>
    {
        private readonly IRepository<Professor> _repositoryProfessor;
        public ProfessorService(IRepository<Professor> repositoryProfessor)
        {
            _repositoryProfessor = repositoryProfessor;
        }
        public async Task<Professor> CreateAsync(Professor entityToCreate)
        {
            return await _repositoryProfessor.CreateAsync(entityToCreate);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entityToDelete= await _repositoryProfessor.GetByIdAsync(id);
                if (entityToDelete != null)
                {
                    await _repositoryProfessor.Delete(entityToDelete);
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

        public async Task<Professor> GetByIdAsync(int id)
        {
            return await _repositoryProfessor.GetByIdAsync(id);
        }

        public async Task<Professor> GetByIdFullAsync(int id)
        {
            return await _repositoryProfessor.GetByIdFullAsync(id);

        }

        public async Task<IEnumerable<Professor>> GetListAsync()
        {
            return await _repositoryProfessor.GetAllAsync();
        }

        public  async Task<bool> UpdateAsync(Professor entityToUpdate)
        {
            try
            {
                await _repositoryProfessor.Update(entityToUpdate);
                return true;
            }
            catch (Exception ex)
            {
                return false;
              
            }
        }
    }
}
