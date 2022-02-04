using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Models
{
    public partial class Professor
    {
        public Professor()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public byte? IsActive { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
