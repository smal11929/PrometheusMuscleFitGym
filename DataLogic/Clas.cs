using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;

namespace DataLogic
{
    public class Clas
    {
        public static void AgregarClases(Clases clases)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    db.insertClases(clases.nombre,
                        clases.dia,
                        clases.horaInicio,
                        clases.horaFin);

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<Clases> ListarMantenimiento()
        {
            List<Clases> lista = new List<Clases>();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    lista = db.Clases.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }

        public static Clases visualizarClase(int? id)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    var obj = db.Clases.Find(id);
                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
         }

        public static void eliminarHorario(int? id)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    db.eliminarClases(id);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Clases modificarClase(Clases cls)
        {
            PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();

            try
            {
                db.updateClases(cls.ID,
                cls.nombre,
                cls.dia,
                cls.horaInicio,
                cls.horaFin);

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return cls;
        }

        public static List<Usuarios> getClientesClase(int id)
        {
            PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();
            List<Usuarios> listaClientes = new List<Usuarios>();
            Horarios horario;
            foreach (Usuarios user in db.Usuarios)
            {
                horario = db.Horarios.Where(o => o.IDUsuario == user.ID).FirstOrDefault();
                foreach(referenciaHorarios_referenciaClases refer in db.referenciaHorarios_referenciaClases)
                {
                    if (horario != null)
                    {
                        if (refer.IDClase == id&&horario.ID==refer.IDHorario)
                        {
                            listaClientes.Add(user);
                        }
                    }
                    
                }
            }
            return (listaClientes);
        }

        public static Boolean agregarRefe(int idUser,int idClase)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    Usuarios user = db.Usuarios.Find(idUser);
                    Horarios horario = db.Horarios.Where(x => x.IDUsuario == idUser).FirstOrDefault();
                    referenciaHorarios_referenciaClases refe = db.referenciaHorarios_referenciaClases.Where(x => x.IDHorario == horario.ID && x.IDClase == idClase).FirstOrDefault();
                    if (refe == null)
                    {
                        referenciaHorarios_referenciaClases referencia = new referenciaHorarios_referenciaClases();
                        referencia.IDClase = idClase;
                        referencia.IDHorario = horario.ID;
                        db.referenciaHorarios_referenciaClases.Add(referencia);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<Clases> getClasesUsuario(int id)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    Usuarios user = db.Usuarios.Find(id);
                    Horarios horario = db.Horarios.Where(x => x.IDUsuario == id).FirstOrDefault();
                    List<referenciaHorarios_referenciaClases> refes = db.referenciaHorarios_referenciaClases.Where(x => x.IDHorario == horario.ID).ToList();
                    List<Clases> clases = new List<Clases>();
                    foreach(referenciaHorarios_referenciaClases var in refes)
                    {
                        clases.Add(db.Clases.Find(var.IDClase));
                    }
                    return clases;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void borrarReferencia(int idUser,int idClass)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    Usuarios user = db.Usuarios.Find(idUser);
                    Horarios horario = db.Horarios.Where(x => x.IDUsuario == idUser).FirstOrDefault();
                    referenciaHorarios_referenciaClases refes = db.referenciaHorarios_referenciaClases.Where(x => x.IDHorario == horario.ID&&x.IDClase==idClass).FirstOrDefault();
                    db.referenciaHorarios_referenciaClases.Remove(refes);
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
