using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class City : BaseEntity
    {
        public string CityName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
