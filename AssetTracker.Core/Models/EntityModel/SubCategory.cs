using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Core.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryID { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "Name")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(150)]
        public string SubCategoryName { get; set; }

        [Required]
        [Display(Name = "Code")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(150)]
        public string SubCategoryCode { get; set; }

        [Required]
        [Display(Name = "Description")]
        [Column(TypeName = "VARCHAR")]
        public string SubCategoryDescription { get; set; }

        public virtual  Category Category { get; set; }
        public virtual ICollection<DetailCategory> DetailCategories { get; set; }


    }
}
