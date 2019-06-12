using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class Pagination<T> 
    {
        public int PagesCount { get; set; }
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
