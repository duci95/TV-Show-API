using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Link : BaseEntity
    {
        public string LinkTitle { get; set; }
        public string Path { get; set; }
        public int Parent { get; set; }

        //public ICollection<Show> Shows { get; set; }
    }
}
