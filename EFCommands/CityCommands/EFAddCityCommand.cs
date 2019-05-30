using Application.Commands.CitiesCommands;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EFCommands.UserCommands;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.CityCommands
{
    public class EFAddCityCommand : EFBaseCommand, IAddCityCommand
    {
        public EFAddCityCommand(TVShowsContext context) : base(context)
        {
        }

        public void Execute(CityDTO request)
        {
                        
            if(Context.Cities.Any(c => c.CityName == request.CityName))
            {
                throw new DataAlreadyExistsException();
            }

            Context.Cities.Add(new City {
                CityName = request.CityName
            });

            Context.SaveChanges();
        }
    }
}
