using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public int ShowId { get; set; }
        public int UserId { get; set; }
    }
}
