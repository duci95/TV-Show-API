using Application.Commands.UsersCommands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.UserCommands
{
    public class EFGetUserCommand : EFBaseCommand, IGetUserCommand
    {
        public EFGetUserCommand(TVShowsContext context) : base(context)
        {

        }
        public UserDTO Execute(int request)
        {
            var user = Context.Users.Find(request);

            if (user == null)
                throw new DataNotFoundException();

            return new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username,
                CityId = user.CityId,
                RoleId = user.RoleId,
                Gender = user.Gender                                
            };
        }
    }
}