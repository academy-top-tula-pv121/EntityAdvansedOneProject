using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAdvansedOneProject
{
    public class User
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public UserProfile? Profile { get; set; }
        public int CompanyId { set; get; }
        public Company? Company { set; get; }
    }

    public class UserProfile
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<User> Users { set; get; } = new();
    }
}
