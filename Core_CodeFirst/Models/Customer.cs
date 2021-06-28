using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Core_CodeFirst.Models
{
    public class Customer
    {
        [Key]
        public int  CustomerRowId { get; set; }
        [Required]
        [StringLength(10)]
        public string CustomerId { get; set; }
        [Required]
        [StringLength(20)]
        [ConcurrencyCheck]
        public string CustomerName { get; set; }
        [Required]
        [StringLength(30)]
        public string Address { get; set; }
        [Required]
        [StringLength(10)]
        public string City { get; set; }
        [Required]
        public int Age { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
