using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic
{
    public class Rutinas
    {
        public static List<DataContracts.Rutinas> getRutinas()
        {
            try
            {
                PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();
                List<DataContracts.Rutinas> lista = db.Rutinas.AsEnumerable().ToList();
                return lista;
            } catch (Exception e)
            {
                return null;
            }
        }

        public static void agregarRutina(DataContracts.Rutinas rutina)
        {
            try
            {
                PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();
                db.Rutinas.Add(rutina);
                db.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }

        public static void modificarRutina(DataContracts.Rutinas rutina)
        {
            try
            {
                PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();
                db.Rutinas.Where(o => o.ID == rutina.ID).FirstOrDefault().nombre = rutina.nombre;
                db.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }

        public static void eliminarRutina(int id)
        {
            try
            {
                PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();
                DataContracts.Rutinas rutina = db.Rutinas.Find(id);
                db.Rutinas.Remove(rutina);
                db.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }

        public static DataContracts.Rutinas getRutina(int id)
        {
            try
            {
                PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();
                DataContracts.Rutinas rutina = db.Rutinas.Find(id);
                return rutina;
            } catch (Exception e)
            {
                return null;
            }
        }

        public static List<DataContracts.Ejercicios> getEjercicios()
        {
            try
            {
                PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();
                List<DataContracts.Ejercicios> lista = new List<DataContracts.Ejercicios>();
                lista = db.Ejercicios.AsEnumerable().ToList();
                return lista;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static List<DataContracts.Ejercicios> getEjercicioRutina(int id)
        {
            try
            {
                PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();
                List<DataContracts.Ejercicios> lista = new List<DataContracts.Ejercicios>();
                foreach (DataContracts.referenciaRutinas_referenciaEjercicios refe in db.referenciaRutinas_referenciaEjercicios.AsEnumerable().ToList())
                {
                    if (refe.IDRutina == id)
                    {
                        lista.Add(db.Ejercicios.Find(refe.IDEjercicio));
                    }
                }
                return lista;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static DataContracts.Ejercicios getEjercicio(int id)
        {
            try
            {
                PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();
                return db.Ejercicios.Find(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static void modificarEjercicios(DataContracts.Ejercicios ejercicio)
        {
            try
            {
                PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();
                db.Ejercicios.Find(ejercicio.ID).descripcion = ejercicio.descripcion;
                db.Ejercicios.Find(ejercicio.ID).duracion = ejercicio.duracion;
                db.Ejercicios.Find(ejercicio.ID).repeticiones = ejercicio.repeticiones;
                db.Ejercicios.Find(ejercicio.ID).series = ejercicio.series;
                db.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }

        public static void eliminarEjercicio(int id)
        {
            try
            {
                PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();
                DataContracts.Ejercicios ejercicio = db.Ejercicios.Find(id);
                ejercicio.ID = id;
                db.Ejercicios.Remove(ejercicio);
                db.SaveChanges();
            }
            catch (Exception e) {
            }
        }

        public static void agregraEjercicio(DataContracts.Ejercicios ejercicio)
        {
            try
            {
                PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();
                db.Ejercicios.Add(ejercicio);
                db.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }

        public static void agregraReferencia(DataContracts.referenciaRutinas_referenciaEjercicios refe)
        {
            try
            {
                PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();

                db.referenciaRutinas_referenciaEjercicios.Add(refe);
                db.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }

        public static DataContracts.referenciaRutinas_referenciaEjercicios getReferencia(int id)
        {
            try
            {
                PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();
                return db.referenciaRutinas_referenciaEjercicios.Find(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static DataContracts.referenciaRutinas_referenciaEjercicios getReferencia(int idEjer, int idRut){
            try
            {
                PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();
                return db.referenciaRutinas_referenciaEjercicios.Where(x => x.IDRutina == idRut && x.IDEjercicio == idEjer).FirstOrDefault();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static void eliminarReferencia(DataContracts.referenciaRutinas_referenciaEjercicios refe)
        {
            try
            {
                PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();
                referenciaRutinas_referenciaEjercicios referencia = db.referenciaRutinas_referenciaEjercicios.Find(refe.ID);
                db.referenciaRutinas_referenciaEjercicios.Remove(referencia);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                string asss = "";
            }
        }

        public static List<Ejercicios> getEjerciciosXRutina(int id)
        {
            try
            {
                PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();
                List<Ejercicios> ejercicios = new List<Ejercicios>();
                List<referenciaRutinas_referenciaEjercicios> refe = db.referenciaRutinas_referenciaEjercicios.Where(x => x.IDRutina == id).ToList();
                foreach(referenciaRutinas_referenciaEjercicios referencia in refe)
                {
                    ejercicios.Add(getEjercicio(referencia.IDEjercicio));
                }
                return ejercicios;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
