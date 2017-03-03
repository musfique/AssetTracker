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
using AssetTracker.Core.Models.Interfaces;
using AssetTracker.Core.Models.Interfaces.BLL;

namespace AssetTracker.Controllers
{
    public class OrganizationBranchController : Controller
    {
        private IOrganizationBranchManager _organizationBranchManager;
        private IOrganizationManager _organizationManager;

        public OrganizationBranchController(IOrganizationBranchManager organizationBranchManager, IOrganizationManager organizationManager)
        {
            _organizationBranchManager = organizationBranchManager;
            _organizationManager = organizationManager;
        }

        // GET: OrganizationBranch
        public ActionResult Index()
        {
            var organizationBranches = _organizationBranchManager.GetAll();
            return View(organizationBranches);
        }

        // GET: OrganizationBranch/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationBranch organizationBranch = _organizationBranchManager.GetById((int) id);
            if (organizationBranch == null)
            {
                return HttpNotFound();
            }
            return View(organizationBranch);
        }

        // GET: OrganizationBranch/Create
        public ActionResult Create()
        {
            ViewBag.Organizations = new SelectList(_organizationManager.GetAll(), "OrganizationID", "OrganizationName");
            return View();
        }

        // POST: OrganizationBranch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrganizationBranchID,OrganizationID,OrganizationBranchName,OrganizatioBranchShortName")] OrganizationBranch organizationBranch)
        {
            if (ModelState.IsValid)
            {
                if(_organizationBranchManager.Insert(organizationBranch))
                    return RedirectToAction("Index");
                ModelState.AddModelError("","Something went worng");
            }

            ViewBag.Organizations = new SelectList(_organizationManager.GetAll(), "OrganizationID", "OrganizationName");
            return View(organizationBranch);
        }

        // GET: OrganizationBranch/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationBranch organizationBranch = _organizationBranchManager.GetById((int) id);
            if (organizationBranch == null)
            {
                return HttpNotFound();
            }
            ViewBag.Organizations = new SelectList(_organizationManager.GetAll(), "OrganizationID", "OrganizationName", organizationBranch.OrganizationID);
            return View(organizationBranch);
        }

        // POST: OrganizationBranch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrganizationBranchID,OrganizationID,OrganizationBranchName,OrganizatioBranchShortName")] OrganizationBranch organizationBranch)
        {
            if (ModelState.IsValid)
            {
                if(_organizationBranchManager.Edit(organizationBranch))
                    return RedirectToAction("Index");
                ModelState.AddModelError("","Something went worng");
            }
            ViewBag.Organizations = new SelectList(_organizationManager.GetAll(), "OrganizationID", "OrganizationName", organizationBranch.OrganizationID);
            return View(organizationBranch);
        }

        // GET: OrganizationBranch/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationBranch organizationBranch = _organizationBranchManager.GetById((int) id);
            if (organizationBranch == null)
            {
                return HttpNotFound();
            }
            return View(organizationBranch);
        }

        // POST: OrganizationBranch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if(_organizationBranchManager.Delete(id))
                return RedirectToAction("Index");
            OrganizationBranch organizationBranch = _organizationBranchManager.GetById((int) id);
            return View(organizationBranch);
        }

        public JsonResult GetOrganizationBranches(int id)
        {
            var organizationBranches = _organizationBranchManager.GetAllByOrganizationId(id)
                .Select(content => new
                {
                    content.OrganizationBranchID,
                    content.OrganizationBranchName,
                    content.OrganizationID,
                    content.Organization.OrganizationName,
                    content.Organization.OrganizationShortName,
                    content.Organization.OrganizationLocation
                }).ToList();
            return Json(organizationBranches,JsonRequestBehavior.DenyGet);
        }

        public JsonResult IsShortNameAvailable(string organizationBranchShortName)
        {
            return Json(_organizationBranchManager.IsShortNameAvilable(organizationBranchShortName),
                JsonRequestBehavior.DenyGet);
        }
        public JsonResult IsShortNameAvailableForEdit(int organizationId, string organizationBranchShortName)
        {
            return Json(_organizationBranchManager.IsShortNameAvilable(organizationBranchShortName, organizationId),
                JsonRequestBehavior.DenyGet);
        }
        
    }
}
