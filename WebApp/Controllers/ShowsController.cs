using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.ShowCommands;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{      

    public class ShowsController : Controller
    {
        private IGetShowsCommand getShowsCommand;
        private IGetShowCommand getShowCommand;
        private IAddShowCommand addShowCommand;
        private IEditShowCommand editShowCommand;
        private IDeleteShowCommand deleteShowCommand;

        public ShowsController(IGetShowsCommand getShowsCommand, IGetShowCommand getShowCommand, IAddShowCommand addShowCommand, IEditShowCommand editShowCommand, IDeleteShowCommand deleteShowCommand)
        {
            this.getShowsCommand = getShowsCommand;
            this.getShowCommand = getShowCommand;
            this.addShowCommand = addShowCommand;
            this.editShowCommand = editShowCommand;
            this.deleteShowCommand = deleteShowCommand;
        }


        // GET: Shows
        public ActionResult Index()
         => View();

        // GET: Shows/Details/5
        public ActionResult Details(int id)
        {
            return View(getShowCommand.Execute(id));
        }

        // GET: Shows/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shows/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
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