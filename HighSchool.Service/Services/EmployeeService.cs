using HighSchool.Core.Models;
using HighSchool.Core.Repositories;
using HighSchool.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HighSchool.Service.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> PostAsync(Employee employee)
        {
            return await _employeeRepository.PostAsync(employee);
        }

        public void Delete(int id)
        {
           _employeeRepository.Delete(id);
        }

        public async Task<IEnumerable<Employee>> GetemployeesAsync()
        {
            return await _employeeRepository.GetemployeesAsync();
        }

        public  Employee GetById(int id)
        {
            return  _employeeRepository.GetById(id);
        }

        public async Task<Employee> PutAsync(int id, Employee employee)
        {
            return await _employeeRepository.PutAsync(id, employee);
        }

       
    }
}
