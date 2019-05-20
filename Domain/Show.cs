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
        public int ShowLike { get; set; }
        public int ShowDislike { get; set; }

        public int LinkId { get; set; }
        public Link Link { get; set; }

        public ICollection<ActorShow> ActorShows { get; set; }
        public ICollection<ShowVote> ShowVotes { get; set; }

    }
}
