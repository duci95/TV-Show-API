using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class CitySearch : Pagination<CityDTO>
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public bool OnlyActive { get; set; }
    }
}
