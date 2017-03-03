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
    public class SubCategoryController : Controller
    {
        private IGeneralCategoryManager _generalCategoryManager;
        private ICategoryManager _categoryManager;
        private ISubCategoryManager _subCategoryManager;

        public SubCategoryController(IGeneralCategoryManager generalCategoryManager, ICategoryManager categoryManager, ISubCategoryManager subCategoryManager)
        {
            _generalCategoryManager = generalCategoryManager;
            _categoryManager = categoryManager;
            _subCategoryManager = subCategoryManager;
        }

        // GET: SubCategory
        public ActionResult Index()
        {
            var subCategories = _subCategoryManager.GetAll();
            return View(subCategories);
        }

        // GET: SubCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = _subCategoryManager.GetById((int) id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // GET: SubCategory/Create
        public ActionResult Create()
        {
            ViewBag.GeneralCategories = new SelectList(_generalCategoryManager.GetAll(),"GeneralCategoryID","GeneralCategoryName");

            ViewBag.Categories = Enumerable.Empty<SelectListItem>();
            return View();
        }

        // POST: SubCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubCategoryID,CategoryID,SubCategoryName,SubCategoryCode,SubCategoryDescription")] SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
               if(_subCategoryManager.Insert(subCategory))
                    return RedirectToAction("Index");
            }

            ViewBag.GeneralCategories = new SelectList(_generalCategoryManager.GetAll(), "GeneralCategoryID", "GeneralCategoryName",subCategory.Category.GeneralCategoryID);
            ViewBag.Categories = new SelectList(_categoryManager.GetAll(), "CategoryID", "CategoryName", subCategory.CategoryID);
            ModelState.AddModelError("","Something went worng!");
            
            return View(subCategory);
        }

        // GET: SubCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = _subCategoryManager.GetById((int) id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.GeneralCategories = new SelectList(_generalCategoryManager.GetAll(), "GeneralCategoryID", "GeneralCategoryName", subCategory.Category.GeneralCategoryID);
            ViewBag.Categories = new SelectList(_categoryManager.GetAll(), "CategoryID", "CategoryName", subCategory.CategoryID);
            return View(subCategory);
        }

        // POST: SubCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubCategoryID,CategoryID,SubCategoryName,SubCategoryCode,SubCategoryDescription")] SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
               if(_subCategoryManager.Edit(subCategory))
                    return RedirectToAction("Index");
            }
            var category = _categoryManager.GetById(subCategory.CategoryID);

            ViewBag.GeneralCategories = new SelectList(_generalCategoryManager.GetAll(), "GeneralCategoryID", "GeneralCategoryName", category.GeneralCategory.GeneralCategoryID);
            ViewBag.Categories = new SelectList(_categoryManager.GetAll(), "CategoryID", "CategoryName", subCategory.CategoryID);
            ModelState.AddModelError("","Something went worng");
            return View(subCategory);
        }

        // GET: SubCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = _subCategoryManager.GetById((int) id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // POST: SubCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if(_subCategoryManager.Delete(id))
                return RedirectToAction("Index");
            SubCategory subCategory = _subCategoryManager.GetById((int) id);
            return View(subCategory);
        }
        public ActionResult IsNameAvailable(string subCategoryName,int categoryId)
        {
            return Json(_subCategoryManager.IsSubCategoryNameAvailable(subCategoryName,categoryId), JsonRequestBehavior.AllowGet);
        }
        public ActionResult IsNameAvailableWithId(string subCategoryName, int subCategoryId, int categoryId) 
        {
            return Json(_subCategoryManager.IsSubCategoryNameAvailable(subCategoryName,subCategoryId, categoryId), JsonRequestBehavior.AllowGet);
        }
        public ActionResult IsCodeAvailable(string subCategoryCode, int categoryId) 
        {
            return Json(_subCategoryManager.IsSubCategoryCodeAvailable(subCategoryCode, categoryId), JsonRequestBehavior.AllowGet);
        }
        public ActionResult IsCodeAvailableWithId(string subCategoryCode,int subCategoryId, int categoryId)
        {
            return Json(_subCategoryManager.IsSubCategoryCodeAvailable(subCategoryCode, subCategoryId,categoryId), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllByCategoryId(int categoryId)
        {
            var subCategories = _subCategoryManager.GetAllByCategoryId(categoryId)
                .Select(content => new
                {
                    content.SubCategoryID,
                    content.SubCategoryName,
                    content.SubCategoryCode,
                    content.SubCategoryDescription,
                    content.CategoryID
                });
            return Json(subCategories, JsonRequestBehavior.AllowGet);
        }

    }
}
