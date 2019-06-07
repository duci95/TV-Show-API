using Application.Commands.CategoriesCommands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.CategoryCommands
{
    public class EFEditCategoryCommand : EFBaseCommand, IEditCategoryCommand
    {
        public EFEditCategoryCommand(TVShowsContext context) : base(context)
        {
        }

        public void Execute(CategoryDTO request)
        {
            var cat = Context.Categories.Find(request.Id);
            if (cat == null || cat.Deleted == true)
                throw new DataNotFoundException();
            if (cat.CategoryTitle != request.CategoryName )
            {
                if (Context.Categories.Any(c => c.CategoryTitle == request.CategoryName && c.Deleted == false ))
                    throw new DataAlreadyExistsException();

                cat.CategoryTitle = request.CategoryName;
                cat.UpdatedAt = DateTime.Now;
                Context.SaveChanges();
            }
            else
                throw new DataNotAlteredException();
        }
    }
}
