using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.CommentsCommands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private IGetCommentsCommand getCommentsCommand;
        private IGetCommentCommand getCommentCommand;
        private IAddCommentCommand addCommentCommand;
        private IEditCommentCommand editCommentCommand;
        private IDeleteCommentCommand deleteCommentCommand;

        public CommentsController(IGetCommentsCommand getCommentsCommand, IGetCommentCommand getCommentCommand, IAddCommentCommand addCommentCommand, IEditCommentCommand editCommentCommand, IDeleteCommentCommand deleteCommentCommand)
        {
            this.getCommentsCommand = getCommentsCommand;
            this.getCommentCommand = getCommentCommand;
            this.addCommentCommand = addCommentCommand;
            this.editCommentCommand = editCommentCommand;
            this.deleteCommentCommand = deleteCommentCommand;
        }




        // GET: api/Comments
        [HttpGet]
        public ActionResult Get([FromQuery] CommentSearch comment)
            => Ok(getCommentsCommand.Execute(comment));
            
        

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(getCommentCommand.Execute(id));
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

        // POST: api/Comments
        [HttpPost]
        public ActionResult Post([FromBody] CommentDTO value)
        {
            try
            {
                addCommentCommand.Execute(value);
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

        // PUT: api/Comments/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CommentDTO value)
        {
            try
            {
                editCommentCommand.Execute(value);
                return NoContent();
            }
            catch (DataNotFoundException)
            {
                return NotFound();
            }
            catch (DataAlreadyExistsException)
            {
                return Conflict();
            }
            catch (DataNotAlteredException)
            {
                return Conflict("Data not altered");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult  Delete(int id)
        {
            try
            {
                deleteCommentCommand.Execute(id);
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
