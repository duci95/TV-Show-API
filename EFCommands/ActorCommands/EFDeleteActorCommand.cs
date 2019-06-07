using Application.Commands.ActorsCommands;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.ActorCommands
{
    public class EFDeleteActorCommand : EFBaseCommand, IDeleteActorCommand
    {
        public EFDeleteActorCommand(TVShowsContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var actor = Context.Actors.Find(request);

            if(actor == null)
            {
                throw new DataNotFoundException();
            }
            actor.Deleted = true;
            Context.SaveChanges();
        }
    }
}
