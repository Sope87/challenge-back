using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntChallenge.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public byte? IsActive { get; set; }
        public int? ProfessorId { get; set; }
        public string getNameAndLastName
        {

            get
            {
                return this.Name + ' ' + this.LastName;
            }
        }
        public  Professor Professor { get; set; }
        
    }
}
