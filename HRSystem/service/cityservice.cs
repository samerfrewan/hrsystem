using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRSystem.data;
namespace HRSystem.service
{
    public class cityservice :Icityservice
    {


        hrcontext context;
        public cityservice(hrcontext _context)
        {
            context = _context;

        }

        public void insert(city city)
        {

            context.cities.Add(city);
            context.SaveChanges();

        }
        public List<city> loadall()
        {
            List<city> lic = context.cities.ToList();

            

            return lic;
        }


        public List<city> loadbyname(string name)
        {

            List<city> li = context.cities.Where(p => p.name == name).ToList();
            return li;
        }
        public List<city> loadcites(int country_id)
        {


           return context.cities.Where(c =>c. country_id == country_id).ToList();

        }
    }
}
