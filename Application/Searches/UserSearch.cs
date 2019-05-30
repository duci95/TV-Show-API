using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class UserSearch : Pagination<UserDTO>
    {
        public int? Id { get; set; }
        public string Keyword { get; set; }
        public string Username { get; set; }
        public bool? OnlyActive { get; set; }
    }
}
