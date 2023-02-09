using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    public  interface IRepo<T>
    {
        T Add(T TrDetails);

        List<T> GetAllSivaDetail();

        T Update(T TrDetails);

 }
}
