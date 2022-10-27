using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRSystem.data;
 using HRSystem.Models;
using HRSystem.service;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace HRSystem.Controllers
{
     
    public class employeeController : Controller
    {

        Icountryservice countryservice;
        Icityservice cityservice;
        Idepartmentservice departmentservice;
        Iemployeeservice employeeservice;
        IConfiguration config;
        public employeeController(Iemployeeservice _iemployeeservice, Idepartmentservice _idepartmentservice, Icityservice _icityservice, Icountryservice _icountryservice ,IConfiguration _config)
        {

           
            countryservice = _icountryservice;
            cityservice = _icityservice;
            departmentservice = _idepartmentservice;
            employeeservice = _iemployeeservice;
            config = _config;
        }


        public IActionResult Index()
        {
            vmemployee vm = new vmemployee();

            vm.licity = cityservice.loadall();
            vm.licountry = countryservice.loadall();
            vm.lidepartment = departmentservice.loadall();

            ViewData["IsEdited"] = false;
            return View("newemployee" ,vm);


        }


        public IActionResult save(vmemployee vm)

        {
            if (ModelState.IsValid == true)
            {
                string name = Guid.NewGuid().ToString() + "." + vm.employee.image.FileName.Split('.')[1];
                string path = Path.Combine(Directory.GetCurrentDirectory(), config["ImageFolderName"], name);
                vm.employee.image.CopyTo(new FileStream(path, FileMode.Create));
                vm.employee.path = name;
            }
            employeeservice.insert(vm.employee);
        


            vm.licity = cityservice.loadall();
            vm.licountry = countryservice.loadall();
            vm.lidepartment = departmentservice.loadall();

            ViewData["IsEdited"] = false;
            return View("newemployee", vm);

        }

        public IActionResult update(vmemployee vm)

        {
            if (ModelState.IsValid == true)
            {
                if(vm.employee.image !=null)
                {
                string name = Guid.NewGuid().ToString() + "." + vm.employee.image.FileName.Split('.')[1];
                string path = Path.Combine(Directory.GetCurrentDirectory(), config["ImageFolderName"], name);
                vm.employee.image.CopyTo(new FileStream(path, FileMode.Create));
                vm.employee.path = name;
                }
            }
            employeeservice.update(vm.employee);



            vm.licity = cityservice.loadall();
            vm.licountry = countryservice.loadall();
            vm.lidepartment = departmentservice.loadall();

            ViewData["IsEdited"] = true;
            return View("newemployee", vm);

        }


        public IActionResult empsearch()
        {
            List<employee> li = employeeservice.loadall();
            return View("employeelist",li);
 
        }


        public IActionResult search()
        {

            string name = Request.Form["txtfirstname"];
            List<employee> li = employeeservice.loadbyname(name);

            return View("employeelist",li);

        }

        public IActionResult delete(int id)
        {

            
            employeeservice.delete(id);
            List<employee> li = employeeservice.loadall();
            return View("employeelist",li);
        }

        public IActionResult loaddept(int dept_id)
        {
         List<employee> li=   employeeservice.loaddept(dept_id);

            return View("employeelist",li);
        }

        public IActionResult edit(int id)
        {
            vmemployee vm = new vmemployee();
            employee  employee=employeeservice.load(id);
            vm.employee = employee;



            vm.licity = cityservice.loadall();
            vm.licountry = countryservice.loadall();
            vm.lidepartment = departmentservice.loadall();

            ViewData["IsEdited"] = true;

            return View("newemployee", vm);
        }

        public IActionResult loadcity(int country_id)

        {

          List<city> li =  cityservice.loadcites(country_id);
            return Json(li);
        }
    }
}
