using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntChallenge.ViewModels
{
    public class ProfessorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public byte? IsActive { get; set; }

        public string getNameAndLastName
        {
            get
            {
                return this.Name + ' ' + LastName;
            }
        }

        public virtual ICollection<StudentViewModel> Students { get; set; } = new List<StudentViewModel>();
    }
}
