﻿using Application.DTO;
using Application.Interfaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.CommentsCommands
{
    public interface IGetCommentsCommand : ICommand<CommentSearch, IEnumerable<CommentDTO>>
    {
    }
}
