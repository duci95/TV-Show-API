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
    public class EFEditRoleCommand : EFBaseCommand, IEditRoleCommand
    {
        public EFEditRoleCommand(TVShowsContext context) : base(context)
        {
        }

        public void Execute(RoleDTO request)
        {
            var data = Context.Roles.Find(request.Id);

            if (data == null)
                throw new DataNotFoundException();

            if (data.RoleName != request.RoleName)
            {
                if (Context.Roles.Any(r => r.RoleName == request.RoleName))
                    throw new DataAlreadyExistsException();

                data.RoleName = request.RoleName;
                data.UpdatedAt = DateTime.Now;
                Context.SaveChanges();
            }
            else
                throw new DataNotAlteredException();
        }
    }
}
