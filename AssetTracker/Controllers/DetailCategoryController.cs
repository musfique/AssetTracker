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
using AssetTracker.Core.Models.Interfaces.IManager;

namespace AssetTracker.Controllers
{
    public class DetailCategoryController : Controller
    {
        
        private IGeneralCategoryManager _generalCategoryManager;
        private ICategoryManager _categoryManager;
        private ISubCategoryManager _subCategoryManager;
        private IDetailCategoryManager _detailCategoryManager;

        public DetailCategoryController(IGeneralCategoryManager generalCategoryManager, ICategoryManager categoryManager, ISubCategoryManager subCategoryManager, IDetailCategoryManager detailCategoryManager)
        {
            _generalCategoryManager = generalCategoryManager;
            _categoryManager = categoryManager;
            _subCategoryManager = subCategoryManager;
            _detailCategoryManager = detailCategoryManager;
        }

        // GET: DetailCategory
        public ActionResult Index()
        {
            var detailCategories = _detailCategoryManager.GetAll();
            return View(detailCategories);
        }

        // GET: DetailCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailCategory detailCategory = _detailCategoryManager.GetById((int)id);
            if (detailCategory == null)
            {
                return HttpNotFound();
            }
            return View(detailCategory);
        }

        // GET: DetailCategory/Create
        public ActionResult Create()
        {
            ViewBag.GeneralCategories = new SelectList(_generalCategoryManager.GetAll(), "GeneralCategoryID", "GeneralCategoryName");
            ViewBag.Categories = Enumerable.Empty<SelectListItem>();
            ViewBag.SubCategories = Enumerable.Empty<SelectListItem>();

            return View();
        }

        // POST: DetailCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DetailCategoryID,SubCategoryID,DetailCategoryName,DetailCategoryCode,DetailCategoryDescription")] DetailCategory detailCategory)
        {
            if (ModelState.IsValid)
            {
                _detailCategoryManager.Insert(detailCategory);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("","Something went wrong");
            ViewBag.GeneralCategories = new SelectList(_generalCategoryManager.GetAll(), "GeneralCategoryID", "GeneralCategoryName", detailCategory.SubCategory.Category.GeneralCategoryID);
            ViewBag.Categories = new SelectList(_categoryManager.GetAll(), "CategoryID", "CategoryName", detailCategory.SubCategory.CategoryID);
            ViewBag.SubCategories = new SelectList(_subCategoryManager.GetAll(), "SubCategoryID", "SubCategoryName", detailCategory.SubCategoryID);
            return View(detailCategory);
        }

        // GET: DetailCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailCategory detailCategory = _detailCategoryManager.GetById((int) id);
            if (detailCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.GeneralCategories = new SelectList(_generalCategoryManager.GetAll(), "GeneralCategoryID", "GeneralCategoryName", detailCategory.SubCategory.Category.GeneralCategoryID);
            ViewBag.Categories = new SelectList(_categoryManager.GetAll(), "CategoryID", "CategoryName", detailCategory.SubCategory.CategoryID);
            ViewBag.SubCategories = new SelectList(_subCategoryManager.GetAll(), "SubCategoryID", "SubCategoryName", detailCategory.SubCategoryID);
            return View(detailCategory);
        }

        // POST: DetailCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DetailCategoryID,SubCategoryID,DetailCategoryName,DetailCategoryCode,DetailCategoryDescription")] DetailCategory detailCategory)
        {
            if (ModelState.IsValid)
            {
                _detailCategoryManager.Edit(detailCategory);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Something went wrong");
            ViewBag.GeneralCategories = new SelectList(_generalCategoryManager.GetAll(), "GeneralCategoryID", "GeneralCategoryName", detailCategory.SubCategory.Category.GeneralCategoryID);
            ViewBag.Categories = new SelectList(_categoryManager.GetAll(), "CategoryID", "CategoryName", detailCategory.SubCategory.CategoryID);
            ViewBag.SubCategories = new SelectList(_subCategoryManager.GetAll(), "SubCategoryID", "SubCategoryName", detailCategory.SubCategoryID);
            return View(detailCategory);
        }

        // GET: DetailCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailCategory detailCategory = _detailCategoryManager.GetById((int)id);
            if (detailCategory == null)
            {
                return HttpNotFound();
            }
            return View(detailCategory);
        }

        // POST: DetailCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if(_detailCategoryManager.Delete(id))
                return RedirectToAction("Index");
            DetailCategory detailCategory = _detailCategoryManager.GetById((int)id);
            return View(detailCategory);
        }
        public ActionResult IsNameAvailable(string detailCategoryName, int subCategoryId)
        {
            return Json(_detailCategoryManager.IsDetailCategoryNameAvilable(detailCategoryName, subCategoryId), JsonRequestBehavior.AllowGet);
        }
        public ActionResult IsNameAvailableWithId(string detailCategoryName, int detailCategoryId, int subCategoryId)
        {
            return Json(_detailCategoryManager.IsDetailCategoryNameAvilable(detailCategoryName, detailCategoryId, subCategoryId), JsonRequestBehavior.AllowGet);
        }
        public ActionResult IsCodeAvailable(string detailCategoryCode, int subCategoryId)
        {
            return Json(_detailCategoryManager.IsDetailCategoryCodeAvilable(detailCategoryCode, subCategoryId), JsonRequestBehavior.AllowGet);
        }
        public ActionResult IsCodeAvailableWithId(string detailCategoryCode, int detailCategoryId, int subCategoryId)
        {
            return Json(_detailCategoryManager.IsDetailCategoryCodeAvilable(detailCategoryCode, detailCategoryId, subCategoryId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllBySubCategoryId(int subCategoryId)
        {
            var detailCategories = _detailCategoryManager
                .GetAllBySubCategoryId(subCategoryId)
                .Select(c => new
                {
                    c.DetailCategoryID,
                    c.SubCategoryID,
                    c.DetailCategoryCode,
                    c.DetailCategoryName,
                    c.DetailCategoryDescription
                }).ToList();

            return Json(detailCategories, JsonRequestBehavior.AllowGet);
        }
    }
}
