using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class Role
    {
        public static string Admin { get; } = "Admin";
        public static string Moderator { get; } = "Moderator";
        public static string User { get; } = "User";
    }
}
