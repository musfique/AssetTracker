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
    public class EmployeeController : Controller
    {
       
        private IEmployeeManager _employeeManager;
        private IOrganizationManager _organizationManager;
        private IOrganizationBranchManager _organizationBranchManager;
        private IDesignationManager _designationManager;
        private IDepartmentManager _departmentManager;

        public EmployeeController(IEmployeeManager employeeManager, IOrganizationManager organizationManager,
            IOrganizationBranchManager organizationBranchManager, IDesignationManager designationManager,
            IDepartmentManager departmentManager)
        {
            _employeeManager = employeeManager;
            _organizationManager = organizationManager;
            _organizationBranchManager = organizationBranchManager;
            _designationManager = designationManager;
            _departmentManager = departmentManager;
        }
        // GET: Employee
        public ActionResult Index()
        {
            var employees = _employeeManager.GetAll();
            return View(employees);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeManager.GetById((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.Organizations = new SelectList(_organizationManager.GetAll(), "OrganizationID", "OrganizationName");
            ViewBag.Designations = new SelectList(_designationManager.GetAll(), "DesignationID", "DesignationName");
            ViewBag.OrganizationBranches = Enumerable.Empty<SelectListItem>();
            ViewBag.Departments = Enumerable.Empty<SelectListItem>();
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,DepartmentID,EmployeeName,DesignationID,ContactNo,Email")] Employee employee,int organizationId,int organizationBranchId)
        {
            if (ModelState.IsValid)
            {
                if (_employeeManager.Insert(employee))
                    return RedirectToAction("Index");
                ModelState.AddModelError("","Something went worng");
            }

            ViewBag.Organizations = new SelectList(_organizationManager.GetAll(), "OrganizationID", "OrganizationName", organizationId);
            ViewBag.Designations = new SelectList(_designationManager.GetAll(), "DesignationID", "DesignationName");
            ViewBag.OrganizationBranches = new SelectList(_organizationBranchManager.GetAll(), "OrganizationBranchID", "OrganizationBranchName", organizationBranchId);
            ViewBag.Departments = new SelectList(_departmentManager.GetAll(),"DepartmentID","DepartmentName");
            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeManager.GetById((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Organizations = new SelectList(_organizationManager.GetAll(), "OrganizationID", "OrganizationName", employee.Department.OrganizationBranch.OrganizationID);
            ViewBag.Designations = new SelectList(_designationManager.GetAll(), "DesignationID", "DesignationName");
            ViewBag.OrganizationBranches = new SelectList(_organizationBranchManager.GetAll(), "OrganizationBranchID", "OrganizationBranchName", employee.Department.OrganizationBranchID);
            ViewBag.Departments = new SelectList(_departmentManager.GetAll(), "DepartmentID", "DepartmentName");
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,DepartmentID,EmployeeName,DesignationID,ContactNo,Email")] Employee employee, int organizationId, int organizationBranchId)
        {
            if (ModelState.IsValid)
            {
                if (_employeeManager.Edit(employee))
                    return RedirectToAction("Index");
                ModelState.AddModelError("", "Something went worng");
            }
            ViewBag.Organizations = new SelectList(_organizationManager.GetAll(), "OrganizationID", "OrganizationName", organizationId);
            ViewBag.Designations = new SelectList(_designationManager.GetAll(), "DesignationID", "DesignationName");
            ViewBag.OrganizationBranches = new SelectList(_organizationBranchManager.GetAllByOrganizationId(organizationId), "OrganizationBranchID", "OrganizationBranchName", organizationBranchId);
            ViewBag.Departments = new SelectList(_departmentManager.GetAllByOrganizationBranchId(organizationBranchId), "DepartmentID", "DepartmentName");
            return View(employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeManager.GetById((int) id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if(_employeeManager.Delete(id))
                return RedirectToAction("Index");
            ModelState.AddModelError("","Something went worng");
            Employee employee = _employeeManager.GetById(id);
            return View(employee);
        }
        
    }
}
