using Application.Commands.ActorsCommands;
using Application.DTO;
using Application.Searches;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.ActorCommands
{
    public class EFGetActorsCommand : EFBaseCommand, IGetActorsCommand
    {
        public EFGetActorsCommand(TVShowsContext context) : base(context)
        {
        }

        public IEnumerable<ActorDTO> Execute(ActorSearch request)
        {
            var data = Context.Actors.AsQueryable();
            if (request.OnlyActive.HasValue)
            {
                data = Context.Actors.Where(a => a.Deleted != request.OnlyActive);
            }
            if(request.ActorFirstName != null)
            {
                var keyword = request.ActorFirstName.ToLower();
                data = Context.Actors.Where(a => a.ActorFirstName.ToLower().Contains(keyword) && a.Deleted == false);
            }
            if(request.ActorLastName != null)
            {
                var keyword = request.ActorLastName.ToLower();
                data = Context.Actors.Where(a => a.ActorLastName.ToLower().Contains(keyword) && a.Deleted == false);
            }

            return data.Include(sa => sa.ActorShows)
                .ThenInclude(s => s.Show)
                .Select(s => new ActorDTO
                {
                    ActorFirstName = s.ActorFirstName,
                    ActorLastName = s.ActorLastName,
                    Shows = s.ActorShows.Select(w => w.Show.ShowTitle)
                });

        }

        
    }
}
