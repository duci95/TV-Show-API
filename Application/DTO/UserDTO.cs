using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Application.DTO
{
    public class UserDTO 
    {
        public int Id { get; set; }
        [MaxLength(30,ErrorMessage = "Too many charachters for first name, 30 is max!")]
        [MinLength(3,ErrorMessage = "Too less charachters for first name, 3 is min!")]    
        public string FirstName { get; set; }
        [MaxLength(30, ErrorMessage = "Too many charachters for last name, 30 is max!")]
        [MinLength(3, ErrorMessage = "Too less charachters for last name, 3 is min!")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [MaxLength(20, ErrorMessage = "Too many charachters for password, 30 is max!")]
        [MinLength(8, ErrorMessage = "Too less charachters for username, 10 is min!")]
        public string Password { get; set; }
        [MaxLength(20, ErrorMessage = "Too many charachters for username, 20 is max!")]
        [MinLength(8, ErrorMessage = "Too less charachters for username, 6 is min!")]
        public string Username { get; set; }
        public char Gender { get; set; }
        

        public int RoleId { get; set; }
        public int CityId { get; set; }
    }
}
