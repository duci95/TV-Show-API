using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.CitiesCommands;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.CityCommands
{
    public class EFDeleteCityCommand : EFBaseCommand, IDeleteCItyCommand
    {
        public EFDeleteCityCommand(TVShowsContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var city = Context.Cities.Find(request);

            if (city == null)
            {
                throw new DataNotFoundException();
            }
            city.Deleted = true;
            Context.SaveChanges();
        }
    }
}
