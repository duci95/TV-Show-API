using Application.Commands.CitiesCommands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.CityCommands
{
    public class EFEditCityCommand : EFBaseCommand, IEditCityCommand
    {
        public EFEditCityCommand(TVShowsContext context) : base(context)
        {
        }

        public void Execute(CityDTO request)
        {
            var city = Context.Cities.Find(request);

            if(city == null)
            {
                throw new DataNotFoundException();
            }
            
            if(city.CityName != request.CityName)
            {
                if (Context.Cities.Any(c => c.CityName == request.CityName))
                {
                    throw new DataAlreadyExistsException();
                }

                city.CityName = request.CityName;
                Context.SaveChanges();
            }
            else
            {
                throw new DataNotAlteredException();
            }
        }
    }
}
