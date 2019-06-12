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

        public Pagination<UserDTO> Execute(UserSearch request)
        {
            var wanted = Context.Users.AsQueryable();

            if(request.OnlyActive.HasValue)
            {
                wanted = wanted.Where(u => u.Deleted != request.OnlyActive);
            }
            
            if (request.Username != null)
            {
                wanted = wanted
                    .Where(u => u.Username.ToLower()
                    .Contains(request.Username.ToLower()) && u.Deleted == false );
            }

            var totalCount = wanted.Count();

            wanted = wanted.Skip((request.PageNumber - 1) * request.PerPage)
                .Take(request.PerPage);

            var totalPages = (int)Math.Ceiling((double)totalCount / request.PerPage);

            var res = new Pagination<UserDTO>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PagesCount = totalPages,
                Data = wanted.Select(u => new UserDTO
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Username = u.Username,
                    CityId = u.CityId,
                    RoleId = u.RoleId,
                    Gender = u.Gender
                })
            };
            return res;          
        }
    }
}
