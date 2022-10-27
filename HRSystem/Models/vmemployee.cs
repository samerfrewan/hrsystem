using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRSystem.data;
namespace HRSystem.Models
{
    public class vmemployee
    {
        public employee employee { set; get; }

        public List<department> lidepartment { set; get; }
        public List<country> licountry { set; get; }

        public List<city> licity { set; get; }


    }
}
