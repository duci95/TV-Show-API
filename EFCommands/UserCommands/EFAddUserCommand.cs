using Application.Commands.UsersCommands;
using Application.DTO;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Exceptions;
using Domain;
using System.Security.Cryptography;
using Application.Interfaces;

namespace EFCommands.UserCommands
{
    public class EFAddUserCommand : EFBaseCommand, IAddUserCommand
    {
        private IEmailSender emailSender;

        public EFAddUserCommand(TVShowsContext context, IEmailSender emailSender) : base(context)
        {
            this.emailSender = emailSender;
        }             

        public void Execute(UserDTO request)
        {
            if (Context.Users.Any(u => u.Username == request.Username))
            {
                throw new DataAlreadyExistsException();
            }
            if(Context.Users.Any(u => u.Email == request.Email))
            {
                throw new DataAlreadyExistsException();
            }
            
            Context.Users.Add(new User{
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Gender = request.Gender,
                Password = request.Password,
                RoleId = request.RoleId,
                CityId = request.CityId,
                Token = "dfjsdofjsdojojsog",
                Username = request.Username                
            });            
            
            Context.SaveChanges();

            var email = request.Email;

            emailSender.Subject = "TV Shows API";
            emailSender.Body = "You have successfuly registered";
            emailSender.ToEmail = email;
            emailSender.Send();
        }
    }
}