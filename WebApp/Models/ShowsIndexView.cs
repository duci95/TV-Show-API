﻿using Application.DTO;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ShowsIndexView
    {
        public IEnumerable<ShowDTO> Shows { get; set; }
    }
}
