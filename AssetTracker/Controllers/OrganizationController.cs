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
    public class OrganizationController : Controller
    {
        private IOrganizationManager _organizationManager;

        public OrganizationController(IOrganizationManager organizationManager)
        {
            _organizationManager = organizationManager;
        }
        // GET: Organization
        public ActionResult Index()
        {
            return View(_organizationManager.GetAll());
        }

        // GET: Organization/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = _organizationManager.GetById((int)id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // GET: Organization/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organization/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrganizationID,OrganizationName,OrganizationShortName,OrganizationLocation")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                _organizationManager.Insert(organization);
                    return RedirectToAction("Index");
            }

            return View(organization);
        }

        // GET: Organization/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = _organizationManager.GetById((int)id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Organization/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrganizationID,OrganizationName,OrganizationShortName,OrganizationLocation")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                if(_organizationManager.Edit(organization))
                    return RedirectToAction("Index");
            }
            return View(organization);
        }

        // GET: Organization/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = _organizationManager.GetById((int) id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Organization/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if(_organizationManager.Delete(id))
                return RedirectToAction("Index");
            Organization organization = _organizationManager.GetById(id);
            return View(organization);
            
        }

        public JsonResult IsNameAvilable(string organizationName, int? organizationId=0)
        {
            return Json(_organizationManager.IsNameAvailable(organizationName, (int)organizationId), JsonRequestBehavior.DenyGet);
        }

        public JsonResult IsShortNameAvilable(string organizationShortName, int? organizationId = 0)
        {
            return Json(_organizationManager.IsShortNameAvailable(organizationShortName, (int)organizationId), JsonRequestBehavior.DenyGet);
        }
    }
}
