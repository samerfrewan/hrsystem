using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HRSystem.helpers;
using Microsoft.AspNetCore.Http;

namespace HRSystem.data
{
    [Table("employees")]
    public class employee
    {
        public int id { set; get; }
        [Required]
        public string firstname { set; get; }
        [Required]
        public string lastname { set; get; }
        [Required]
        public string phone { set; get; }
        [Required]
        public string gender { set; get; }
        [Required]
        public string email { set; get; }
        [Required]
        public double salary { set; get; }
        [Required]
        public double expectedsalary { set; get; }
        [HierdateValidation]
        public DateTime hiredate { set; get; }
        [Required]
        public string address { set; get; }

        public string path { set; get; }

        [NotMapped]
        public IFormFile image { set; get; }



        [ForeignKey("country")]
        public int country_id
        {
            set; get;

        }

        public country country { set; get; }



        [ForeignKey("city")]
        public int city_id
        {
            set; get;

        }
        public city city { set; get; }




        [ForeignKey("department")]
        public int department_id
        {
            set; get;

        }
        public department department { set; get; }

    }
}
