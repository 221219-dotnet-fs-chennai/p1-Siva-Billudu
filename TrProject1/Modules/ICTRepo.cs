using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    public interface ICTRepo<T>
    {
        T AddContact(T TrContact);

        List<T> GetAllSivaContact();

    }
}
