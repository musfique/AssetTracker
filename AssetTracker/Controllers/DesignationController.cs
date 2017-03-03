using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssetTracker.Core.BLL;
using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces.IManager;

namespace AssetTracker.Controllers
{
    public class DesignationController : Controller
    {
       
        private IDesignationManager _designationManager;

        public DesignationController(IDesignationManager designationManager)
        {
            _designationManager = designationManager;
        }

        // GET: Designations
        public ActionResult Index()
        {
            return View(_designationManager.GetAll());
        }

        // GET: Designations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = _designationManager.GetById((int) id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // GET: Designations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Designations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DesignationID,DesignationName")] Designation designation)
        {
            if (ModelState.IsValid)
            {
               if(_designationManager.Insert(designation))
                    return RedirectToAction("Index");
                ModelState.AddModelError("","Something went worng");
            }

            return View(designation);
        }

        // GET: Designations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = _designationManager.GetById((int)id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // POST: Designations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DesignationID,DesignationName")] Designation designation)
        {
            if (ModelState.IsValid)
            {
                if(_designationManager.Edit(designation))
                    return RedirectToAction("Index");
                ModelState.AddModelError("","Something went worng");

            }
            return View(designation);
        }

        // GET: Designations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = _designationManager.GetById((int) id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // POST: Designations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if(_designationManager.Delete(id))
                return RedirectToAction("Index");
            Designation designation = _designationManager.GetById(id);
            return View(designation);
        }
        public JsonResult IsDesignationAvailable(string designationName, int? designationId)
        {
            if (designationId == null)
                designationId = 0;
            return Json(_designationManager.IsDesignationNameAvailable(designationName, (int) designationId),
                JsonRequestBehavior.DenyGet);
        }
    }
}
