using Application.Commands.ShowCommands;
using Application.DTO;
using Application.Searches;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.ShowCommands
{
    public class EFGetShowsWEBCommnad : EFBaseCommand, IGetShowsWEBCommand
    {
        public EFGetShowsWEBCommnad(TVShowsContext context) : base(context)
        {
        }

        public IEnumerable<ShowDTO> Execute(ShowSearch request)
        {
            var data = Context.Shows.AsQueryable();

            if (request.ShowTitle != null)
            {
                var wanted = request.ShowTitle.ToLower();
                data = data.Where(s => s.ShowTitle.ToLower().Contains(wanted) && s.Deleted == false);
            }
            if (request.OnlyActive.HasValue)
            {
                data = data.Where(s => s.Deleted != request.OnlyActive);
            }

            if (request.CategoryId.HasValue)
            {
                data = data.Where(s => s.CategoryId == request.CategoryId && s.Deleted == false);
            }
            if (request.ActorFirstName != null)
            {
                data = data.Where(asc => asc.ActorShows.Any(a => a.Actor.ActorFirstName.ToLower()
                .Contains(request.ActorFirstName.ToLower()) && asc.Deleted == false));
            }
            if (request.ActorLastName != null)
            {
                data = data.Where(asc => asc.ActorShows.Any(a => a.Actor.ActorFirstName.ToLower()
                .Contains(request.ActorLastName.ToLower()) && asc.Deleted == false));
            }

            return data.Include(d => d.ActorShows).ThenInclude(p => p.Actor).Select(s => new ShowDTO
            {
                Id = s.Id,
                ActorIds = s.ActorShows.Select(a => a.ActorId),
                CategoryId = s.CategoryId,
                ShowPicturePath = s.ShowPicturePath,
                ShowText = s.ShowText,
                ShowTitle = s.ShowTitle,
                ShowYear = s.ShowYear
            });
        }
    }
}
