using Application.Commands.CategoriesCommands;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.CategoryCommands
{
    public class EFDeleteCategoryCommand : EFBaseCommand, IDeleteCategoryCommand
    {
        public EFDeleteCategoryCommand(TVShowsContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var one = Context.Categories.Find(request);

            if (one == null || one.Deleted == true)
                throw new DataNotFoundException();

            one.Deleted = true;
            Context.SaveChanges();
        }
    }
}
