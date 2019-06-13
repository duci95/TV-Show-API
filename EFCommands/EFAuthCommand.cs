using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands
{
    public class EFAuthCommand : EFBaseCommand, IAuthCommand
    {
        public EFAuthCommand(TVShowsContext context) : base(context)
        {
        }

        public AuthDTO Execute(AuthDTO request)
        {
            var user = Context.Users
                .Include(u => u.Role)
                .Where(u => u.Username == request.Username)
                .Where(u => u.Password == request.Password)
                .FirstOrDefault();


            if (user == null)
                throw new DataNotFoundException();

            return new AuthDTO
            {
                Password = user.Password,
                Username = user.Username,
                RoleName = user.Role.RoleName
            };
        }
    }
}
