using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Application.Commands.ShowCommands;
using Application.DTO;
using Application.Helpers;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        private IAddShowCommand addShowCommand;

        public ShowsController(IAddShowCommand addShowCommand)
        {
            this.addShowCommand = addShowCommand;
        }

        // GET: api/Shows
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Shows/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Shows
        [HttpPost]
        public IActionResult Post([FromForm] InsertShow value)
        {
            var extension = Path.GetExtension(value.ShowPicturePath.FileName);

            if (!AllowedExtensions.Extensions.Contains(extension))
            {
                return UnprocessableEntity("Extension is not allowed!");
            }

            try
            {
                var newPictureName = Guid.NewGuid().ToString() + "_" + value.ShowPicturePath.FileName;

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newPictureName);

                value.ShowPicturePath.CopyTo(new FileStream(filePath, FileMode.Create));

                var show = new ShowDTO
                {
                    ShowPicturePath = newPictureName,
                    ShowTitle = value.ShowTitle,
                    ShowText = value.ShowText,
                    ShowYear = value.ShowYear,
                    CategoryId = value.CategoryId
                    //Actors = value.Actors.Select(a => a.ActorFirstName + "" + a.ActorLastName).ToList()
                };

                addShowCommand.Execute(show);
                return StatusCode(201);

            }
            catch (Exception)
            {
                return StatusCode(500);
            }            
        }

        // PUT: api/Shows/5
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
