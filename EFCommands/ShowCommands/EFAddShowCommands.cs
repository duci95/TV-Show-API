using Application.Commands.ShowCommands;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EFCommands.ShowCommands
{
    public class EFAddShowCommands : EFBaseCommand, IAddShowCommand
    {
        public EFAddShowCommands(TVShowsContext context) : base(context)
        {
        }

        public void Execute(ShowDTO request)
        {
            if (Context.Shows.Any(t => t.ShowTitle == request.ShowTitle))
                throw new DataAlreadyExistsException();

            var show = new Show
            {
                ShowPicturePath = request.ShowPicturePath,
                ShowText = request.ShowText,
                ShowTitle = request.ShowTitle,
                ShowYear = request.ShowYear,
                CategoryId = request.CategoryId                
            };


            //var relationships = request.ActorIds.Select(id => new ActorShow
            //{
            //    ActorId = id,
            //    ShowId = show.Id
            //});

            //show.ActorShows = relationships.ToList();

            Context.Shows.Add(show);
            Context.SaveChanges();

            //kako ubaciti i glumce
            //edit serije
            //delete serije
        }
    }
}