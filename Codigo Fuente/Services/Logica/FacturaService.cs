using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logica
{
    public class FacturaService
    {
        FacturaRepository FacturaRepository;

        public FacturaService(string connectionString)
        {
            FacturaRepository = new FacturaRepository(connectionString);
        }
        public List<FacturaModel> list()
        {

            return FacturaRepository.list();

        }

        public bool add(FacturaModel modelo)
        {
            if (validacionFactura(modelo))
                return FacturaRepository.add(modelo);
            else
                return false;
        }

        public bool edit(FacturaModel modelo)
        {
            return FacturaRepository.update(modelo);

        }
        public bool delete(int id)
        {
            return FacturaRepository.remove(id);

        }


        private bool validacionFactura(FacturaModel Factura)
        {
            if (Factura == null)
                return false;
            if(string.IsNullOrEmpty(Factura.Nro_factura))
                return false;
            return true;
        }
    }
}
