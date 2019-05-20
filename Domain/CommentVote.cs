using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CommentVote
    {
        public int UserId { get; set; }
        public int CommentId { get; set; }

        public User User { get; set; }
        public Comment Comment { get; set; }
    }
}
