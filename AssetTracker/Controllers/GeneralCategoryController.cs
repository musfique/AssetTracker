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
    public class GeneralCategoryController : Controller
    {
        private IGeneralCategoryManager _generalCategoryManager;

        public GeneralCategoryController(IGeneralCategoryManager generalCategoryManager)
        {
            _generalCategoryManager = generalCategoryManager;
        }
        // GET: GeneralCategory
        public ActionResult Index()
        {
            var generalCategories = _generalCategoryManager.GetAll();
            return View(generalCategories);
        }

        // GET: GeneralCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralCategory generalCategory = _generalCategoryManager.GetById((int) id);
            if (generalCategory == null)
            {
                return HttpNotFound();
            }
            return View(generalCategory);
        }

        // GET: GeneralCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GeneralCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GeneralCategoryID,GeneralCategoryName,GeneralCategoryCode")] GeneralCategory generalCategory)
        {
            if (ModelState.IsValid)
            {
                if(_generalCategoryManager.Insert(generalCategory))
                    return RedirectToAction("Index");
                ModelState.AddModelError("","Something went worng");
            }
            return View(generalCategory);
        }

        // GET: GeneralCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralCategory generalCategory = _generalCategoryManager.GetById((int) id);
            if (generalCategory == null)
            {
                return HttpNotFound();
            }
            return View(generalCategory);
        }

        // POST: GeneralCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GeneralCategoryID,GeneralCategoryName,GeneralCategoryCode")] GeneralCategory generalCategory)
        {
            if (ModelState.IsValid)
            {
               if(_generalCategoryManager.Edit(generalCategory))
                    return RedirectToAction("Index");
                ModelState.AddModelError("","Something went worng");
            }
            return View(generalCategory);
        }

        // GET: GeneralCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralCategory generalCategory = _generalCategoryManager.GetById((int) id);
            if (generalCategory == null)
            {
                return HttpNotFound();
            }
            return View(generalCategory);
        }

        // POST: GeneralCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if(_generalCategoryManager.Delete(id))
                return RedirectToAction("Index");
            ModelState.AddModelError("","Something went worng");
            GeneralCategory generalCategory = _generalCategoryManager.GetById(id);
            return View(generalCategory);

        }

        public JsonResult GetAllCategories()
        {
            return Json(_generalCategoryManager.GetAll(), JsonRequestBehavior.DenyGet);
        }

        public JsonResult IsGeneralCategoryNameAvailable(string generalCategoryName,int? generalCategoryId)
        {
            if (generalCategoryId == null)
                generalCategoryId = 0;
            return Json(_generalCategoryManager.IsGeneralCategoryNameAvailable(generalCategoryName,(int)generalCategoryId), JsonRequestBehavior.DenyGet);
        }
        public JsonResult IsGeneralCategoryCodeAvailable(string generalCategoryCode,int? generalCategoryId) 
        {
            if (generalCategoryId == null)
                generalCategoryId = 0;
            return Json(_generalCategoryManager.IsGeneralCategoryCodeAvailable(generalCategoryCode,(int)generalCategoryId), JsonRequestBehavior.DenyGet);
        }
    }
}
