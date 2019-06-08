using Application.Commands.CommentsCommands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.CommentCommands
{
    public class EFGetCommentCommand : EFBaseCommand, IGetCommentCommand
    {
        public EFGetCommentCommand(TVShowsContext context) : base(context)
        {
        }

        public CommentDTO Execute(int request)
        {
            var one = Context.Comments.Find(request);
            if (one == null || one.Deleted == true)
                throw new DataNotFoundException();
            return new CommentDTO
            {
                CommentText = one.CommentText,
                ShowId = one.ShowId,
                UserId = one.UserId
            };
        }
    }
}
