using Application.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class InsertShow
    {
        public int Id { get; set; }
        public string ShowTitle { get; set; }
        public string ShowText { get; set; }
        public IFormFile ShowPicturePath { get; set; }
        public int ShowYear { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<int> ActorIds { get; set; }
    }
}
