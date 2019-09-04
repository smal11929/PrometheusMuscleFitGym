
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic
{
    public class Publicar
    {
        #region Mantenimientos por ID
        public static Noticias visualizarMantenimientoNoticias(int? id)
        {
            Noticias noti = new Noticias();

            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    noti = db.Noticias.Find(id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return noti;
        }

        public static Eventos visualizarMantenimientoEventos(int? id)
        {
            Eventos eve = new Eventos();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    eve = db.Eventos.Find(id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return eve;
        }

        public static Ofertas visualizarMantenimientoOfertas(int? id)
        {
            Ofertas ofe = new Ofertas();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    ofe = db.Ofertas.Find(id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return ofe;
        }
        #endregion

        #region Listado de Mantenimientos
        public static List<Noticias> listarNoticias()
        {
            List<Noticias> lista = new List<Noticias>();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    lista = db.Noticias.ToList();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lista;
        }

        public static List<Eventos> listarEventos()
        {
            List<Eventos> lista = new List<Eventos>();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    lista = db.Eventos.ToList();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lista;
        }

        public static Eventos listarEventosComentar(int? id)
        {
            Eventos lista = new Eventos();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    lista = db.Eventos.Find(id);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lista;
        }

        public static Noticias listarNoticiasComentar(int? id)
        {
            Noticias lista = new Noticias();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    lista = db.Noticias.Find(id);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lista;
        }

        public static Ofertas listarOfertasComentar(int? id)
        {
            Ofertas lista = new Ofertas();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    lista = db.Ofertas.Find(id);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lista;
        }

        public static List<Ofertas> listarOfertas()
        {
            List<Ofertas> lista = new List<Ofertas>();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    lista = db.Ofertas.ToList();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lista;
        }

        public static List<Notificaciones> listarNotificaciones(int id)
        {
            List<Notificaciones> lista = new List<Notificaciones>();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    foreach(referenciaUsuarios_referenciaNotificaciones refe in db.referenciaUsuarios_referenciaNotificaciones.ToList())
                    {
                        if (refe.IDUsuario == id)
                        {
                            lista.Add(db.Notificaciones.Find(refe.IDNotificacion));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                 throw ex;
            }
            return lista;
        }


        #endregion

        #region Agregar a Base de datos
        public static void AgregarOferta(Ofertas etOferta)
        {
            PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();
            try
            {
                db.insertOfertas(etOferta.titulo,
                etOferta.descripcion,
                etOferta.monto,
                etOferta.porcentaje,
                etOferta.fechaInicio,
                etOferta.fechaFin,
                etOferta.imagen);

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static void AgregarNoticia(Noticias noti)
        {
            PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();
            try
            {
                db.insertNoticias(noti.titulo,
                noti.contenido,
                noti.fechaRealizacion,
                noti.imagen);

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static void AgregarEvento(Eventos eve)
        {
            PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();
            try
            {
                db.insertEventos(eve.nombre,
                eve.descripcion,
                eve.fechaPublicacion,
                eve.fechaRealizacion,
                eve.costo,
                eve.imagen);

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region Modificar a Base de datos

        public static Ofertas modificarOfertas(Ofertas etOferta)
        {
            PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();

            try
            {
                db.updateOfertas(etOferta.ID,
                etOferta.titulo,
                etOferta.descripcion,
                etOferta.monto,
                etOferta.porcentaje,
                etOferta.fechaInicio,
                etOferta.fechaFin,
                etOferta.imagen);

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return etOferta;
        }

        public static Noticias modificarNoticias(Noticias noti)
        {
            PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();

            try
            {
                db.updateNoticias(noti.ID,
                noti.titulo,
                noti.contenido,
                noti.fechaRealizacion,
                noti.imagen);

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return noti;
        }

        public static Eventos modificarEventos(Eventos eve)
        {
            PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();

            try
            {
                db.updateEventos(eve.ID,
                eve.nombre,
                eve.descripcion,
                eve.fechaPublicacion,
                eve.fechaRealizacion,
                eve.costo,
                eve.imagen);

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return eve;
        }
        #endregion

        #region Eliminar a base de datos
        public static void eliminarEvento(int? id)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    db.eliminarEventos(id);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void eliminarOferta(int? id)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    db.eliminarOfertas(id);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void eliminarNoticia(int? id)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    db.eliminarNoticias(id);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        public static void comentarEvento(ComentariosEventos comentario)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    db.ComentariosEventos.Add(comentario);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void comentarNoticia(ComentariosNoticias comentario)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    db.ComentariosNoticias.Add(comentario);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<Usuarios> listarUsuarios()
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    List<Usuarios> lista = db.Usuarios.Where(x => x.tipo == "Cliente").ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static 






    }
}
