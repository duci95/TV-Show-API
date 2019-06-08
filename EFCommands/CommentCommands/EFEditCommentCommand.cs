using Application.Commands.CommentsCommands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.CommentCommands
{
    public class EFEditCommentCommand : EFBaseCommand, IEditCommentCommand
    {
        public EFEditCommentCommand(TVShowsContext context) : base(context)
        {
        }

        public void Execute(CommentDTO request)
        {
            var one = Context.Comments.Find(request.Id);
            if (one == null || one.Deleted == true)
                throw new DataNotFoundException();
            if (one.CommentText != request.CommentText)
            {
                one.CommentText = request.CommentText;
                one.UpdatedAt = DateTime.Now;
                Context.SaveChanges();
            }
            else
                throw new DataNotAlteredException();
        }
    }
}
