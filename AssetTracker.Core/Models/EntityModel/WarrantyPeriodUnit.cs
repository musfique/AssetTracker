using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Core.Models.EntityModel {
    public class WarrantyPeriodUnit {
        [Key]
        public int WarrantyPeriodUnitID { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(150)]
        public string WarrantyPeriodUnitName { get; set; }

    }
}
