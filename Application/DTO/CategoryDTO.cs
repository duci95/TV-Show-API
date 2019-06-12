using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [MinLength(3,ErrorMessage ="Category name must be 3 characters or longer")]
        public string CategoryName { get; set; }
        public IEnumerable<string> Shows { get; set; }
    }
}
