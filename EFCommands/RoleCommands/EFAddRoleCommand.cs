using Application.Commands.RolesCommands;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.RoleCommands
{
    public class EFAddRoleCommand : EFBaseCommand, IAddRoleCommand
    {
        public EFAddRoleCommand(TVShowsContext context) : base(context)
        {
        }

        public void Execute(RoleDTO request)
        {
            if (Context.Roles.Any(r => r.RoleName == request.RoleName))
                throw new DataAlreadyExistsException();

            Context.Roles.Add(new Role
            {
                RoleName = request.RoleName
            });
            Context.SaveChanges();
        }
    }
}
