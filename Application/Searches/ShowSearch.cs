using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class ShowSearch : BaseSearch
    {
        public int? CategoryId { get; set; }
        public string ShowTitle { get; set; }
        public string ActorFirstName { get; set; }
        public string ActorLastName { get; set; }
    }
}
