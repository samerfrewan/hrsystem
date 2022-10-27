using HRSystem.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSystem.service
{
      public interface Iemployeeservice
    {

        void insert(employee employee);
        List<employee> loadall();
        List<employee> loadbyname(string name);
        void delete(int id);
        List<employee> loaddept(int dept_id);
        employee load(int id);
        void update(employee employee);
    }
}
