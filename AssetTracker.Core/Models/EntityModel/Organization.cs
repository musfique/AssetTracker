using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AssetTracker.Core.Models
{
    public class Organization
    {
        [Key]
        public int OrganizationID { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(150)]
        [Display(Name = "Name")]
        [Remote("IsNameAvilable", "Organization", AdditionalFields = "OrganizationID", ErrorMessage = "Name Already Exist", HttpMethod = "POST")]
        public string OrganizationName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(3,MinimumLength = 3)]
        [Display(Name = "Short Name")]
        [Remote("IsShortNameAvilable", "Organization", AdditionalFields = "OrganizationID", ErrorMessage = "Short Name Already Exist", HttpMethod = "POST")]

        public string OrganizationShortName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(150)]
        [Display(Name = "Location")]
        public string OrganizationLocation { get; set; }

        public virtual ICollection<OrganizationBranch> OrganizationBranches { get; set; }
        
    }
}
