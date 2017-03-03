using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.Models.Interfaces.IModel;

namespace AssetTracker.Core.Models.EntityModel
{
    public class AssetPurchaseHeader:IAudit
    {
        [Key]
        public int AssetPurchaseHeaderID { get; set; }

        [Required]
        [Display(Name = "Vendor")]
        public int VendorID { get; set; }

        [Required]
        [Display(Name = "Purchased Date")]
        public DateTime PurchasedOn { get; set; }

        [Required]
        [Display(Name = "Purchased By")]
        public int PurchasedBy { get; set; }

        public int OrganizationBranchID { get; set; }

        public OrganizationBranch OrganizationBranch { get; set; }
        public ICollection<AssetPurchaseDetail> AssetPurchaseDetails { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
