using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Actor : BaseEntity
    {
        public string ActorFirstName { get; set; }
        public string ActorLastName { get; set; }

        public ICollection<ActorShow> ActorShows { get; set; }
    }
}
