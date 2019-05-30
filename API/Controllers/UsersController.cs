using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.UsersCommands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Domain;
using EFDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private readonly TVShowsContext tVShowsContext;

        private IAddUserCommand _addUserCommand;
        private IGetUserCommand _getUserCommand;
        private IGetUsersCommand _getUsersCommand;
        private IEditUserCommand _editUserCommand;
        private IDeleteUserCommand _deleteUserCommand;

        public UsersController(IAddUserCommand _addUserCommand, 
                               IGetUserCommand _getUserCommand, 
                               IGetUsersCommand _getUsersCommand,
                               IEditUserCommand _editUserCommand,
                               IDeleteUserCommand _deleteUserCommand)
        {
            this._addUserCommand = _addUserCommand;
            this._getUserCommand = _getUserCommand;
            this._getUsersCommand = _getUsersCommand;
            this._editUserCommand = _editUserCommand;
            this._deleteUserCommand = _deleteUserCommand;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch query)
        {
            try
            {
                var searched = _getUsersCommand.Execute(query);
                return Ok(searched);
            }
            catch (DataNotFoundException)
            {
                return NotFound("There is no match with searched criteria");
            }
            catch (Exception)
            {
                return StatusCode(500, "Server is currently under construction, please try later");
            }
           
        }
                  
        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = _getUserCommand.Execute(id);
                return Ok(user);
            }
            catch (DataNotFoundException)
            {
                return NotFound("User with that id does not exists");
            }
            catch (Exception)
            {
                return  StatusCode(500, "Server is currently under construction, please try later");
            }
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody] UserDTO request)
        {
            try
            {  //request.id u uri stalno stvalja 0 ali u bazi je dobar
                _addUserCommand.Execute(request);
                return Created("/api/users/" + request.Id, new UserDTO
                {
                    Id = request.Id,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Gender = request.Gender,
                    RoleId = request.RoleId,
                    CityId = request.CityId,
                    Username = request.Username
                    
                    
                });
            }
            catch (DataAlreadyExistsException)
            { 
                return Conflict("Username or email alreday exists!");
            }
            catch (Exception)
            {
                return StatusCode(500, "Server is currently under construction, please try later");
            }                          
        }
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDTO request)
        {
            try
            {
                //kako !!??
                //id je uvek 0
                
                _editUserCommand.Execute(request);
                return NoContent();
            }
            catch (DataNotFoundException)
            {
                return NotFound("User with that id does not exists"); 
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message + "" + e.Data+" Server is currently under construction, please try later"); 
            }
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteUserCommand.Execute(id);
                return NoContent();
            }
            catch (DataNotFoundException)
            {
                return NotFound();                    
            }
            catch (Exception)
            {
                return StatusCode(500,"Seerver error");
            }
        }
    }
}