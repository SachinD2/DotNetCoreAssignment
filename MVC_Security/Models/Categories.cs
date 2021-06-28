using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Security.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public int CategoryRowId { get; set; }
        [Required(ErrorMessage = "Category Id is required")]
        public string CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is required")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Base Price is required")]
        //  [NumericValidator(ErrorMessage = "Base Price annot be -ve")]
        public int BasePrice { get; set; }
        [Required(ErrorMessage = "Sub Category Name is required")]
        public string SubCategoryName { get; set; }


        public virtual ICollection<Products> Products { get; set; }
    }



    public class NumericValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (Convert.ToInt32(value) < 0)
            {
                return false;
            }
            return true;
        }
    }
}

