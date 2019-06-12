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

        public Pagination<ShowDTO> Execute(ShowSearch request)
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

            var totalCount = data.Count();

            data = data.Include(sa => sa.ActorShows).ThenInclude(s => s.Actor)
                .Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var totalPages = (int)Math.Ceiling((double)totalCount/request.PerPage);

            var res = new Pagination<ShowDTO>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PagesCount = totalPages,
                Data = data.Select(s => new ShowDTO
                {
                    Id = s.Id,
                    ActorIds = s.ActorShows.Select(a => a.ActorId),
                    CategoryId = s.CategoryId,
                    ShowPicturePath = s.ShowPicturePath,
                    ShowText = s.ShowText,
                    ShowTitle = s.ShowTitle,
                    ShowYear = s.ShowYear
                })
            };

            return res;
        }
    }
}
