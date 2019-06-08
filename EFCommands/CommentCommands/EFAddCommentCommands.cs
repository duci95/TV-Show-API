using Application.Commands.CommentsCommands;
using Application.DTO;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.CommentCommands
{
    public class EFAddCommentCommands : EFBaseCommand, IAddCommentCommand
    {
        public EFAddCommentCommands(TVShowsContext context) : base(context)
        {
        }

        public void Execute(CommentDTO request)
        {
            Context.Comments.Add(new Comment
            {
                CommentText = request.CommentText,
                ShowId = request.ShowId,
                UserId = request.UserId
            });
            Context.SaveChanges();
        }
    }
}
