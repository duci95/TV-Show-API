using Application.Commands.ShowCommands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.ShowCommands
{
    public class EFGetShowCommand : EFBaseCommand , IGetShowCommand
    {
        public EFGetShowCommand(TVShowsContext context) : base(context)
        {
        }

        public ShowDTO Execute(int request)
        {
            var one = Context.Shows.Find(request);

            if (one == null || one.Deleted)
                throw new DataNotFoundException();

            return new ShowDTO
            {
                Id = one.Id,
                CategoryId = one.CategoryId,
                ShowTitle = one.ShowTitle,
                ShowText = one.ShowText,
                ShowPicturePath = one.ShowPicturePath                
            };
        }
    }
}