using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class RoleDTO 
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public string RoleName { get; set; }
        public IEnumerable<string> Users { get; set; }
    }
}
