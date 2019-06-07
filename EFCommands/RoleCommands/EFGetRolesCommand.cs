using Application.Commands.RolesCommands;
using Application.DTO;
using Application.Searches;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EFCommands.RoleCommands
{
    public class EFGetRolesCommand : EFBaseCommand, IGetRolesCommand
    {
        public EFGetRolesCommand(TVShowsContext context) : base(context)
        {
        }

        public IEnumerable<RoleDTO> Execute(RoleSearch request)
        {
            var data = Context.Roles.AsQueryable();
                        
            if(request.RoleName != null )
            {
                var name = request.RoleName;
                data = Context.Roles.Where(r => r.RoleName.ToLower().Contains(name) && r.Deleted == false);
            }
            
            if (request.OnlyActive.HasValue)
            {
                data = Context.Roles.Where(r => r.Deleted != request.OnlyActive);
            }

            return data.Include(u => u.Users).Select(d => new RoleDTO
            {
                Id = d.Id,
                RoleName = d.RoleName,
                Users = d.Users.Select(u => u.Username)
            });

        }
    }
}