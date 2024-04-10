using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchool.Core.Models
{   
    public enum Sex
    {
        Male=1,
        Female
    }
    public class Employee
    {       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public string Identity { get; set; }
        public DateTime DateStartJob { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex{ get; set; }
        public bool IsActive { get; set; }
        public List<RoleEmployee> Roles{ get; set; }
    }
}
