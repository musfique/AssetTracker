using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AssetTracker.Core.Models.EntityModel {
    public class Department 
    {
        public int DepartmentID { get; set; }
        [Required]
        [Display(Name = "Branch")]
        public int OrganizationBranchID { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        [Column(TypeName = "VARCHAR")]
        //[Remote("IsDepartmentAvailable","Department" ,AdditionalFields = "OrganizationBranchID",ErrorMessage = "Department Already Exists")]
        public string DepartmentName { get; set; }

        public virtual OrganizationBranch OrganizationBranch { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
