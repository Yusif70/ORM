using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateOnly HireDate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int? ReportedEmployeeId { get; set; }
        public Employee ReportedEmployee { get; set; }
    }
}