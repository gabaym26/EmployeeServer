using HighSchool.Core.Models;

namespace HighSchool.API.Models
{
    public class EmployeePostModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identity { get; set; }
        public DateTime DateStartJob { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex{ get; set; }
        public bool IsActive { get; set; } = true;
        public List<RoleEmployeePostModel> Roles { get; set; }
    }
}
