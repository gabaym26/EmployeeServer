using HighSchool.Core.Models;
using HighSchool.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchool.Core.Services
{
    public interface IRoleService
    {
        public Task<Role> PostAsync(Role role);
        public IEnumerable<Role> GetRoles();
        public Role GetById(int id);
        public void Delete(int id);

    }
}
