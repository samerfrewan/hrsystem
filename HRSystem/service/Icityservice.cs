using HRSystem.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSystem.service
{
    public interface Icityservice
    {

        void insert(city city);
        List<city> loadall();
        List<city> loadbyname(string name);
        List<city> loadcites(int country_id);
    }
}
