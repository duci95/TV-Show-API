using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.CitiesCommands;
using Application.DTO;
using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private IAddCityCommand _addCityCommand;
        private IDeleteCItyCommand _deleteCItyCommand;
        private IEditCityCommand _editCityCommand;
        private IGetCitiesCommand _getCitiesCommand;
        private IGetCityCommand _getCityCommand;

        public CitiesController(IAddCityCommand addCityCommand, IDeleteCItyCommand deleteCItyCommand, IEditCityCommand editCityCommand, IGetCitiesCommand getCitiesCommand, IGetCityCommand getCityCommand)
        {
            _addCityCommand = addCityCommand;
            _deleteCItyCommand = deleteCItyCommand;
            _editCityCommand = editCityCommand;
            _getCitiesCommand = getCitiesCommand;
            _getCityCommand = getCityCommand;
        }




        // GET: api/Cities
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cities/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cities
        [HttpPost]
        public IActionResult Post([FromBody] CityDTO value)
        {
            try
            {
                _addCityCommand.Execute(value);
                return Created("/api/cities/" + value.Id, new CityDTO
                {
                    Id = value.Id,
                    CityName = value.CityName
                });
            }
            catch (DataAlreadyExistsException)
            {
                return Conflict("City with that name already exists");
            }
            catch (Exception)
            {
                return StatusCode(500, "Server is busy at the moment, please try later");
            }
        }

        // PUT: api/Cities/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
