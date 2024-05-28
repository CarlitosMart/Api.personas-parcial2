using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public interface IFactura
    {
        bool add(FacturaModel Cliente);
        bool remove(int id);
        bool update(FacturaModel Cliente);
        FacturaModel get(int id);
        List<FacturaModel> list();
    }
}
