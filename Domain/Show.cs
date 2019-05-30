using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Show : BaseEntity
    {
        public string ShowTitle { get; set; }
        public string ShowText { get; set; }
        public int ShowYear { get; set; }
        public string ShowPicturePath { get; set; }        

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<ActorShow> ActorShows { get; set; }
        

    }
}
