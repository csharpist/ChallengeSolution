using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.Conrete.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        public decimal SalaryRatio { get; set; }
    }
}
