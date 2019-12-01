using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic
{
    public class Pagos
    {

        public static PagosRealizados AgregarPago(PagosRealizados pago)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {

                    db.PagosRealizados.Add(pago);
                        db.SaveChanges();
                        return pago;
                    
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
                PagosRealizados p = db.PagosRealizados.Find(pago.ID);
                p.monto = pago.monto;
                p.fecha = pago.fecha;
                p.descuento = pago.descuento;
                p.montoDescuento = pago.montoDescuento;
                p.IDUsuario = pago.IDUsuario;
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

        public static List<PagosRealizados> listarPagos()
        {
            List<PagosRealizados> lista = new List<PagosRealizados>();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    lista = db.PagosRealizados.ToList();

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
