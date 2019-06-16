using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.ActorsCommands;
using Application.Commands.CategoriesCommands;
using Application.Commands.ShowCommands;
using Application.DTO;
using Application.Helpers;
using Application.Searches;
using EFDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{      

    public class ShowsController : Controller
    {        

        private IGetShowsWEBCommand getShowsCommand;
        private IGetShowCommand getShowCommand;
        private IAddShowCommand addShowCommand;
        private IEditShowCommand editShowCommand;
        private IDeleteShowCommand deleteShowCommand;
             
        private TVShowsContext Context;

        public ShowsController(IGetShowsWEBCommand getShowsCommand, IGetShowCommand getShowCommand, IAddShowCommand addShowCommand, IEditShowCommand editShowCommand, IDeleteShowCommand deleteShowCommand, TVShowsContext context, IGetActorsCommand getActorsCommand)
        {
            this.getShowsCommand = getShowsCommand;
            this.getShowCommand = getShowCommand;
            this.addShowCommand = addShowCommand;
            this.editShowCommand = editShowCommand;
            this.deleteShowCommand = deleteShowCommand;
            Context = context;            
        }   

        // GET: Shows
        public ActionResult Index([FromQuery] ShowSearch value)
        {
            var all = new ShowDTOModel();
            all.Shows = getShowsCommand.Execute(value);
            return View(all);
            
        }
       

        // GET: Shows/Details/5
        public ActionResult Details(int id)
        {
            return View(getShowCommand.Execute(id));
        }

        // GET: Shows/Create
        public ActionResult Create()
        {
            ViewBag.Categories = Context.Categories.Select(e => new CategoryDTO
            {
                CategoryName = e.CategoryTitle,
                Id = e.Id
            });
            ViewBag.Actors = Context.Actors.Select(e => new ActorsDTOModel
            {
               ActorFullName = e.ActorFirstName + " " + e.ActorLastName,
               Id = e.Id
            });
            return View();
        }

        // POST: Shows/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InsertShowDTO value)
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
                    CategoryId = value.CategoryId,
                    ActorIds = value.ActorIds
                };

                addShowCommand.Execute(show);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
            
        }

        // GET: Shows/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Shows/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Shows/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shows/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}