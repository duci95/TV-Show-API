using Application.Commands.ActorsCommands;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.ActorCommands
{
    public class EFAddActorCommand : EFBaseCommand, IAddActorCommand
    {
        public EFAddActorCommand(TVShowsContext context) : base(context)
        {
        }

        public void Execute(ActorDTO request)
        {
            if(Context.Actors.Any(a => a.ActorFirstName == request.ActorFirstName) 
                && Context.Actors.Any (a => a.ActorLastName == request.ActorLastName))
            {
                throw new DataAlreadyExistsException();
            }

            Context.Actors.Add(new Actor
            {
                ActorFirstName = request.ActorFirstName,
                ActorLastName = request.ActorLastName
            });
            Context.SaveChanges();
        }
    }
}
