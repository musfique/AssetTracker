using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Core.Models
{
    public class DetailCategory
    {
        [Key]
        public int DetailCategoryID { get; set; }

        [Required]
        [Display(Name = "Sub Category")]
        public int SubCategoryID { get; set; }

        [Required]
        [Display(Name = "Name")]
        [Column(TypeName = "VARCHAR")]
        public string DetailCategoryName { get; set; }
        [Required]
        [Display(Name = "Code")]
        [Column(TypeName = "VARCHAR")]
        public string DetailCategoryCode { get; set; }

        [Required]
        [Display(Name = "Description")]
        [Column(TypeName = "VARCHAR")]
        public string DetailCategoryDescription { get; set; }
        
        public virtual SubCategory SubCategory { get; set; }
    }
}
