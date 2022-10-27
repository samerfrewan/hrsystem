using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRSystem.data;

namespace HRSystem.service
{
    public class employeeservice :Iemployeeservice
    {
        hrcontext context;
        public employeeservice(hrcontext _context)
        {
            context = _context;

        }

        public void insert(employee employee)
        {

            context.employees.Add(employee);
            context.SaveChanges();

        }
        public void update(employee employee)
        {

            context.employees.Attach(employee);
            context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

        }

        public List<employee> loadall()
        {
            List<employee> li = context.employees.ToList();
                                  
            return li;
        }

        public List<employee> loadbyname(string name)
        {

            List<employee> li = context.employees.Where (p=>p.firstname == name).ToList();
            
            return li;
        }

        public void delete(int id)
        {
            employee employee = context.employees.Find(id);
            context.employees.Remove(employee);
            context.SaveChanges();

        }

        public List<employee> loaddept(int dept_id)
        {

            return context.employees.Where(d => d.department_id == dept_id).ToList();
        }

        public employee load(int id)
        {

            return context.employees.Find(id);

        }
    }


}
