using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public interface ICliente
    {
        bool add(ClienteModel Cliente);
        bool remove(int id);
        bool update(ClienteModel Cliente);
        ClienteModel get(int id);
        List<ClienteModel> list();
    }
}
