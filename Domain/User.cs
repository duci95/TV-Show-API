using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
namespace Domain
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
        public char Gender { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<Comment> Comments { get; set; }    
    }
}
