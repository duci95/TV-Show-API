using Application.Commands.ActorsCommands;
using Application.DTO;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Exceptions;

namespace EFCommands.ActorCommands
{
    public class EFEditActorCommand : EFBaseCommand, IEditActorCommand
    {
        public EFEditActorCommand(TVShowsContext context) : base(context)
        {
        }

        public void Execute(ActorDTO request)
        {
            var actor = Context.Actors.Find(request.Id);

            if (actor == null || actor.Deleted == true)
                throw new DataNotFoundException();

            if(actor.ActorFirstName != request.ActorFirstName || 
               actor.ActorLastName != request.ActorLastName)
            {
                if(Context.Actors.Any(f => f.ActorFirstName == request.ActorFirstName) &&
                   Context.Actors.Any(f => f.ActorLastName == request.ActorLastName) )
                     throw new DataAlreadyExistsException();

                actor.ActorFirstName = request.ActorFirstName;
                actor.ActorLastName = request.ActorLastName;
                actor.UpdatedAt = DateTime.Now;
                Context.SaveChanges();
            }
            else
            {
                throw new DataNotAlteredException();
            }
        }
    }
}