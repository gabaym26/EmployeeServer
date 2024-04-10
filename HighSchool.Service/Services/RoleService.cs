using HighSchool.Core.Models;
using HighSchool.Core.Repositories;
using HighSchool.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchool.Service.Services
{
    public class RoleService: IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<Role> PostAsync(Role role)
        {
            return await _roleRepository.PostAsync(role);
        }
        public IEnumerable<Role> GetRoles()
        {
            return _roleRepository.GetRoles();
        }
        public Role GetById(int id)
        {
            return _roleRepository.GetById(id);
        }
        public void Delete(int id)
        {
            _roleRepository.Delete(id);
        }
    }
}
