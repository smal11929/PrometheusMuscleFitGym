using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prototipos.Models;
using System.Threading.Tasks;

namespace DataLogic
{
    public class Pagos
    {

        public static PagosRealizados AgregarPago(PagosRealizados pago, int cedula)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    var id = db.BuscarIdPorCedula(cedula).FirstOrDefault();

                    if (id == null)
                    {
                        pago = new PagosRealizados();
                        return pago;
                    }
                    else
                    {
                        db.insertPagosRealizados(pago.monto,
                        pago.fecha,
                        pago.descuento,
                        pago.montoDescuento,
                        pago.IDUsuario = Convert.ToInt32(id));

                        db.SaveChanges();
                        return pago;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static PagosRealizados modificarPago(PagosRealizados pago)
        {
            PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();

            try
            {
                db.updatePagosRealizados(pago.ID,
                pago.monto,
                pago.fecha,
                pago.descuento,
                pago.montoDescuento,
                pago.IDUsuario);

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return pago;
        }

        public static PagosRealizados visualizarModificarPago(int? id)
        {
            PagosRealizados pago = new PagosRealizados();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    pago = db.PagosRealizados.Find(id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return pago;
        }

        public static List<PagosRealizados_Usuarios> listarPagos()
        {
            List<PagosRealizados_Usuarios> lista = new List<PagosRealizados_Usuarios>();
            List<PagosRealizados> pagosRealizados = new List<PagosRealizados>();
            List<Usuarios> usuarios = new List<Usuarios>();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                   
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public static void eliminarPago(int id)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    db.eliminarPagoRealizado(id);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int getUsu(int? id)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    Usuarios usu = db.Usuarios.Where(x => x.ID == id).FirstOrDefault();
                    return usu.cedula;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
