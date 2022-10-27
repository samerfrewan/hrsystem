using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRSystem.data;
namespace HRSystem.service
{
    public class departmentservice : Idepartmentservice
    {


        hrcontext context;
        public departmentservice(hrcontext _context)
        {
            context = _context;

        }


        public void insert(department department)
        {

            context.departments.Add(department);
            context.SaveChanges();

        }
        public void update(department department)
        {

            context.departments.Attach(department);
            context.Entry(department).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

        }

        public List<department> loadall()
        {
            List<department> li = context.departments.ToList();



            return li;
        }
        public List<department> loadbyname(string name)
        {

            List<department> li = context.departments.Where(p => p.name == name).ToList();

            return li;
        }

        public void delete(int id)
        {
           department department = context.departments.Find(id);
            context.departments.Remove(department);
            context.SaveChanges();


        }
        public department load(int id)
        {

            return context.departments.Find(id);

        }
    }
}
