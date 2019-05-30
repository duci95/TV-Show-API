using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Category : BaseEntity
    {
        public string CategoryTitle { get; set; }               

        public ICollection<Show> Shows { get; set; }
    }
}
