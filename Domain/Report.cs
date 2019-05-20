using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Report : BaseEntity
    {
        public string Activity { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
