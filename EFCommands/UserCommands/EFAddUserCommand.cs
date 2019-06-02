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
        public EFAddUserCommand(TVShowsContext context) : base(context) {  }

        public void Execute(UserDTO request)
        {
            if (Context.Users.Any(u => u.Username == request.Username))
            {
                throw new DataAlreadyExistsException();
            }
            if(Context.Users.Any(u => u.Email == request.Email))
            {
                throw new DataAlreadyExistsException();
            }
            
            Context.Users.Add(new User{
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Gender = request.Gender,
                Password = request.Password,
                RoleId = request.RoleId,
                CityId = request.CityId,
                Token = "dfjsdofjsdojojsog",
                Username = request.Username                
            });            
            
            Context.SaveChanges();
        }
    }
}