using HighSchool.Core.Models;
using HighSchool.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchool.Core.Services
{
    public interface IEmployeeService
    {
        public Task<Employee> PostAsync(Employee employee);
        public void Delete(int id);
        public Task<IEnumerable<Employee>> GetemployeesAsync();
        public  Employee GetById(int id);

        public Task<Employee> PutAsync(int id, Employee employee);

    }
}
