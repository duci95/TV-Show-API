using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Sponsor : BaseEntity
    {
        public string SponsorPicturePath { get; set; }
        public string SponsorURL { get; set; }
    }
}
