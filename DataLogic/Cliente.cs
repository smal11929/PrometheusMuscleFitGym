using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataContracts;
using Prototipos.Models;

namespace DataLogic
{
    public class Cliente
    {
        //public static Medidas_Usuarios mu;
        
        public static void AgregarhistorialMedico(HistorialMedico historialMedico)
        {
            PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities();
            try
            {
                db.insertHistorialMedico(historialMedico.alcohol,
                historialMedico.fumado,
                historialMedico.hipertension,
                historialMedico.diabetes,
                historialMedico.medicamentos,
                historialMedico.fracturas,
                historialMedico.cirugias,
                historialMedico.alergias,
                historialMedico.problemasArticulares,
                historialMedico.otras,
                historialMedico.IDUsuario);

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public static List<Usuarios> listarUsuarios()
        {
            List<Usuarios> lstU = new List<Usuarios>();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    lstU = db.Usuarios.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstU;
        }

        public static HistorialMedico ModificarHM(HistorialMedico historialMedico)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    if (db.HistorialMedico.Any(o => o.IDUsuario == historialMedico.IDUsuario))
                    {
                        db.HistorialMedico.Where(o => o.IDUsuario == historialMedico.IDUsuario).FirstOrDefault().alcohol=historialMedico.alcohol;
                        db.HistorialMedico.Where(o => o.IDUsuario == historialMedico.IDUsuario).FirstOrDefault().fumado = historialMedico.fumado;
                        db.HistorialMedico.Where(o => o.IDUsuario == historialMedico.IDUsuario).FirstOrDefault().hipertension = historialMedico.hipertension;
                        db.HistorialMedico.Where(o => o.IDUsuario == historialMedico.IDUsuario).FirstOrDefault().diabetes = historialMedico.diabetes;
                        db.HistorialMedico.Where(o => o.IDUsuario == historialMedico.IDUsuario).FirstOrDefault().medicamentos = historialMedico.medicamentos;
                        db.HistorialMedico.Where(o => o.IDUsuario == historialMedico.IDUsuario).FirstOrDefault().fracturas = historialMedico.fracturas;
                        db.HistorialMedico.Where(o => o.IDUsuario == historialMedico.IDUsuario).FirstOrDefault().cirugias = historialMedico.cirugias;
                        db.HistorialMedico.Where(o => o.IDUsuario == historialMedico.IDUsuario).FirstOrDefault().alergias = historialMedico.alergias;
                        db.HistorialMedico.Where(o => o.IDUsuario == historialMedico.IDUsuario).FirstOrDefault().problemasArticulares = historialMedico.problemasArticulares;
                        db.HistorialMedico.Where(o => o.IDUsuario == historialMedico.IDUsuario).FirstOrDefault().otras = historialMedico.otras;
                    }
                    else
                    {
                        db.HistorialMedico.Add(historialMedico);
                    }
                    

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return historialMedico;
        }

        public static HistorialMedico visualizarHM(int? id)
        {
            HistorialMedico hm = new HistorialMedico();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    Usuarios user = db.Usuarios.Find(id);
                    hm= db.HistorialMedico.Where(o => o.IDUsuario == id).FirstOrDefault();
                    return hm;
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static dynamic retornaViewBags(int? id)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    var collection = db.HistorialMedico.Where(x => x.IDUsuario == id).ToList();
                    return collection;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public static List<MedidasHombre> getMedidasHombre(int? id)
        {
            List<MedidasHombre> mu = new List<MedidasHombre>();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    foreach(Medidas medidas in db.Medidas.Where(o => o.IDUsuario == id))
                    {
                        MedidasHombre medidasH = new MedidasHombre();
                        PlieguesHombres plieguesH = new PlieguesHombres();
                        if (db.PlieguesHombres.Any(o=>o.IDMedidas==medidas.ID))
                        {
                            plieguesH = db.PlieguesHombres.Where(o => o.IDMedidas == medidas.ID).FirstOrDefault();
                        }
                        medidasH.ID = medidas.ID;
                        medidasH.edad = medidas.edad;
                        medidasH.pesoLB = medidas.pesoLB;
                        medidasH.pesoKg = medidas.pesoKg;
                        medidasH.estatura = medidas.estatura;
                        medidasH.imc = medidas.imc;
                        medidasH.diametroHumero = medidas.diametroHumero;
                        medidasH.diametroFemur = medidas.diametroFemur;
                        medidasH.pesoResidual = medidas.pesoResidual;
                        medidasH.pesoGrasa = medidas.pesoGrasa;
                        medidasH.pesoMuscular = medidas.pesoMuscular;
                        medidasH.pesoOseo = medidas.pesoOseo;
                        medidasH.pesoLibreGrasa = medidas.pesoLibreGrasa;
                        medidasH.porcentajeGrasa = medidas.porcentajeGrasa;
                        medidasH.circuferenciaBrazo = medidas.circuferenciaBrazo;
                        medidasH.circuferenciaCintura = medidas.circuferenciaCintura;
                        medidasH.circunferenciaAntebrazo = medidas.circunferenciaAntebrazo;
                        medidasH.circunferenciaCadera = medidas.circunferenciaCadera;
                        medidasH.circunferenciaMuslo = medidas.circunferenciaMuslo;
                        medidasH.circunferenciaPierna = medidas.circunferenciaPierna;
                        medidasH.circunferenciaTorax = medidas.circunferenciaTorax;
                        medidasH.fecha = medidas.fecha;
                        medidasH.IDEvaluador = medidas.IDEvaluador;
                        medidasH.plieguesAbdomen = plieguesH.plieguesAbdomen;
                        medidasH.plieguesMuslo = plieguesH.plieguesMuslo;
                        medidasH.plieguesPecho = plieguesH.plieguesPecho;
                        medidasH.plieguesSubEscapular = plieguesH.plieguesSubEscapular;
                        mu.Add(medidasH);
                    }
                    
                    return mu;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<MedidasMujer> getMedidasMujer(int? id)
        {
            List<MedidasMujer> mu = new List<MedidasMujer>();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    foreach (Medidas medidas in db.Medidas.Where(o => o.IDUsuario == id))
                    {
                        MedidasMujer medidasH = new MedidasMujer();
                        PlieguesMujeres plieguesM = new PlieguesMujeres();
                        if (db.PlieguesHombres.Any(o => o.IDMedidas == medidas.ID))
                        {
                            plieguesM = db.PlieguesMujeres.Where(o => o.IDMedidas == medidas.ID).FirstOrDefault();
                        }
                        medidasH.ID = medidas.ID;
                        medidasH.edad = medidas.edad;
                        medidasH.pesoLB = medidas.pesoLB;
                        medidasH.pesoKg = medidas.pesoKg;
                        medidasH.estatura = medidas.estatura;
                        medidasH.imc = medidas.imc;
                        medidasH.diametroHumero = medidas.diametroHumero;
                        medidasH.diametroFemur = medidas.diametroFemur;
                        medidasH.pesoResidual = medidas.pesoResidual;
                        medidasH.pesoGrasa = medidas.pesoGrasa;
                        medidasH.pesoMuscular = medidas.pesoMuscular;
                        medidasH.pesoOseo = medidas.pesoOseo;
                        medidasH.pesoLibreGrasa = medidas.pesoLibreGrasa;
                        medidasH.porcentajeGrasa = medidas.porcentajeGrasa;
                        medidasH.circuferenciaBrazo = medidas.circuferenciaBrazo;
                        medidasH.circuferenciaCintura = medidas.circuferenciaCintura;
                        medidasH.circunferenciaAntebrazo = medidas.circunferenciaAntebrazo;
                        medidasH.circunferenciaCadera = medidas.circunferenciaCadera;
                        medidasH.circunferenciaMuslo = medidas.circunferenciaMuslo;
                        medidasH.circunferenciaPierna = medidas.circunferenciaPierna;
                        medidasH.circunferenciaTorax = medidas.circunferenciaTorax;
                        medidasH.fecha = medidas.fecha;
                        medidasH.IDEvaluador = medidas.IDEvaluador;
                        medidasH.plieguesSubPrailiaco = plieguesM.plieguesSubPrailiaco;
                        medidasH.plieguesMuslo = plieguesM.plieguesMuslo;
                        medidasH.plieguesTriceps = plieguesM.plieguesTriceps;
                        medidasH.plieguesSubEscapular = plieguesM.plieguesSubEscapular;
                        mu.Add(medidasH);
                    }

                    return mu;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void agregarMedidasHombre(MedidasHombre medidasH)
        {
            try
            {
                Medidas medidas = new Medidas();
                medidas.edad = medidasH.edad;
                medidas.pesoLB = medidasH.pesoLB;
                medidas.pesoKg = medidasH.pesoKg;
                medidas.estatura = medidasH.estatura;
                medidas.imc = medidasH.imc;
                medidas.diametroHumero = medidasH.diametroHumero;
                medidas.diametroFemur = medidasH.diametroFemur;
                medidas.pesoResidual = medidasH.pesoResidual;
                medidas.pesoGrasa = medidasH.pesoGrasa;
                medidas.pesoMuscular = medidasH.pesoMuscular;
                medidas.pesoOseo = medidasH.pesoOseo;
                medidas.pesoLibreGrasa = medidasH.pesoLibreGrasa;
                medidas.porcentajeGrasa = medidasH.porcentajeGrasa;
                medidas.circuferenciaBrazo = medidasH.circuferenciaBrazo;
                medidas.circuferenciaCintura = medidasH.circuferenciaCintura;
                medidas.circunferenciaAntebrazo = medidasH.circunferenciaAntebrazo;
                medidas.circunferenciaCadera = medidasH.circunferenciaCadera;
                medidas.circunferenciaMuslo = medidasH.circunferenciaMuslo;
                medidas.circunferenciaPierna = medidasH.circunferenciaPierna;
                medidas.circunferenciaTorax = medidasH.circunferenciaTorax;
                medidas.fecha = medidasH.fecha;
                medidas.IDEvaluador = medidasH.IDEvaluador;
                medidas.IDUsuario = medidasH.IDUsuario;
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    db.Medidas.Add(medidas);
                    db.SaveChanges();
                    PlieguesHombres pliegues = new PlieguesHombres();
                    pliegues.IDMedidas = medidas.ID;
                    pliegues.plieguesAbdomen = medidasH.plieguesAbdomen;
                    pliegues.plieguesMuslo = medidasH.plieguesMuslo;
                    pliegues.plieguesPecho = medidasH.plieguesPecho;
                    pliegues.plieguesSubEscapular = medidasH.plieguesSubEscapular;
                    db.PlieguesHombres.Add(pliegues);
                    db.SaveChanges();
                }
            }catch(Exception e)
            {

            }
        }

        public static List<Medidas> getMedidas(int id)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    return db.Medidas.Where(o => o.IDUsuario == id).ToList();
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public static void agregarMedidas(Medidas medi)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    db.Medidas.Add(medi);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
            }
        }

        public static void UpadateMedidas(Medidas medi)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    Medidas medidas=db.Medidas.Where(o=>o.ID==medi.ID).FirstOrDefault();
                    medidas = medi;
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
            }
        }


    }
}
