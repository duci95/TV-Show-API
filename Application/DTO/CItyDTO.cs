using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class CityDTO 
    {
        public int Id { get; set; }
        [Required (ErrorMessage="This field is required")]
        [MinLength(3,ErrorMessage="Name of city cannot be shorter than 3")]
        [MaxLength(30,ErrorMessage="Name of city cannot be longer than 30")]
        public string CityName { get; set; }
    }
}
