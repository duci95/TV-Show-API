using Application.Commands.CategoriesCommands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.CategoryCommands
{
    public class EFGetCategoryCommand : EFBaseCommand, IGetCategoryCommand
    {
        public EFGetCategoryCommand(TVShowsContext context) : base(context)
        {
        }

        public CategoryDTO Execute(int request)
        {
            var data = Context.Categories.Find(request);
            if (data == null || data.Deleted == true)
                throw new DataNotFoundException();

            return new CategoryDTO
            {
                 Id = data.Id,
                 CategoryName = data.CategoryTitle                 
            };
            
        }
    }
}
