using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HRSystem.Controllers;

namespace HRSystem.data
{
    [Table("countries")]
    public class country
    {
        public int id { set; get; }

        [Required]
        public string name { set; get; }
        [Required]
        public int code { set; get; }



        public List<city> licity { set; get; }

        public List<employee> liemployee { set; get; }


    }
}
