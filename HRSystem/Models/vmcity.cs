using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRSystem.data;
using HRSystem.Controllers;
namespace HRSystem.Models
{
    public class vmcity
    {
        public city city { set; get; }

        public List<city> licity { set; get; }

        public List<country> licountry { set; get; }

    }
}
