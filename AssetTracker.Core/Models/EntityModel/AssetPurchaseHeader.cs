using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Core.Models.EntityModel
{
    public class AssetPurchaseHeader
    {
        [Key]
        public int AssetPurchaseHeaderID { get; set; }

        [Required]
        [Display(Name = "Vendor")]
        public int VendorID { get; set; }

        [Required]
        [Display(Name = "Purchased Date")]
        public DateTime PurchasedDate { get; set; }

        [Required]
        [Display(Name = "Purchased By")]
        public int PurchasedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public int CreatedBy { get; set; }

        public int OrganizationBranchID { get; set; }

        public OrganizationBranch OrganizationBranch { get; set; }
        public ICollection<AssetPurchaseDetail> AssetPurchaseDetails { get; set; }
    }
}
