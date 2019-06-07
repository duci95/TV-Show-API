using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class ActorDTO 
    {
        public int Id { get; set; }
        public string ActorFirstName { get; set; }
        public string ActorLastName { get; set; }
        public IEnumerable<string> Shows { get; set; }
    }
}
