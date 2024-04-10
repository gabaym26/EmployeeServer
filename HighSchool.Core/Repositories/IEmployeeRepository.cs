using HighSchool.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchool.Core.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetemployeesAsync();
        public  Employee GetById(int id);
        public  Task<Employee> PostAsync(Employee employee);
        public  Task<Employee> PutAsync(int id, Employee employee);
        public void Delete(int id);
    }
}
