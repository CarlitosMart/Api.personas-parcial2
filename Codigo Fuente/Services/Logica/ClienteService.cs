using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logica
{
    public class ClienteService
    {
        ClienteRepository ClienteRepository;

        public ClienteService(string connectionString)
        {
            ClienteRepository = new ClienteRepository(connectionString);
        }

        public List<ClienteModel> list()
        {
            
            return ClienteRepository.list();
           
        }
        public bool add(ClienteModel modelo)
        {
            if (validacionCliente(modelo))
                return ClienteRepository.add(modelo);
            else
                return false;
        }


        public bool edit(ClienteModel modelo)
        {
            return ClienteRepository.update(modelo);

        }
        public bool delete(int id)
        {
            return ClienteRepository.remove(id);

        }


        private bool validacionCliente(ClienteModel Cliente)
        {
            if (Cliente == null)
                return false;
            if(string.IsNullOrEmpty(Cliente.Nombre))
                return false;
            return true;
        }
    }
}
