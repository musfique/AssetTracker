using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Core.Models.EntityModel
{
    public class AssetPurchaseDetail
    {
        [Key]
        public int AssetPurchaseDetailID { get; set; }

        [Required]
        public int AssetPurchaseHeaderID { get; set; }

        [Required]
        [Display(Name = "Product Category")]
        public int ProductCategoryID { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public double Quantity { get; set; }

        [Required]
        [Display(Name = "Unit Price")]
        public double UnitPrice { get; set; }

        public bool IsWarranty { get; set; }

        [Required]
        [Display(Name = "Warranty Period")]
        public double WarrantyPeriod { get; set; }

        [Required]
        [Display(Name = "Warranty Period Unit")]
        public double WarrantyPeriodUnitID { get; set; }

        public virtual WarrantyPeriodUnit WarrantyPeriodUnit { get; set; }
        public virtual AssetPurchaseHeader AssetPurchaseHeader { get; set; }
        public virtual ICollection<AssetPurchaseDetailSerialNumber> AssetPurchaseDetailSerialNumbers { get; set; }
    }
}
