using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;

namespace DataLogic
{
    public class Envios
    {
        public static List<Mensaje> listarMensajes()
        {
            List<Mensaje> lista = new List<Mensaje>();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    lista = db.Mensaje.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lista;
        }

        public static void AgregarNotificaciones(string titulo, string msj)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    db.insertNotificaciones(titulo,msj);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AgregarRefe(referenciaUsuarios_referenciaNotificaciones refe)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    db.referenciaUsuarios_referenciaNotificaciones.Add(refe);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




    }
}
