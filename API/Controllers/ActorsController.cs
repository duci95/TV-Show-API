using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Exceptions;
using Application.Commands.ActorsCommands;
using Application.DTO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private IAddActorCommand addActorCommand;
        private IGetActorsCommand getActorsCommand;
        private IGetActorCommand getActorCommand;
        private IEditActorCommand editActorCommand;
        private IDeleteActorCommand deleteActorCommand;

        public ActorsController(IAddActorCommand addActorCommand, IGetActorsCommand getActorsCommand, IGetActorCommand getActorCommand, IEditActorCommand editActorCommand, IDeleteActorCommand deleteActorCommand)
        {
            this.addActorCommand = addActorCommand;
            this.getActorsCommand = getActorsCommand;
            this.getActorCommand = getActorCommand;
            this.editActorCommand = editActorCommand;
            this.deleteActorCommand = deleteActorCommand;
        }


        // GET: api/Actors
        [HttpGet]
        public ActionResult Get([FromQuery] ActorSearch criteria)
            => Ok(getActorsCommand.Execute(criteria));


        // GET: api/Actors/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(getActorCommand.Execute(id));
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

        // POST: api/Actors
        [HttpPost]
        public ActionResult Post([FromBody] ActorDTO value)
        {
            try
            {
                addActorCommand.Execute(value);
                return StatusCode(201);
            }
            catch (DataAlreadyExistsException)
            {
                return Conflict();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        // PUT: api/Actors/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ActorDTO value)
        {
            try
            {
                editActorCommand.Execute(value);
                return NoContent();
            }
            catch (DataNotFoundException)
            {
                return NotFound();
            }
            catch (DataNotAlteredException)
            {
                return Conflict("Data not altered");
            }
            catch (DataAlreadyExistsException)
            {
                return Conflict();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                deleteActorCommand.Execute(id);
                return NoContent();
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
    }
}
