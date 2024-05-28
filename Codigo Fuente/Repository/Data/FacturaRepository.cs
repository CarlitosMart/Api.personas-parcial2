using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repository.Models.BD;

namespace Repository.Data
{
    public class FacturaRepository : IFactura
    {
        private IDbConnection conexionDB;
        private ClientesDbContext db = new ClientesDbContext();
        public FacturaRepository(string _connectionString)
        {
            conexionDB = new DbConection(_connectionString).dbConnection();
        }
        public bool add(FacturaModel m)
        {
            try
            {
                db.Facturas.Add(new Models.BD.Factura { IdCliente = m.Id_cliente, NroFactura = m.Nro_factura, FechaHora = m.Fecha_hora, Total = m.Total, TotalIva5 = m.Total_iva5, TotalIva10 = m.Total_iva10, TotalIva = m.Total_iva, TotalLetras = m.Total_letras, Sucursal = m.Sucursal });
            db.SaveChanges();
            return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool update(FacturaModel m)
        {
            try
            {
                Factura c = db.Facturas.Find(m.Id);
                db.Entry(c).State = EntityState.Modified;
                c.IdCliente = m.Id_cliente; c.NroFactura = m.Nro_factura; c.FechaHora = m.Fecha_hora; c.Total = m.Total; c.TotalIva5 = m.Total_iva5; c.TotalIva10 = m.Total_iva10; c.TotalIva = m.Total_iva; c.TotalLetras = m.Total_letras; c.Sucursal = m.Sucursal;
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
                Factura c = db.Facturas.Find(id);
                db.Facturas.Remove(c);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FacturaModel get(int id)
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
        public List<FacturaModel> list()
        {
            string connectionString = this.conexionDB.ConnectionString;
            string query = "SELECT * FROM Factura";

            List<FacturaModel> r = new List<FacturaModel>();
            try
            {
                foreach (Factura reader in db.Facturas)

                {
                    r.Add(new FacturaModel
                    {
                        Id = Convert.ToInt32(reader.Id),
                        Id_cliente = Convert.ToInt32(reader.IdCliente),
                        Nro_factura = reader.NroFactura,
                        Fecha_hora = reader.FechaHora.ToString(),
                        Total = reader.Total.ToString(),
                        Total_iva5 = reader.TotalIva5.ToString(),
                        Total_iva10 = reader.TotalIva10.ToString(),
                        Total_iva = reader.TotalIva.ToString(),
                        Total_letras = reader.TotalLetras.ToString(),
                        Sucursal = reader.Sucursal.ToString(),
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
