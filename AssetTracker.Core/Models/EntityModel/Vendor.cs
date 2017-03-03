using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AssetTracker.Core.Models.EntityModel
{
    public class Vendor
    {
        [Key]
        public int VendorID { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(150)]
        [Display(Name = "Vendor's Name")]
        [Remote("IsVendorNameAvailable", "Vendor", AdditionalFields = "VendorID",ErrorMessage = "Name Already Exist",HttpMethod = "POST")]
        public string VendorName { get; set; }

    }
}
