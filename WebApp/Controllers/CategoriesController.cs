using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.CategoriesCommands;
using Application.DTO;
using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        private IAddCategoryCommand addCategoryCommand;
        private IGetCategoryCommand getCategoryCommand;
        private IEditCategoryCommand editCategoryCommand;
        private IDeleteCategoryCommand deleteCategoryCommand;
        private IGetCategoriesCommand getCategoriesCommand;

        public CategoriesController(IAddCategoryCommand addCategoryCommand, IGetCategoryCommand getCategoryCommand, IEditCategoryCommand editCategoryCommand, IDeleteCategoryCommand deleteCategoryCommand, IGetCategoriesCommand getCategoriesCommand)
        {
            this.addCategoryCommand = addCategoryCommand;
            this.getCategoryCommand = getCategoryCommand;
            this.editCategoryCommand = editCategoryCommand;
            this.deleteCategoryCommand = deleteCategoryCommand;
            this.getCategoriesCommand = getCategoriesCommand;
        }

        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryDTO collection)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Category name error";
                RedirectToAction("create");
            }
            try
            {
                addCategoryCommand.Execute(collection);
            }
            catch(DataAlreadyExistsException)
            {
                TempData["error"] = "Already same name exists!";
            }
            catch (Exception)
            {
                TempData["error"] = "Something is wrong!";
            }
            return View();
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var data = getCategoryCommand.Execute(id);
                return View(data);
            }            
            catch (Exception e)
            {
                return RedirectToAction("index");
            }
            
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryDTO collection)
        {
            if (!ModelState.IsValid)
            {
                return View(collection);
            }
            try
            {
                editCategoryCommand.Execute(collection);
                return RedirectToAction("Index");
            }
            catch(DataNotFoundException)
            {
                return RedirectToAction("Index");
            }
            catch (DataAlreadyExistsException)
            {
                TempData["error"] = "Name already exists!";
                return null;
            }
            catch (DataNotAlteredException)
            {
                TempData["error"] = "Name was not altered!";
                return null;
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }        

        // GET: Categories/Delete/5
        
        public ActionResult Delete(int id)
        {
            try
            {
                deleteCategoryCommand.Execute(id);
                return RedirectToAction("Index");
            }
            catch(DataNotFoundException)
            {
                return null;
            }
            catch (Exception)
            {
                return RedirectToAction("Create");
            }
        }
    }
}