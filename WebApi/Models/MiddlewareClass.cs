using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Assign.Models
{
    public class MiddlewareClass
    {
        [Key]
        public int LogId { get; set; }

        [Required]
        public string LogGUID { get; set; }
        [Required]
        public DateTime Request{ get; set; }
        [Required]
        public string ControllerName { get; set; }
        [Required]
        public string ActionName { get; set; }
        [Required]
        public string Exception { get; set; }
    }
}
