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
  
    public class cityController : Controller
    {

        Icountryservice countryservice;
        Icityservice cityservice;
        public cityController(Icountryservice _Icountryservice, Icityservice _icityservice)
        {
            countryservice = _Icountryservice;
            cityservice= _icityservice;


        }



        public IActionResult Index()
        {

            vmcity vm = new vmcity();
            vm.licountry = countryservice.loadall();

            return View("newcity",vm);
        }



        public IActionResult save(vmcity vm)
        {


            cityservice.insert(vm.city);
            vm.licountry = countryservice.loadall();

            return View("newcity",vm);

        }

        public IActionResult citysearch()
        {
            List<city> li = cityservice.loadall();
            return View("citylist",li);
        }




        public IActionResult search()
        {

            string name = Request.Form["txtname"];
            List<city> li= cityservice.loadbyname(name);
         

            return View("citylist",li);
        }


    }
}
