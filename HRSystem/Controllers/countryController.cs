using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRSystem.data;
using HRSystem.Models;
using HRSystem.service;
using Microsoft.AspNetCore.Authorization;

namespace HRSystem.Controllers
{
   
    public class countryController : Controller
    {

        Icountryservice countryservice;
        public countryController(Icountryservice _icountryservice)
        {
            countryservice =_icountryservice;
        
        
        }
        public IActionResult Index()
        {
          
            return View("newcountry");
        }


        public IActionResult save(country count)
        {

            countryservice.insert(count);

          
            return View("newcountry");
        }


        public IActionResult countrysearch()
        {

            List<country> li = countryservice.loadall();


            return View("countrylist",li);
        }




        public IActionResult search()
        {
            string name = Request.Form["txtname"];
            List<country> li = countryservice.loadbyname(name);

            return View("countrylist",li);
        }

    }
}
