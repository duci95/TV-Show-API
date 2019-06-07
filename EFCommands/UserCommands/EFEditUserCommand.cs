using Application.Commands.UsersCommands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.UserCommands
{
    public class EFEditUserCommand : EFBaseCommand, IEditUserCommand
    {
        public EFEditUserCommand(TVShowsContext context) : base(context)
        {
        }

        public void Execute(UserDTO request)
        {
            var user = Context.Users.Find(request.Id);

            if (user == null || user.Deleted == true)
            {
                throw new DataNotFoundException();
            }
            if (user.Email != request.Email)
            {
                if (Context.Users.Any(u => u.Email == request.Email))
                {
                    throw new DataAlreadyExistsException();
                }
                user.Email = request.Email;
                user.UpdatedAt = DateTime.Now;

                Context.SaveChanges();
            }
            else
            {
                throw new DataNotAlteredException();
            }


        }
    }
}
