using Application.Commands.RolesCommands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.RoleCommands
{
    public class EFGetRoleCommand : EFBaseCommand, IGetRoleCommand
    {
        public EFGetRoleCommand(TVShowsContext context) : base(context)
        {
        }

        public RoleDTO Execute(int request)
        {
            var data = Context.Roles.Find(request);

            if(data == null)
            {
                throw new DataNotFoundException();
            }
            if(data.Deleted == true)
            {
                throw new DataNotFoundException();
            }

            return new RoleDTO
            {
                Id = data.Id,
                RoleName = data.RoleName                            
            };
        }
    }
}
