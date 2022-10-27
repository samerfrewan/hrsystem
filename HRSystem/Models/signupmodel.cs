using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRSystem.Models
{
    public class signupmodel
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string  Bdate { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        [Compare("confirmpassword")]
        public string password { get; set; }
        [Required]
        public string confirmpassword { get; set; }

    }
}
