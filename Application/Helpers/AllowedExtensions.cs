using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Helpers
{
    public class AllowedExtensions
    {
        public static IEnumerable<string> Extensions => new List<string> {".gif", ".png", ".jpg", ".jpeg" };
    }
}
