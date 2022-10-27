using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSystem.Models
{
    public class Applicationuser:IdentityUser
    {
        public string Name { get; set; }
        public string Bdate { get; set; }

    }
}
