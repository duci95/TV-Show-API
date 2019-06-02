using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public abstract class BaseSearch 
    {
        public int? Id { get; set; }
        public string Keyword { get; set; }
        public bool? OnlyActive { get; set; }
        public byte PerPage { get; set; } = 5;
        public byte PageNumber { get; set; } = 1;
    }
}
