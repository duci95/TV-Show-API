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

        public Pagination<CommentDTO> Execute(CommentSearch request)
        {
            var data = Context.Comments.AsQueryable();

            if(request.CommentText != null)
            {
                var wanted = request.CommentText.ToLower();
                data = data.Where(c => c.CommentText.ToLower().Contains(wanted) &&
                 c.Deleted == false);               
                
            }
            if (request.OnlyActive.HasValue)
            {
                data = data.Where(c => c.Deleted != request.OnlyActive);
            }

            var totalCount = data.Count();

            data = data.Skip((request.PerPage - 1) * request.PageNumber).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double) totalCount / request.PerPage);

            var res = new Pagination<CommentDTO>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = data.Select(c => new CommentDTO
                {
                    CommentText = c.CommentText,
                    ShowId = c.Show.Id,
                    UserId = c.UserId
                })
            };
            return res;
        }
    }
}