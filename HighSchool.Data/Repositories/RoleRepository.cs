using HighSchool.Core.Models;
using HighSchool.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchool.Data.Repositories
{
    public class RoleRepository: IRoleRepository
    {
        private readonly DataContext _context;

        public RoleRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Role> GetRoles()
        {
            return _context.Roles;
        }
        public Role GetById(int id)
        {
            return  _context.Roles.Find(id);
        }
        public async Task<Role> PostAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role;
        }
        public void Delete(int id)
        {
            var role = GetById(id);
            _context.Roles?.Remove(role);
            _context.SaveChanges();
        }
    }
}
