using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ShowVote
    {
        public int ShowId { get; set; }
        public int UserId { get; set; }

        public Show Show { get; set; }
        public User User { get; set; }
    }
}
