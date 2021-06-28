using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CheckUserRole.Models
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Minimum Length of RoleName should be 3")]
       public string RoleName { get; set; }

        public ICollection<Users> Users { get; set; }

    }
}
