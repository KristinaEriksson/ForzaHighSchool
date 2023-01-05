using System;
using System.Collections.Generic;

namespace ForzaHighSchool.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Grades = new HashSet<Grade>();
        }

        public int EmploymentNumber { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string SocialSecurityNumber { get; set; } = null!;
        public string Title { get; set; } = null!;
        public decimal Salary { get; set; }
        public DateTime EmploymentDate { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
