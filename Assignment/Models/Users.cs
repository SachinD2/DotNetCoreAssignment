using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CheckUserRole.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Minimum Length of Username should be 3")]
        public string UserName { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Minimum Length of Email should be 12")]
       // [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage ="Minimum Length of Password should be 8")]
       //  [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        public string Password { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Minimum Length of Confirm Password should be 8")]
        public string ConfirmPassowrd { get; set; }
        [Required]
        public int RoleId { get; set; }

        public Roles Roles { get; set; }
    }
}
