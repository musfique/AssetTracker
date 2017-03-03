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
    public class Designation
    {
        [Key]
        public int DesignationID { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(150)]
        [Display(Name = "Designation Name")]
        [Remote("IsDesignationAvailable", "Designation", AdditionalFields = "DesignationID", HttpMethod = "Post", ErrorMessage = "Designation Already Exist")]
        public string DesignationName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
