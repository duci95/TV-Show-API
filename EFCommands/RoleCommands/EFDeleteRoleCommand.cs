using Application.Commands.RolesCommands;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.RoleCommands
{
    public class EFDeleteRoleCommand : EFBaseCommand, IDeleteRoleCommand
    {
        public EFDeleteRoleCommand(TVShowsContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var role = Context.Roles.Find(request);

            if(role == null)
            {
                throw new DataNotFoundException();
            }

            role.Deleted = true;
            Context.SaveChanges();
        }
    }
}
