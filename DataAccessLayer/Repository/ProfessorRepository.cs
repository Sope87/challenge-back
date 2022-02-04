using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class ProfessorRepository: BaseRepository<Professor>
    {
        public ProfessorRepository(SystemAntorcha_DBContext dbContext) : base(dbContext)
        {

        }

        public async override Task<Professor> GetByIdFullAsync(int id)
        {
            var response = await _dbContext.Set<Professor>().Where(x=>x.Id==id).Include(x=>x.Students).FirstOrDefaultAsync() ;
            if (response == null)
                return null;
            return response;
        }
    }
}
