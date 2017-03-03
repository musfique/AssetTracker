using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AssetTracker.Core.Models.Interfaces.IManager;

namespace AssetTracker.Core.Models.UiLoader
{
    public class UiLoader
    {
        private IOrganizationManager _organizationManager;
        private IOrganizationBranchManager _organizationBranchManager;
        private IDepartmentManager _departmentManager;
        private IDesignationManager _designationManager;
        private IEmployeeManager _employeeManager;
        private IVendorManager _vendorManager;

        private IGeneralCategoryManager _generalCategoryManager;
        private ICategoryManager _categoryManager;
        private ISubCategoryManager _subCategoryManager;
        private IDetailCategoryManager _detailCategoryManager;
        
        public UiLoader(
            IOrganizationManager organizationManager,
            IOrganizationBranchManager organizationBranchManager,
            IDepartmentManager departmentManager,
            IDesignationManager designationManager,
            IEmployeeManager employeeManager,
            IVendorManager vendorManager,
            IGeneralCategoryManager generalCategoryManager,
            ICategoryManager categoryManager,
            ISubCategoryManager subCategoryManager,
            IDetailCategoryManager detailCategoryManager
            )
        {
            _organizationManager = organizationManager;
            _organizationBranchManager = organizationBranchManager;
            _departmentManager = departmentManager;
            _designationManager = designationManager;
            _employeeManager = employeeManager;
            _vendorManager = vendorManager;
            _generalCategoryManager = generalCategoryManager;
            _categoryManager = categoryManager;
            _subCategoryManager = subCategoryManager;
            _detailCategoryManager = detailCategoryManager;
        }

        public List<SelectListItem> GetDefaultSelectListItem()
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem {Value = "", Text = "---Select---"},
            };
            return items;
        }
        public List<SelectListItem> GetGeneralCategorySelectListItems()
        {
            var generalCategories = _generalCategoryManager.GetAll();
            var items = GetDefaultSelectListItem();
            items.AddRange(generalCategories.Select(generalCategory => new SelectListItem()
            {
                Value = generalCategory.GeneralCategoryID.ToString(),
                Text = generalCategory.GeneralCategoryName
            }));

            return items;
        }

        public List<SelectListItem> GetCategorySelectListItems()
        {
            var categories = _categoryManager.GetAll();
            var items = GetDefaultSelectListItem();
            items.AddRange(categories.Select(category => new SelectListItem()
            {
                Value = category.CategoryID.ToString(),
                Text = category.CategoryName
            }));

            return items;
        }

        public List<SelectListItem> GetSubCategorySelectListItems()
        {
            var subCategories = _subCategoryManager.GetAll();
            var items = GetDefaultSelectListItem();
            items.AddRange(subCategories.Select(subCategory => new SelectListItem()
            {
                Value = subCategory.SubCategoryID.ToString(),
                Text = subCategory.SubCategoryName
            }));

            return items;
        }

        public List<SelectListItem> GetDetailCategorySelectListItems()
        {
            var detailCategories = _detailCategoryManager.GetAll();
            var items = GetDefaultSelectListItem();
            items.AddRange(detailCategories.Select(detailCategory => new SelectListItem()
            {
                Value = detailCategory.DetailCategoryID.ToString(),
                Text = detailCategory.DetailCategoryName
            }));

            return items;
        }
    }
}
