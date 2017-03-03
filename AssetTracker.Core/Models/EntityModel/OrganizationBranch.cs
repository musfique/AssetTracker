using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.Models.EntityModel;

namespace AssetTracker.Core.Models
{
    public class OrganizationBranch
    {
        [Key]
        public int OrganizationBranchID { get; set; }
        [Required]
        [Display(Name = "Organization")]
        public int OrganizationID { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        [Display(Name = "Branch Name")]
        public string OrganizationBranchName { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        [Display(Name = "Branch Short Name")]
        public string OrganizatioBranchShortName { get; set; }

        public virtual  Organization Organization { get; set; }
        public virtual ICollection<AssetLocation> AssetLocations { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
       
    }
}
