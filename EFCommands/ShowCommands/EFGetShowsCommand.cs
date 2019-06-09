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
    public class EFGetShowsCommand : EFBaseCommand, IGetShowsCommand
    {
        public EFGetShowsCommand(TVShowsContext context) : base(context)
        {
        }

        public IEnumerable<ShowDTO> Execute(ShowSearch request)
        {
            var data = Context.Shows.AsQueryable();
            
            if(request.ShowTitle != null)
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
            if(request.ActorFirstName != null)
            {
                data = data.Where(asc => asc.ActorShows.Any(a => a.Actor.ActorFirstName.ToLower()
                .Contains(request.ActorFirstName.ToLower()) && asc.Deleted == false));                    
            }
            if(request.ActorLastName != null)
            {
                data = data.Where(asc => asc.ActorShows.Any(a => a.Actor.ActorFirstName.ToLower()
                .Contains(request.ActorLastName.ToLower()) && asc.Deleted == false));
            }

            return data.Include(sa => sa.ActorShows).ThenInclude(s => s.Actor)
                .Select(f => new ShowDTO
                {
                    Id = f.Id,
                    ShowTitle = f.ShowTitle,
                    ShowText = f.ShowText,
                    ShowPicturePath = f.ShowPicturePath,
                    CategoryId = f.Category.Id                   
                });
        }
    }
}
