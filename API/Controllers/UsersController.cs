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
        public ActionResult Get([FromQuery] UserSearch query)                              
              =>  Ok(_getUsersCommand.Execute(query));                     
        
                  
        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
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
        public ActionResult Post(UserDTO request)
        {
            try
            {  
                _addUserCommand.Execute(request);
                return StatusCode(201, "User successfuly has been created");
            }
            catch (DataAlreadyExistsException)
            { 
                return Conflict("Username or email already exists!");
            }
            catch (Exception)
            {
                return StatusCode(500, "Server is currently under construction, please try later");
            }                          
        }
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UserDTO request)
        {
            try
            {                
                _editUserCommand.Execute(request);
                return NoContent();
            }
            catch (DataNotFoundException)
            {
                return NotFound("User with that id does not exists"); 
            }
            catch (DataAlreadyExistsException)
            {
                return Conflict("User with that email already exists");
            }
            catch (DataNotAlteredException)
            {
                return Conflict("User already have same value for email");
            }
            catch (Exception)
            {
                return StatusCode(500, "Server is currently under construction, please try later"); 
            }
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
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
                return StatusCode(500, "Server is currently under construction, please try later");
            }
        }
    }
}