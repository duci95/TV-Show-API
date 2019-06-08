using Application.Commands.CommentsCommands;
using Application.DTO;
using Application.Searches;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.CommentCommands
{
    public class EFGetCommentsCommand : EFBaseCommand, IGetCommentsCommand
    {
        public EFGetCommentsCommand(TVShowsContext context) : base(context)
        {
        }

        public IEnumerable<CommentDTO> Execute(CommentSearch request)
        {
            var data = Context.Comments.AsQueryable();

            if(request.CommentText != null)
            {
                var wanted = request.CommentText.ToLower();
                data = Context.Comments.Where(c => c.CommentText.ToLower().Contains(wanted) &&
                 c.Deleted == false);               
                
            }
            if (request.OnlyActive.HasValue)
            {
                data = Context.Comments.Where(c => c.Deleted != request.OnlyActive);
            }
            return data.Select(c => new CommentDTO
            {
                CommentText = c.CommentText,
                ShowId = c.Show.Id,
                UserId = c.UserId
            });
        }
    }
}