using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class ShowDTO 
    {
        public int Id { get; set; }
        public string ShowTitle  { get; set; }
        public string ShowText { get; set; }
        public string ShowPicturePath { get; set; }
        public byte ShowYear { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<ActorDTO> Actors { get; set; }
    }
}
