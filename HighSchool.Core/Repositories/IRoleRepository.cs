using HighSchool.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchool.Core.Repositories
{
    public interface IRoleRepository
    {
        public IEnumerable<Role> GetRoles();
        public Task<Role> PostAsync(Role role);
        public Role GetById(int id);
        public void Delete(int id);

    }
}
