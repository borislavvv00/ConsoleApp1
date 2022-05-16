using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FacultyNumber { get; set; }
        public UserRoles UserRole { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateActiveTo { get; set; }
    }
}
