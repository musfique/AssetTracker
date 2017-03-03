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
    public class Category
    {
        public int CategoryID { get; set; }
        [Required]
        [Display(Name = "General Category")]
        public int GeneralCategoryID { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(150)]
        [Display(Name = "Name")]
        public string CategoryName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(3,MinimumLength = 3)]
        [Display(Name = "Code")]
        public string CategoryCode { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Description")]
        public string CategoryDescription { get; set; }

        public virtual GeneralCategory GeneralCategory { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
