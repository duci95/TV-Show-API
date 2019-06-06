using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.RolesCommands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private IGetRolesCommand getRolesCommand;
        private IGetRoleCommand getRoleCommand;
        private IAddRoleCommand addRoleCommand;
        private IEditRoleCommand editRoleCommand;
        private IDeleteRoleCommand deleteRoleCommand;



        public RolesController(IGetRolesCommand getRolesCommand, IGetRoleCommand getRoleCommand, IAddRoleCommand addRoleCommand, IEditRoleCommand editRoleCommand, IDeleteRoleCommand deleteRoleCommand)
        {
            this.getRolesCommand = getRolesCommand;
            this.getRoleCommand = getRoleCommand;
            this.addRoleCommand = addRoleCommand;
            this.editRoleCommand = editRoleCommand;
            this.deleteRoleCommand = deleteRoleCommand;
        }



        // GET: api/Roles
        [HttpGet]
        public IActionResult Get([FromQuery] RoleSearch criteria)
            => Ok(getRolesCommand.Execute(criteria));


        // GET: api/Roles/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(getRoleCommand.Execute(id));
        

        // POST: api/Roles
        [HttpPost]
        public IActionResult Post([FromBody] RoleDTO value)
        {
            try
            {
                addRoleCommand.Execute(value);
                return StatusCode(201, "Role successfuly inserted");
            }
            catch (DataAlreadyExistsException)
            {
                return Conflict("Role with that name already exists");
            }
            catch (Exception)
            {
                return StatusCode(500, "Server is busy at the moment, please try later");
            }
        }

        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RoleDTO value)
        {
            try
            {
                editRoleCommand.Execute(value);
                return NoContent();
            }
            catch (DataNotFoundException)
            {
                return NotFound();
            }
            catch (DataAlreadyExistsException)
            {
                return Conflict("Role with that name already exists");
            }
            catch (DataNotAlteredException)
            {
                return Conflict("Role not changed");
            }
            
            catch (Exception)
            {
                return StatusCode(500, "Server is busy at the moment, please try later");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                deleteRoleCommand.Execute(id);
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
