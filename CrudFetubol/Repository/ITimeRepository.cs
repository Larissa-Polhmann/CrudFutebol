using CrudFutebol.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudFutebol.Repository
{
    interface ITimeRepository
    {
        int Add(Time time);
        List<Time> GetTimes();
        Time Get(int id);
        int Edit(Time time);
        int Delete(int id);
    }
}
