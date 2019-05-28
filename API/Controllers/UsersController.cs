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
        private readonly TVShowsContext tVShowsContext;

        private IAddUserCommand _addUserCommand;
        private IGetUserCommand _getUserCommand;
        

        public UsersController(IAddUserCommand _addUserCommand, IGetUserCommand _getUserCommand)
        {
            this._addUserCommand = _addUserCommand;
            this._getUserCommand = _getUserCommand;

            

        }

        // GET: api/Users
        [HttpGet]
        public void Get([FromQuery] UserSearch query)
        {
            
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
            catch (Exception)
            {
                return NotFound("User with that id not found");
            }
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody] UserDTO request)
        {

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Gender = request.Gender,
                Password = request.Password,
                RoleId = request.RoleId,
                CityId = request.CityId,
                Token = "dfjsdofjsdojojsog",
                Username = request.Username
            };              

            try
            {
                
                _addUserCommand.Execute(request);
                return StatusCode(201, "Success");
            }
            
            catch (Exception)
            {
                return StatusCode(500, "Something is wrong but i dont know what!");
            }                          
        }

        // PUT: api/Users/5
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
