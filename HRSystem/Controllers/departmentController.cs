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
    [Authorize]
    public class departmentController : Controller
    {



        Idepartmentservice departmentservice;
       
        public departmentController(Idepartmentservice _Idepartmentservice)
        {
            departmentservice = _Idepartmentservice;


        }

        public IActionResult Index()
        {
            ViewData["IsEdited"] = false;
            return View("newdepartment" );
        }




        public IActionResult save (department dept) 
        {
            departmentservice.insert(dept);

            return View("newdepartment");
        }


        public IActionResult update(department d)

        {
           
            departmentservice.update(d);
            ViewData["IsEdited"] = true;

            return View("newdepartment", d);

        }
        public IActionResult deptsearch()
        {
            List<department> li = departmentservice.loadall();

            return View("departmentlist",li);

        }

        public IActionResult edit(int id)

        {

            department dept = new department();
            department department = departmentservice.load(id);
            dept = department;

            ViewData["IsEdited"] = true;
            return View("newdepartment", dept);

        }



        public IActionResult search()
        {

            string name = Request.Form["txtname"];
            List<department> li = departmentservice.loadbyname(name);

            return View("departmentlist",li);


        }
        public IActionResult delete(int id)
        {


            departmentservice.delete(id);
            List<department> li = departmentservice.loadall();
            return View("departmentlist", li);
        }
       

    }
}
