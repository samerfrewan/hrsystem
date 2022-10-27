using HRSystem.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSystem.service
{
   public interface Idepartmentservice
    {
        void insert(department department);
        List<department> loadall();
        List<department> loadbyname(string name);
        void delete(int id);
        department load(int id);
        void update(department department);

    }
}
