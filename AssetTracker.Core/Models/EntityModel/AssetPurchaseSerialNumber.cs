using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Core.Models.EntityModel {
    public class AssetPurchaseSerialNumber 
    {
        public int AssetPurchaseSerialNumberID { get; set; }
        [Required]
        public int PerchaseDetailID { get; set; }
        [Required]
        public string SerialNumber { get; set; }
    }
}
