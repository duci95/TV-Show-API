using Application.DTO;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.CitiesCommands
{
    public interface IGetCityCommand : ICommand<int, CityDTO>
    {
    }
}
