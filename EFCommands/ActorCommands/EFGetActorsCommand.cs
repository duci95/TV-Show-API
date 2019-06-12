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

        public Pagination<ActorDTO> Execute(ActorSearch request)
        {
            var data = Context.Actors.AsQueryable();
            if (request.OnlyActive.HasValue)
            {
                data = data.Where(a => a.Deleted != request.OnlyActive);
            }
            if(request.ActorFirstName != null)
            {
                var keyword = request.ActorFirstName.ToLower();
                data = data.Where(a => a.ActorFirstName.ToLower().Contains(keyword) && a.Deleted == false);
            }
            if(request.ActorLastName != null)
            {
                var keyword = request.ActorLastName.ToLower();
                data = data.Where(a => a.ActorLastName.ToLower().Contains(keyword) && a.Deleted == false);
            }

            var totalCount = data.Count();

            data = data.Skip((request.PageNumber - 1) * request.PerPage)
                .Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new Pagination<ActorDTO>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = data.Select(a => new ActorDTO
                {
                    Id = a.Id,
                    ActorFirstName = a.ActorFirstName,
                    ActorLastName = a.ActorLastName,
                    Shows = a.ActorShows.Select(s => s.Show.ShowTitle)
                })
            };

        }

        
    }
}
