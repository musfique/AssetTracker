using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Core.Models.EntityModel {
    public class Employee {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(150)]
        [Display(Name = "Name")]
        public string EmployeeName { get; set; }

        [Required]
        [Display(Name = "Designation")]
        public int DesignationID { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(25)]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(70)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        public Department Department { get; set; }
        public Designation Designation { get; set; }

    }
}
