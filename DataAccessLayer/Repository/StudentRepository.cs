using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository(SystemAntorcha_DBContext dbContext) : base(dbContext)
        {

        }

        public async override Task<Student> GetByIdFullAsync(int id)
        {
            var response = await _dbContext.Set<Student>().Where(x => x.Id == id).Include(x => x.Professor).FirstOrDefaultAsync();
            if (response == null)
                return null;
            return response;
        }
    }
}
