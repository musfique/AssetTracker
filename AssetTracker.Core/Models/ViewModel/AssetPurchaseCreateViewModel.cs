using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AssetTracker.Core.Models.EntityModel;

namespace AssetTracker.Core.Models.ViewModel
{
    class AssetPurchaseCreateViewModel
    {
        [Required]
        [Display(Name = "Vendor")]
        public int VendorID { get; set; }

        [Required]
        [Display(Name = "Organization")]
        public int OrganizationID { get; set; }

        [Required]
        [Display(Name = "Organization Branch")]
        public int OrganizationBranchID { get; set; }

        [Required]
        [Display(Name = "Purchased Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PurchasedDate { get; set; }

        [Required]
        [Display(Name = "Purchased By")]
        public int PurchasedBy { get; set; }


        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        [Display(Name = "General Category")]
        public int GeneralCategoryID { get; set; }

        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        [Display(Name = "Sub Category")]
        public int SubCategoryID { get; set; }

        [Display(Name = "Detail Category")]
        public int DetailCategoryID { get; set; }

        [Display(Name = "Detail Category Code")]
        public int DetailCategoryCode { get; set; }

        public double Quantity { get; set; }
        public double Price { get; set; }

        [Display(Name = "Has Warranty")]
        public bool HasWarranty { get; set; }

        [Display(Name = "Warranty Period Unit")]
        public int WarrantyPeriodUnitID { get; set; }

        [Display(Name = "Warranty Period")]
        public double WarrantyPeriod { get; set; }




        public SelectList OrganizationsSelectList { get; set; }
        public SelectList OrganizationBranchesSelectList { get; set; }
        public SelectList VendorsSelectList { get; set; }
        public SelectList GeneralCategoriesSelectList { get; set; }
        public SelectList CategoriesSelectList { get; set; }
        public SelectList SubCategoriesSelectList { get; set; }
        public SelectList DetailCategoriesSelectList { get; set; }
        public SelectList DetailCategoryCodesSelectList { get; set; }
        public SelectList WarrantyPeriodUnitsSelectList { get; set; }

        public virtual ICollection<AssetPurchaseDetail> AssetPurchaseDetails { get; set; }
        public virtual ICollection<AssetPurchaseDetailSerialNumber> AssetPurchaseDetailSerialNumbers { get; set; }
    }
}
