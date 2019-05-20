using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Comment : BaseEntity
    {
        public string CommentText { get; set; }
        public int CommentLike { get; set; }
        public int CommentDislike { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ShowId { get; set; }
        public Show Show { get; set; }

        public ICollection<CommentVote> CommentVotes { get; set; }
    }
}
