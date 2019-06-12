using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public abstract class BaseSearch 
    {       
        public bool? OnlyActive { get; set; }
        public short PerPage { get; set; } = 1;
        public short PageNumber { get; set; } = 1;
    }
}
