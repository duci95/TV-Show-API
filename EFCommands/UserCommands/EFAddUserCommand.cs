using Application.Commands.UsersCommands;
using Application.DTO;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Exceptions;
using Domain;
using System.Security.Cryptography;

namespace EFCommands.UserCommands
{
    public class EFAddUserCommand : EFBaseCommand, IAddUserCommand
    {
        public EFAddUserCommand(TVShowsContext context) : base(context) { }

        public void Execute(UserDTO request)
        {
            if ((Context.Users.Any(u => u.Username == request.Username)) ||
                Context.Users.Any(e => e.Email == request.Email))
            {
                throw new DataAlreadyExists();
            }

            Context.Users.Add(new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Email = request.Email,
                //potreban token i password da se hesuje 
                Gender = request.Gender,
                RoleId = request.RoleId,
                CityId = request.CityId
                
            });

            Context.SaveChanges();

        }
    }
}