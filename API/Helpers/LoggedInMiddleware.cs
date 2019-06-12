using Application.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class LoggedInMiddleware : Attribute, IResourceFilter
    {
        private readonly string _role;
        public LoggedInMiddleware(string role)
        {
            _role = role;
        }

        public LoggedInMiddleware()
        {

        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {

        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var user = context.HttpContext.RequestServices.GetService<LoggedUser>();

            if (!user.IsLogged)
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                if (_role != null)
                {
                    if (user.Role != _role)
                    {
                        context.Result = new UnauthorizedResult();
                    }
                }
            }
        }
    }
}
