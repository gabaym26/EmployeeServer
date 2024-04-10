using HighSchool.Core.Models;
using HighSchool.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchool.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetemployeesAsync()
        {
            return await _context.Employees.Include(e => e.Roles).ThenInclude(r => r.Role).ToListAsync();
        }

        public Employee GetById(int id)
        {/*Include(e => e.Roles).ThenInclude(r => r.Role).FirstOrDefault(e => e.Id == id);*/
            return _context.Employees.Include(e => e.Roles).ThenInclude(r => r.Role).FirstOrDefault(e => e.Id == id);
        }

        public async Task<Employee> PostAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task<Employee> PutAsync(int id, Employee employee)
        {
            Employee existemployee = GetById(id);
            if (existemployee != null)
            {
                existemployee.FirstName = employee.FirstName;
                existemployee.Identity = employee.Identity;
                existemployee.LastName = employee.LastName;
                existemployee.BirthDate = employee.BirthDate;
                existemployee.DateStartJob = employee.DateStartJob;
                existemployee.Sex = employee.Sex;
                existemployee.IsActive = employee.IsActive;

                var arrExistRoles = existemployee.Roles.ToArray();
                var arrNewRoles = employee.Roles.ToArray();
                int i = 0;
                while (i!=arrExistRoles.Length&&i!= arrNewRoles.Length)
                {
                    PutRole(arrExistRoles[i].Id, arrNewRoles[i]);
                    i++;
                }
                if (arrExistRoles.Length> arrNewRoles.Length)
                {
                    while (i != arrExistRoles.Length)
                    {
                        DeleteRole(arrExistRoles[i]);
                        i++;
                    }
                }
                else if (arrExistRoles.Length < arrNewRoles.Length)
                {
                    while (i != arrNewRoles.Length)
                    {
                        existemployee.Roles.Add(arrNewRoles[i]);
                        i++;
                    }
                }
            }
            await _context.SaveChangesAsync();
            return await _context.Employees.Include(e => e.Roles).ThenInclude(r => r.Role).FirstOrDefaultAsync(e => e.Id == id);
        }
        public void Delete(int id)
        {
            var employee = GetById(id);
            employee.IsActive = false;
            _context.SaveChanges();
        }
        public void DeleteRole(RoleEmployee r)
        {
            _context.RolesEmployees.Remove(r);
            _context.SaveChanges();
        }
        public RoleEmployee GetRoleById(int id)
        {
            return _context.RolesEmployees.Find(id);
        }
        public RoleEmployee PutRole(int id, RoleEmployee roleEmployee)
        {
            var existRoleEmployee = GetRoleById(id);
            if (existRoleEmployee != null)
            {
                existRoleEmployee.RoleId = roleEmployee.RoleId;
                existRoleEmployee.StartDate = roleEmployee.StartDate;
                existRoleEmployee.IsAdministrative = roleEmployee.IsAdministrative;
            }
            _context.SaveChanges();
            return existRoleEmployee;
        }
    }
}
