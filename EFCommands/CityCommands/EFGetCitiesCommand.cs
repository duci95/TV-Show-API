using Application.Commands.CitiesCommands;
using Application.DTO;
using Application.Searches;
using EFCommands.UserCommands;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.CityCommands
{
    public class EFGetCitiesCommand : EFBaseCommand , IGetCitiesCommand
    {
        public EFGetCitiesCommand(TVShowsContext context) : base(context)
        {
        }

        public IEnumerable<CityDTO> Execute(CitySearch criteria)
        {
            var query = Context.Cities.AsQueryable();
            
            if(criteria.CityName != null)
            {
                query = query.Where(c => c.CityName.ToLower().Contains(criteria.CityName.ToLower()));
            }

            if (criteria.OnlyActive.HasValue)
            {
                query = query.Where(c => c.Deleted != criteria.OnlyActive);
            }


            return query.Include(u => u.Users).Select(c => new CityDTO
            {
                Id = c.Id,
                CityName = c.CityName,
                Users = c.Users.Select(u => u.Username)
            });
            
        }
    }
}
