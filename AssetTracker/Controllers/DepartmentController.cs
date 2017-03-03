using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssetTracker.Core.BLL;
using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces;
using AssetTracker.Core.Models.Interfaces.IManager;

namespace AssetTracker.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentManager _departmentManager;
        private IOrganizationBranchManager _organizationBranchManager;
        private IOrganizationManager _organizationManager;

        public DepartmentController(IDepartmentManager departmentManager, IOrganizationBranchManager organizationBranchManager, IOrganizationManager organizationManager)
        {
            _departmentManager = departmentManager;
            _organizationBranchManager = organizationBranchManager;
            _organizationManager = organizationManager;
        }

        // GET: Department
        public ActionResult Index()
        {
            var departments = _departmentManager.GetAll();
            return View(departments);
        }

        // GET: Department/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _departmentManager.GetById((int)id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            ViewBag.Organizations = new SelectList(_organizationManager.GetAll(), "OrganizationID",
                "OrganizationName");
            ViewBag.OrganizationBranches = Enumerable.Empty<SelectListItem>();
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentID,OrganizationBranchID,DepartmentName")] Department department)
        {
            if (ModelState.IsValid)
            {
                if(_departmentManager.Insert(department))
                    return RedirectToAction("Index");
                ModelState.AddModelError("","Something went worng");
            }

            ViewBag.Organizations = new SelectList(_organizationManager.GetAll(), "OrganizationID",
                "OrganizationName");
            ViewBag.OrganizationBranches = Enumerable.Empty<SelectListItem>();
            return View(department);
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _departmentManager.GetById((int) id);
            if (department == null)
            {
                return HttpNotFound();
            }
            ViewBag.Organizations = new SelectList(_organizationManager.GetAll(), "OrganizationID",
                "OrganizationName",department.OrganizationBranch.OrganizationID);
            ViewBag.OrganizationBranches = new SelectList(_organizationBranchManager.GetAllByOrganizationId(department.OrganizationBranch.OrganizationID), "OrganizationBranchID",
                "OrganizationBranchName");
            return View(department);
        }

        // POST: Department/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentID,OrganizationBranchID,DepartmentName")] Department department)
        {
            if (ModelState.IsValid)
            {
                if(_departmentManager.Edit(department))
                    return RedirectToAction("Index");
                ModelState.AddModelError("","Something went worng");
            }
            var existingDepartment = _departmentManager.GetById(department.DepartmentID);
            ViewBag.Organizations = new SelectList(_organizationManager.GetAll(), "OrganizationID",
               "OrganizationName", existingDepartment.OrganizationBranch.OrganizationID);
            ViewBag.OrganizationBranches = new SelectList(_organizationBranchManager.GetAllByOrganizationId(existingDepartment.OrganizationBranch.OrganizationID), "OrganizationBranchID",
                "OrganizationBranchName");
            return View(department);
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _departmentManager.GetById((int) id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (_departmentManager.Delete((int) id))
                return RedirectToAction("Index");
            ModelState.AddModelError("","Something went worng!");
            Department department = _departmentManager.GetById(id);
            return View(department);
        }

        public JsonResult IsDepartmentAvailable(string departmentName, int organizationBranchId)
        {
            return Json(_departmentManager.IsDepartmentNameAvailable(departmentName, organizationBranchId),JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDepartments(int id)
        {
            var departments = _departmentManager.GetAllByOrganizationBranchId(id)
                .Select(content => new
                {
                    content.DepartmentID,
                    content.DepartmentName,
                    content.OrganizationBranchID,
                    content.OrganizationBranch.OrganizationBranchName
                }).ToList();
            return Json(departments, JsonRequestBehavior.AllowGet);
        }
        
    }
}
