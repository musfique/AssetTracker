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
    public class GeneralCategory
    {
        [Key]
        public int GeneralCategoryID { get; set; }
        [Required]
        [Display(Name = "Name")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(150)]
        [Remote("IsGeneralCategoryNameAvailable", "GeneralCategory", AdditionalFields = "GeneralCategoryID", HttpMethod = "Post", ErrorMessage = "Name already exist")]
        public string GeneralCategoryName { get; set; }

        [Required]
        [Display(Name = "Code")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(2,MinimumLength = 2)]
        [Remote("IsGeneralCategoryCodeAvailable", "GeneralCategory", AdditionalFields = "GeneralCategoryID", HttpMethod = "Post", ErrorMessage = "Code already exist")]
        public string GeneralCategoryCode { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
