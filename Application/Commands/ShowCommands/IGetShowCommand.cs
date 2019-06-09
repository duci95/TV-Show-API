using System;
using System.Collections.Generic;
using System.Text;
using Application.DTO;
using Application.Interfaces;
namespace Application.Commands.ShowCommands
{
    public interface IGetShowCommand : ICommand<int, ShowDTO>
    {
    }
}
