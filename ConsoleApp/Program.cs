using Domain;
using EFDataAccess;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var tv = new TVShowsContext();

            tv.Roles.Add(new Role
            {
                RoleName = "Administrator"
            });

            //tv.Users.Add(new User
            //{
            //    FirstName = "Dusan",
            //    LastName = "Krsmanvic",
            //    Email = "isjdsi@kfds.vxc",
            //    Gender = 'm',
            //    Password = "sdsfdsfdsfsd",
            //    RoleId = 1,
            //    CityId = 1,
            //    Token = "dfjsdofjsdojojsog",
            //    Username = "duanasdid"
            //});                                

            tv.SaveChanges();


        }
    }
}