using AssetTracker.Core.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTracker.Core.BLL;
using AssetTracker.Core.Models.Interfaces.BLL;

namespace AssetTracker.Controllers
{
    public class VendorController : Controller
    {
        private IVendorManager _vendorManager;

        public VendorController(IVendorManager vendorManager)
        {
            _vendorManager = vendorManager;
        }
        // GET: Vendor
        public ActionResult Index()
        {
            var vendors = _vendorManager.GetAll();
            return View(vendors);
        }

        // GET: Vendor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vendor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendor/Create
        [HttpPost]
        public ActionResult Create(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                if (_vendorManager.Insert(vendor))
                    return RedirectToAction("Index");
                ModelState.AddModelError("","Something went worng");
            }
            return View(vendor);
        }

        // GET: Vendor/Edit/5
        public ActionResult Edit(int id)
        {
            var vendor = _vendorManager.GetById(id);
            return View(vendor);
        }

        // POST: Vendor/Edit/5
        [HttpPost]
        public ActionResult Edit(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                if(_vendorManager.Edit(vendor))
                    return RedirectToAction("Index");
                ModelState.AddModelError("", "Something went worng");
            }
            return View(vendor);
        }

        // GET: Vendor/Delete/5
        public ActionResult Delete(int id)
        {
            var vendor = _vendorManager.GetById(id);
            return View(vendor);
        }

        // POST: Vendor/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (_vendorManager.Delete(id))
                return RedirectToAction("Index");
            ModelState.AddModelError("","Something went worng");
            var vendor = _vendorManager.GetById(id);
            return View(vendor);
        }

        public JsonResult IsVendorNameAvailable(string vendorName,int? vendorId)
        {
            if (vendorId == null)
                vendorId = 0;
            return Json(_vendorManager.IsVendorNameAvailable(vendorName, (int)vendorId),JsonRequestBehavior.DenyGet);
        }
    }
}
