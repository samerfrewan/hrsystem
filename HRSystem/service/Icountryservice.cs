using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRSystem.data;
namespace HRSystem.service
{
    public interface Icountryservice
    {
        void insert(country country);
        List<country> loadall();
        List<country> loadbyname(string name);

    }
}
