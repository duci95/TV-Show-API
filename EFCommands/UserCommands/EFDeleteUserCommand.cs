using Application.Commands.UsersCommands;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.UserCommands
{
    public class EFDeleteUserCommand : EFBaseCommand, IDeleteUserCommand
    {
        public EFDeleteUserCommand(TVShowsContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var user = Context.Users.Find(request);

            if(user.Deleted == true)
            {
                throw new DataNotFoundException();
            }

            user.Deleted = true;

            Context.SaveChanges();

        }
    }
}
