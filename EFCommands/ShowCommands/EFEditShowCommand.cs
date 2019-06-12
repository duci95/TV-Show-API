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
    public class EFEditShowCommand : EFBaseCommand, IEditShowCommand
    {
        public EFEditShowCommand(TVShowsContext context) : base(context)
        {
        }

        public void Execute(ShowDTO request)
        {
            var one = Context.Shows.Find(request.Id);

            if (one == null || one.Deleted)
                throw new DataNotFoundException();

            if(one.ShowPicturePath != request.ShowPicturePath)
            {
                one.ShowPicturePath = request.ShowPicturePath;
                one.UpdatedAt = DateTime.Now;
            }
            if(one.ShowTitle != request.ShowTitle)
            {
                if (Context.Shows.Any(s => s.ShowTitle == request.ShowTitle))
                    throw new DataAlreadyExistsException();
                one.ShowTitle = request.ShowTitle;
                one.UpdatedAt = DateTime.Now;
            }
            if (one.ShowYear != request.ShowYear)
            {
                one.ShowYear = request.ShowYear;
                one.UpdatedAt = DateTime.Now;
            }
            if(one.ShowText != request.ShowText)
            {
                one.ShowText = request.ShowText;
                one.UpdatedAt = DateTime.Now;
            }
            else            
                throw new DataNotAlteredException();              
        }
    }
}
