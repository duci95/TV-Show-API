using Application.Commands.CategoriesCommands;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.CategoryCommands
{

    public class EFAddCategoryCommand : EFBaseCommand, IAddCategoryCommand
    {
        public EFAddCategoryCommand(TVShowsContext context) : base(context)
        {
        }

        public void Execute(CategoryDTO request)
        {
            if (Context.Categories.Any(c => c.CategoryTitle == request.CategoryName))
                throw new DataAlreadyExistsException();

            Context.Categories.Add(new Category
            {
                CategoryTitle = request.CategoryName                
            });
            Context.SaveChanges();
        }
    }
}
