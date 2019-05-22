using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class UserDTO 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public char Gender { get; set; }
        public string Token { get; set; }

        public int RoleId { get; set; }
        public int CityId { get; set; }
    }
}
