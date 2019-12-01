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
        public static List<Mensaje> listarMensajes(int id)
        {
            List<Mensaje> lista = new List<Mensaje>();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    lista = db.Mensaje.Where(x=> x.IDReceptor==id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lista;
        }

        public static void agregarMensaje(Mensaje mensaje)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    db.Mensaje.Add(mensaje);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int AgregarNotificaciones(Notificaciones noti)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    Notificaciones notificacion=db.Notificaciones.Add(noti);
                    db.SaveChanges();
                    return notificacion.ID;
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

        public static List<Notificaciones> getNotificaciones()
        {
            try
            {
                List<Notificaciones> lista;
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    lista=db.Notificaciones.AsQueryable().ToList();
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void deleteNotificaciones(int id)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    List<referenciaUsuarios_referenciaNotificaciones> lista = db.referenciaUsuarios_referenciaNotificaciones.Where(x => x.IDNotificacion == id).ToList();
                    db.referenciaUsuarios_referenciaNotificaciones.RemoveRange(lista);
                    Notificaciones noti = db.Notificaciones.Find(id);
                    db.Notificaciones.Remove(noti);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void updateNotificaciones(Notificaciones noti)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    Notificaciones n = db.Notificaciones.Find(noti.ID);
                    n.mensaje = noti.mensaje;
                    n.titulo = noti.titulo;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Notificaciones getNotificacion(int id)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    Notificaciones n = db.Notificaciones.Find(id);
                    return n;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
