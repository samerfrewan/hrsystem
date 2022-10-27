using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.data
{
    [Table("departments")]
    public class department
    {
       

        public int id { set; get; }

      [Required]
        public string name { set; get; }
        [Required]
        public string description { set; get; }


      


    }
}
