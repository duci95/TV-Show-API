using Application.DTO;
using Application.Interfaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.ActorsCommands
{
    public interface IGetActorsCommand : ICommand<ActorSearch, IEnumerable<ActorDTO>>
    {
    }
}
