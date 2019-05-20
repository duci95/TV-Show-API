using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ActorShow
    {
        public int ActorId { get; set; }
        public int ShowId { get; set; }

        public Actor Actor { get; set; }
        public Show Show { get; set; }
    }
}
