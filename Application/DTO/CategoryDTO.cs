using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<string> Shows { get; set; }
    }
}
