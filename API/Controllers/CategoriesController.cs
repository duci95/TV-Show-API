using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.CategoriesCommands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private IGetCategoriesCommand getCategoriesCommand;
        private IGetCategoryCommand getCategoryCommand;
        private IAddCategoryCommand addCategoryCommand;
        private IEditCategoryCommand editCategoryCommand;
        private IDeleteCategoryCommand deleteCategoryCommand;

        public CategoriesController(IGetCategoriesCommand getCategoriesCommand, IGetCategoryCommand getCategoryCommand, IAddCategoryCommand addCategoryCommand, IEditCategoryCommand editCategoryCommand, IDeleteCategoryCommand deleteCategoryCommand)
        {
            this.getCategoriesCommand = getCategoriesCommand;
            this.getCategoryCommand = getCategoryCommand;
            this.addCategoryCommand = addCategoryCommand;
            this.editCategoryCommand = editCategoryCommand;
            this.deleteCategoryCommand = deleteCategoryCommand;
        }

        // GET: api/Categories
        [HttpGet]
        public ActionResult Get([FromQuery] CategorySearch search)
            => Ok(getCategoriesCommand.Execute(search));        

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(getCategoryCommand.Execute(id));
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

        // POST: api/Categories
        [HttpPost]
        public ActionResult Post([FromBody] CategoryDTO value)
        {
            try
            {
                addCategoryCommand.Execute(value);
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

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CategoryDTO value)
        {
            try
            {
                editCategoryCommand.Execute(value);
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
                deleteCategoryCommand.Execute(id);
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
