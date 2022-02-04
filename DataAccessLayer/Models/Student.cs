using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public byte? IsActive { get; set; }
        public int? ProfessorId { get; set; }

        public virtual Professor Professor { get; set; }
    }
}
