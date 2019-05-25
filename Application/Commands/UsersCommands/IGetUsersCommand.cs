using Application.DTO;
using Application.Interfaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.UsersCommands
{
    public interface IGetUsersCommand : ICommand<UserSearch, IEnumerable<UserDTO>>
    {

    }
}
