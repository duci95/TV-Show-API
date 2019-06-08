using Application.Commands.CommentsCommands;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.CommentCommands
{
    public class EFDeleteCommentCommand : EFBaseCommand, IDeleteCommentCommand
    {
        public EFDeleteCommentCommand(TVShowsContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var one = Context.Comments.Find(request);
            if (one == null || one.Deleted)
                throw new DataNotFoundException();
            one.Deleted = true;
            Context.SaveChanges();
        }
    }
}
