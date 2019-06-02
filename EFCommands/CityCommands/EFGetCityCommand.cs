using Application.Commands.CitiesCommands;
using Application.DTO;
using Application.Exceptions;
using Application.Interfaces;
using EFCommands;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.CityCommands
{
    public class EFGetCityCommand : EFBaseCommand, IGetCityCommand
    {
        public EFGetCityCommand(TVShowsContext context) : base(context)
        {
        }

        public CityDTO Execute(int request)
        {
            var city = Context.Cities.Find(request);

            if(city == null)
            {
                throw new DataNotFoundException();
            }
            if(city.Deleted == true)
            {
                throw new DataNotFoundException();
            }
            return new CityDTO
            {
                Id = city.Id,
                CityName = city.CityName                
            };
        }
    }
}
