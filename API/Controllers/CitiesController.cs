using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.CitiesCommands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
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

    

        public CitiesController(IAddCityCommand addCityCommand, IGetCitiesCommand getCitiesCommand, IDeleteCItyCommand deleteCItyCommand, IGetCityCommand getCityCommand, IEditCityCommand editCityCommand)
        {
            _addCityCommand = addCityCommand;
            _deleteCItyCommand = deleteCItyCommand;
            _editCityCommand = editCityCommand;
            _getCitiesCommand = getCitiesCommand;
            _getCityCommand = getCityCommand;
        }
                
        // GET: api/Cities
        [HttpGet]
        public ActionResult Get([FromQuery] CitySearch criteria ) => Ok(_getCitiesCommand.Execute(criteria));
        

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(_getCityCommand.Execute(id));
            }
            catch (DataNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // POST: api/Cities
        [HttpPost]
        public ActionResult Post([FromBody] CityDTO value)
        {
            try
            {
                _addCityCommand.Execute(value);
                return StatusCode(201, "City successfuly inserted");
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
        public ActionResult Put(int id, [FromBody] CityDTO value)
        {
            try
            {
                _editCityCommand.Execute(value);
                return NoContent();
            }
            catch (DataNotFoundException)
            {
                return NotFound();
            }
            catch (DataNotAlteredException)
            {
                return Conflict();
            }
            catch (Exception)
            {
               return StatusCode(500, "Server is busy at the moment, please try later");
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteCItyCommand.Execute(id);
                return NoContent();
            }
            catch(DataNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "Server is busy at the moment, please try later");
            }
        }
    }
}
