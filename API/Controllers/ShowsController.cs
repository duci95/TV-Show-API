using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Application.Commands.ShowCommands;
using Application.DTO;
using Application.Exceptions;
using Application.Helpers;
using Application.Searches;
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
        private IEditShowCommand editShowCommand;
        private IGetShowCommand getShowCommand;
        private IGetShowsCommand getShowsCommand;
        private IDeleteShowCommand deleteShowCommand;

        public ShowsController(IAddShowCommand addShowCommand, IEditShowCommand editShowCommand, IGetShowCommand getShowCommand, IGetShowsCommand getShowsCommand, IDeleteShowCommand deleteShowCommand)
        {
            this.addShowCommand = addShowCommand;
            this.editShowCommand = editShowCommand;
            this.getShowCommand = getShowCommand;
            this.getShowsCommand = getShowsCommand;
            this.deleteShowCommand = deleteShowCommand;
        }

        // GET: api/Shows
        [HttpGet]
        public IActionResult Get([FromQuery] ShowSearch shows)
            => Ok(getShowsCommand.Execute(shows));        

        // GET: api/Shows/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(getShowCommand.Execute(id));
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
                };

                addShowCommand.Execute(show);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }            
        }
        //kako da se odradi edit slike - nema ga nigde
        // PUT: api/Shows/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] InsertShow value)
        {
            if(value.ShowPicturePath != null)
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
                        ShowPicturePath = newPictureName                        
                    };

                    editShowCommand.Execute(show);
                    return NoContent();

                }
                catch (Exception e)
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return null;
                //??
            }
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                deleteShowCommand.Execute(id);
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