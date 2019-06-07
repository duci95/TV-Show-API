using Application.Commands.ActorsCommands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.ActorCommands
{
    public class EFGetActorCommand : EFBaseCommand, IGetActorCommand
    {
        public EFGetActorCommand(TVShowsContext context) : base(context)
        {
        }

        public ActorDTO Execute(int request)
        {
            var actor = Context.Actors.Find(request);
            
            if(actor == null)
            {
                throw new DataNotFoundException();
            }
            if(actor.Deleted == true)
            {
                throw new DataNotFoundException();
            }
            return new ActorDTO
            {
                ActorFirstName = actor.ActorFirstName,
                ActorLastName = actor.ActorLastName
            };
            
        }
    }
}
