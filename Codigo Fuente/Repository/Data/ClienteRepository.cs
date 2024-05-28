using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Extension;
using Repository.Models.BD;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using Repository.Models.BD;


namespace Repository.Data
{
    public class ClienteRepository : ICliente
    {
        private IDbConnection conexionDB;
        public ClienteRepository(string _connectionString)
        {
            conexionDB = new DbConection(_connectionString).dbConnection();
        }
        private ClientesDbContext db = new ClientesDbContext();

        // GET: api/CLIENTE

        public IQueryable<Cliente> GetCLIENTE()
        {

            return db.Clientes;
        }
        public bool add(ClienteModel m)
        {
            try
            {
                db.Clientes.Add(new Models.BD.Cliente { IdBanco = "1", Nombre =m.Nombre, Apellido=m.Apellido, Celular= m.Celular, Direccion= m.Direccion, Mail = m.Mail, Documento = m.Documento, Estado=m.Estado });
                db.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool update(ClienteModel m)
        {
            try
            {
                Cliente c = db.Clientes.Find(m.Id);
                db.Entry(c).State = EntityState.Modified;
                c.Nombre = m.Nombre; c.Apellido = m.Apellido; c.Celular = m.Celular; c.Direccion = m.Direccion; c.Documento = m.Documento; c.Estado = m.Estado;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool remove(int id)
        {
            try
            {
                Cliente c = db.Clientes.Find(id);
                db.Clientes.Remove(c);
                db.SaveChanges();
                return true;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteModel get(int id)
        {
            try
            {
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ClienteModel> list()
        {
            List<ClienteModel> r = new List<ClienteModel>();
            try
            {
                            foreach (Cliente reader in db.Clientes)

                            {
                                r.Add(new ClienteModel {
                                    Id = Convert.ToInt32(reader.Id),
                                    Id_banco = reader.IdBanco,
                                    Nombre = reader.Nombre.ToString(),
                                    Apellido = reader.Apellido.ToString(),
                                    Documento = reader.Documento.ToString(),
                                    Direccion = reader.Direccion.ToString(),
                                    Mail = reader.Mail.ToString(),
                                    Celular = reader.Celular.ToString(),
                                    Estado = reader.Estado.ToString(),
                                });


                            }


            }
            catch (Exception)
            {
            }


            return r;

            //throw new NotImplementedException();
        }
        


    }
}
