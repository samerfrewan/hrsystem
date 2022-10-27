using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HRSystem.Controllers;

namespace HRSystem.data
{
    [Table("cities")]
    public class city
    {
        public int id { set; get; }
        [Required]
        public string name { set; get; }

       

        [ForeignKey("country")]
        public int country_id { set; get; }
        public country country { set; get; }



        public List<employee> liemployee { set; get; }

       

    }
}
