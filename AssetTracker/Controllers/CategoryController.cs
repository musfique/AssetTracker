using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssetTracker.Core.BLL;
using AssetTracker.Core.Models;
using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces.BLL;

namespace AssetTracker.Controllers
{
    public class CategoryController : Controller
    {
        private IGeneralCategoryManager _generalCategoryManager;
        private ICategoryManager _categoryManager;

        public CategoryController(IGeneralCategoryManager generalCategoryManager, ICategoryManager categoryManager)
        {
            _generalCategoryManager = generalCategoryManager;
            _categoryManager = categoryManager;
        }
        // GET: Category
        public ActionResult Index()
        {
            var categories = _categoryManager.GetAll();
            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _categoryManager.GetById((int) id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            ViewBag.GeneralCategories = new SelectList(_generalCategoryManager.GetAll(), "GeneralCategoryID", "GeneralCategoryName");
            ViewBag.Categories = new List<SelectListItem>();
            return View();
        }
        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,GeneralCategoryID,CategoryName,CategoryCode,CategoryDescription")] Category category)
        {
            if (ModelState.IsValid)
            {
                if(_categoryManager.Insert(category))
                    return RedirectToAction("Index");
                ModelState.AddModelError("","Something went worng");
            }

            ViewBag.GeneralCategories = new SelectList(_generalCategoryManager.GetAll(), "GeneralCategoryID", "GeneralCategoryName");
            return View(category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _categoryManager.GetById((int) id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.GeneralCategories = new SelectList(_generalCategoryManager.GetAll(), "GeneralCategoryID", "GeneralCategoryName");
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,GeneralCategoryID,CategoryName,CategoryCode,CategoryDescription")] Category category)
        {
            if (ModelState.IsValid)
            {
                if(_categoryManager.Edit(category))
                    return RedirectToAction("Index");
                ModelState.AddModelError("","Something went worng");
            }
            ViewBag.GeneralCategories = new SelectList(_generalCategoryManager.GetAll(), "GeneralCategoryID", "GeneralCategoryName");
            return View(category);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _categoryManager.GetById((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if(_categoryManager.Delete(id))
                return RedirectToAction("Index");
            Category category = _categoryManager.GetById((int)id);
            return View(category);
        }
        public JsonResult IsCategoryCodeAvailableWithId(int generalCategoryId, string categoryCode,int categoryId) 
        {
            return Json(_categoryManager.IsCategoryCodeAvailable(generalCategoryId, categoryCode, categoryId), JsonRequestBehavior.DenyGet);
        }
       public JsonResult IsCategoryCodeAvailable(int generalCategoryId, string categoryCode) 
        {
            return Json(_categoryManager.IsCategoryCodeAvailable(generalCategoryId, categoryCode), JsonRequestBehavior.DenyGet);
        }
        public JsonResult IsCategoryNameAvailable(int generalCategoryId, string categoryName) 
        {
            return Json(_categoryManager.IsCategoryNameAvailable(generalCategoryId, categoryName), JsonRequestBehavior.DenyGet);
        }
        public JsonResult IsCategoryNameAvailableWithId(int generalCategoryId, string categoryName, int categoryId) 
        {
            return Json(_categoryManager.IsCategoryNameAvailable(generalCategoryId, categoryName, categoryId), JsonRequestBehavior.DenyGet);
        }

        public JsonResult GetAllByGeneralCategoryId(int generalCategoryId)
        {
            var categories = _categoryManager.GetAllByGeneralCategoryId(generalCategoryId)
                .Select(content => new
                {
                    content.CategoryID,
                    content.CategoryCode,
                    content.CategoryName,
                    content.CategoryDescription,
                    content.GeneralCategoryID,
                    content.GeneralCategory.GeneralCategoryName
                });
            return Json(categories, JsonRequestBehavior.DenyGet);
        }

        
    }
}
