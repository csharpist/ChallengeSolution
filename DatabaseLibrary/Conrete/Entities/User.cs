using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLibrary.Abstract;

namespace DatabaseLibrary.Conrete.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal SalaryRatio { get; set; }

    }
}
