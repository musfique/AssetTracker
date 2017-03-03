using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTracker.Core.BLL;
using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces.IManager;
using AssetTracker.Core.Models.ViewModel;

namespace AssetTracker.Controllers
{
    public class AssetPurchaseController : Controller
    {
        private IVendorManager _vendorManager;
        private IOrganizationManager _organizationManager;
        private IOrganizationBranchManager _organizationBranch;
        private IGeneralCategoryManager _generalCategoryManager;
        private ICategoryManager _categoryManager;
        private ISubCategoryManager _subCategoryManager;
        private IDetailCategoryManager _detailCategoryManager;

        public AssetPurchaseController(IVendorManager vendorManager, IOrganizationManager organizationManager, IOrganizationBranchManager organizationBranch, IGeneralCategoryManager generalCategoryManager, ICategoryManager categoryManager, ISubCategoryManager subCategoryManager, IDetailCategoryManager detailCategoryManager)
        {
            _vendorManager = vendorManager;
            _organizationManager = organizationManager;
            _organizationBranch = organizationBranch;
            _generalCategoryManager = generalCategoryManager;
            _categoryManager = categoryManager;
            _subCategoryManager = subCategoryManager;
            _detailCategoryManager = detailCategoryManager;
        }

        // GET: AssetPurchase
        public ActionResult Index()
        {
            return View();
        }

        // GET: AssetPurchase/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AssetPurchase/Create
        public ActionResult Create()
        {
            var assetPurchasevm = new AssetPurchaseCreateViewModel
            {
                VendorsSelectList =  new SelectList(_vendorManager.GetAll(),"VendorID","VendorName"),
                OrganizationsSelectList = new SelectList(_organizationManager.GetAll(),"OrganizationID","OrganizationName"),
                OrganizationBranchesSelectList = new SelectList(Enumerable.Empty<SelectListItem>()),
                //WarrantyPeriodUnitsSelectList = new SelectList(_warrantyPeriodUnitManager.GetAllWarrantyPeriodUnits(), "WarrantyPeriodUnitID", "WarrantyPeriodUnitName"),
                GeneralCategoriesSelectList = new SelectList(_generalCategoryManager.GetAll(), "GeneralCategoryID", "GeneralCategoryName"),
                CategoriesSelectList = new SelectList(Enumerable.Empty<SelectListItem>()),
                SubCategoriesSelectList = new SelectList(Enumerable.Empty<SelectListItem>()),
                DetailCategoriesSelectList = new SelectList(Enumerable.Empty<SelectListItem>()),
                DetailCategoryCodesSelectList = new SelectList(Enumerable.Empty<SelectListItem>())
               

                
            };
            return System.Web.UI.WebControls.View(assetPurchasevm);
        }

        // POST: AssetPurchase/Create
        [HttpPost]
        public ActionResult Create(AssetPurchaseCreateViewModel assetPurchaseVm)
        {

            
          var assetPurchase = Mapper.Map<AssetPurchase>(assetPurchaseVm);

            using (AssetTrackerEntities db = new AssetTrackerEntities())
            {
                db.AssetPurchases.Add(assetPurchase);
                db.SaveChanges();
            }
            
            return View();
        }

        // GET: AssetPurchase/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AssetPurchase/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AssetPurchase/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AssetPurchase/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}