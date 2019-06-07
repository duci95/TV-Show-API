using Application.Commands.CategoriesCommands;
using Application.DTO;
using Application.Searches;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.CategoryCommands
{
    public class EFGetCategoriesCommand : EFBaseCommand, IGetCategoriesCommand
    {
        public EFGetCategoriesCommand(TVShowsContext context) : base(context)
        {
        }

        public IEnumerable<CategoryDTO> Execute(CategorySearch request)
        {
            var data = Context.Categories.AsQueryable();

            if(request.CategoryName != null)
            {
                var wanted = request.CategoryName;
                data = Context.Categories.Where(c => c.CategoryTitle.Contains(wanted) && c.Deleted == false );
            }
            if (request.OnlyActive.HasValue)
            {
                data = Context.Categories.Where(c => c.Deleted != request.OnlyActive);
            }

            return data.Include(shows => shows.Shows).Select(s => new CategoryDTO
            {
                Id = s.Id,
                CategoryName = s.CategoryTitle,
                Shows = s.Shows.Select(t => t.ShowTitle)
            });

        }
    }
}
