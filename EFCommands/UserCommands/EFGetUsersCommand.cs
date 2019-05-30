using Application.Commands.UsersCommands;
using Application.DTO;
using Application.Searches;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EFCommands.UserCommands
{
    public class EFGetUsersCommand : EFBaseCommand, IGetUsersCommand
    {
        public EFGetUsersCommand(TVShowsContext context) : base(context)
        {
        }

        public IEnumerable<UserDTO> Execute(UserSearch request)
        {
            var wanted = Context.Users.AsQueryable();

            if(request.OnlyActive.HasValue)
            {
                wanted = wanted.Where(u => u.Deleted != request.OnlyActive);
            }
            //samo keyword nece da radi
            //Object reference not set to an instance of an object
            if (request.Keyword != null)
            {
                wanted = wanted
                    .Where(u => u.Username.ToLower()
                    .Contains(request.Username.ToLower()));
            }
            if (request.Id.HasValue)
            {
                wanted = wanted.Where(u => u.Id.Equals(request.Id));
            }

            return wanted.Select(u => new UserDTO
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Username = u.Username,
                CityId = u.CityId,
                RoleId = u.RoleId,
                Gender = u.Gender                
            });
        }
    }
}

 
