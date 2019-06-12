using Application.Commands.ShowCommands;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.ShowCommands
{
    public class EFDeleteShowCommand : EFBaseCommand, IDeleteShowCommand
    {
        public EFDeleteShowCommand(TVShowsContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var one = Context.Shows.Find(request);

            if(one == null || one.Deleted)
            {
                throw new DataNotFoundException();
            }
            one.Deleted = true;
            one.UpdatedAt = DateTime.Now;

            Context.SaveChanges();
        }

        
    }
}
