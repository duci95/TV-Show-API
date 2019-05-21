using Domain;
using EFDataAccess;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var item = new TVShowsContext();

            item.Roles.Add(new Role
            {
                RoleName = "admin"
            });
            item.SaveChanges();
        }
    }
}
