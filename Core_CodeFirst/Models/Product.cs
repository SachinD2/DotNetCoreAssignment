using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core_CodeFirst.Models
{
    public class Product
    {
        [Key]
        public int ProductRowId { get; set; }
        [Required]
        [StringLength(10)]
        public string ProductId { get; set; }
        [Required]
        public string VendorId { get; set; } // Foreign key from vendor class
        [Required]
        [StringLength(10)]
        [ConcurrencyCheck]
        public string ProductName { get; set; }
        [Required]
        [StringLength(10)]
        public string CategoryName { get; set; }
        [Required]
        public int UnitPrice { get; set; }

        public Vendor Vendor { get; set; }
    }
}
