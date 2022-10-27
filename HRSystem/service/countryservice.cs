using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRSystem.data;
namespace HRSystem.service
{
    public class countryservice:Icountryservice
    {

        hrcontext context;
        public countryservice(hrcontext _context)
        {
            context =_context;

        }

        public void insert( country country)
        {

            context.countries.Add(country);
            context.SaveChanges();

        }

        public List<country> loadall()
        {
            List<country> li = context.countries.ToList();
                           

            return li;
        }


        public List<country> loadbyname(string name)
        {

            List<country> li = context.countries.Where(p=>p.name == name).ToList();
                            
                          
            return li;
        }
    }
}
