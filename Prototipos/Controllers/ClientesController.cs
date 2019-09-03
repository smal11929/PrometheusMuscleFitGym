using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataContracts;
using DataLogic;
using Prototipos.Models;

namespace Prototipos.Controllers
{
    public class ClientesController : Controller
    {
        DatosSession session = new DatosSession();
        // GET: Clientes
        public ActionResult Index()
        { 

            return View();
        }
        #region Mantenimientos

        public ActionResult medidasMantenimiento()
        {
            return View(Cliente.listarUsuarios().Where(o=>o.tipo=="Cliente"&&o.habilitado));
        }

        public ActionResult rutinasMantenimiento()
        {
            return View(Cliente.listarUsuarios().Where(o => o.tipo == "Cliente"&&o.habilitado));
        }

        #endregion

        #region Insertar

        //GET://
        public ActionResult AgregarcmMedico()
        {
            #region ViewBag
            List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem { Text = "Si", Value = "true" });
            lst.Add(new SelectListItem { Text = "No", Value = "false" });

            ViewBag.Opciones = lst;
            #endregion


            return View();
        }

        //POST://
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarcmMedico(HistorialMedico hMedico)
        {
            #region ViewBag
            List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem { Text = "Si", Value = "1" });
            lst.Add(new SelectListItem { Text = "No", Value = "2" });

            ViewBag.Opciones = lst;
            #endregion

            if (ModelState.IsValid)
            {
                Cliente.AgregarhistorialMedico(hMedico);
                return RedirectToAction("medidasMantenimiento");
            }

            return View();
        }

        public ActionResult cmMedida(int? id)
        {
            TempData["id"] = id;
            return View(Cliente.getMedidas((int)id));
        }

        public ActionResult MedidasHombres(List<Prototipos.Models.MedidasHombre> medidas)
        {
            TempData["id2"] = TempData["id"];
            if (medidas == null)
            {
                List<MedidasHombre> lista = new List<MedidasHombre>();
                return View(lista);
            }
            else
            {
                return View(medidas);
            }
            
        }

        public ActionResult MedidasMujer(MedidasMujer medidas)
        {
            if (medidas == null)
            {
                List<MedidasMujer> lista = new List<MedidasMujer>();
                return View(lista);
            }
            else
            {
                return View(medidas);
            }
        }

        public ActionResult cmRutina(int id)
        {
            #region Viewbag

            List<SelectListItem> lstSeries = new List<SelectListItem>();
            List<SelectListItem> lstRepeticiones = new List<SelectListItem>();
            List<SelectListItem> lstMinutos = new List<SelectListItem>();

            lstSeries.Add(new SelectListItem { Text = "1 Serie", Value = "1" });
            lstSeries.Add(new SelectListItem { Text = "2 Series", Value = "2" });
            lstSeries.Add(new SelectListItem { Text = "3 Series", Value = "3" });
            lstSeries.Add(new SelectListItem { Text = "4 Series", Value = "4" });
            lstSeries.Add(new SelectListItem { Text = "5 Series", Value = "5" });
            lstSeries.Add(new SelectListItem { Text = "6 Series", Value = "6" });
            lstSeries.Add(new SelectListItem { Text = "7 Series", Value = "7" });
            lstSeries.Add(new SelectListItem { Text = "8 Series", Value = "8" });
            lstSeries.Add(new SelectListItem { Text = "9 Series", Value = "9" });
            lstSeries.Add(new SelectListItem { Text = "10 Series", Value = "10" });
            lstSeries.Add(new SelectListItem { Text = "11 Series", Value = "11" });
            lstSeries.Add(new SelectListItem { Text = "12 Series", Value = "12" });
            lstSeries.Add(new SelectListItem { Text = "13 Series", Value = "13" });
            lstSeries.Add(new SelectListItem { Text = "14 Series", Value = "14" });
            lstSeries.Add(new SelectListItem { Text = "15 Series", Value = "15" });

            lstRepeticiones.Add(new SelectListItem { Text = "1 Repeticion", Value = "1" });
            lstRepeticiones.Add(new SelectListItem { Text = "2 Repeticiones", Value = "2" });
            lstRepeticiones.Add(new SelectListItem { Text = "3 Repeticiones", Value = "3" });
            lstRepeticiones.Add(new SelectListItem { Text = "4 Repeticiones", Value = "4" });
            lstRepeticiones.Add(new SelectListItem { Text = "5 Repeticiones", Value = "5" });
            lstRepeticiones.Add(new SelectListItem { Text = "6 Repeticiones", Value = "6" });
            lstRepeticiones.Add(new SelectListItem { Text = "7 Repeticiones", Value = "7" });
            lstRepeticiones.Add(new SelectListItem { Text = "8 Repeticiones", Value = "8" });
            lstRepeticiones.Add(new SelectListItem { Text = "9 Repeticiones", Value = "9" });
            lstRepeticiones.Add(new SelectListItem { Text = "10 Repeticiones", Value = "10" });
            lstRepeticiones.Add(new SelectListItem { Text = "11 Repeticiones", Value = "11" });
            lstRepeticiones.Add(new SelectListItem { Text = "12 Repeticiones", Value = "12" });
            lstRepeticiones.Add(new SelectListItem { Text = "13 Repeticiones", Value = "13" });
            lstRepeticiones.Add(new SelectListItem { Text = "14 Repeticiones", Value = "14" });
            lstRepeticiones.Add(new SelectListItem { Text = "15 Repeticiones", Value = "15" });

            lstMinutos.Add(new SelectListItem { Text = "1 minuto", Value = "1" });
            lstMinutos.Add(new SelectListItem { Text = "2 minutos", Value = "2" });
            lstMinutos.Add(new SelectListItem { Text = "3 minutos", Value = "3" });
            lstMinutos.Add(new SelectListItem { Text = "4 minutos", Value = "4" });
            lstMinutos.Add(new SelectListItem { Text = "5 minutos", Value = "5" });
            lstMinutos.Add(new SelectListItem { Text = "6 minutos", Value = "6" });
            lstMinutos.Add(new SelectListItem { Text = "7 minutos", Value = "7" });
            lstMinutos.Add(new SelectListItem { Text = "8 minutos", Value = "8" });
            lstMinutos.Add(new SelectListItem { Text = "9 minutos", Value = "9" });
            lstMinutos.Add(new SelectListItem { Text = "10 minutos", Value = "10" });
            lstMinutos.Add(new SelectListItem { Text = "11 minutos", Value = "11" });
            lstMinutos.Add(new SelectListItem { Text = "12 minutos", Value = "12" });
            lstMinutos.Add(new SelectListItem { Text = "13 minutos", Value = "13" });
            lstMinutos.Add(new SelectListItem { Text = "14 minutos", Value = "14" });
            lstMinutos.Add(new SelectListItem { Text = "15 minutos", Value = "15" });

            ViewBag.OpcionesSeries = lstSeries;
            ViewBag.OpcionesRepeticiones = lstRepeticiones;
            ViewBag.OpcionesMinutos = lstMinutos;

            #endregion
            Usuarios_Ejercicios model = new Usuarios_Ejercicios();

            model.Usuarios = Cliente.obtieneusuarioEjercicio(id);
            model.Ejercicios = Cliente.obtieneejercicioUsuario(id);
            return View(model);
        }

        #endregion
        

        #region Modificar

        //GET://
        public ActionResult ModificarcmMedico(int? id)
        {


            #region ViewBag

            var viewalcochol = Cliente.retornaViewBags(id);
            var viewfumado = Cliente.retornaViewBags(id);
            var viewhipertension = Cliente.retornaViewBags(id);
            var viewdiabetes = Cliente.retornaViewBags(id);

            ViewBag.Alcohol = new SelectList(viewalcochol,"alcohol","alcohol");
            ViewBag.Fumado = new SelectList(viewfumado,"fumado","fumado");
            ViewBag.Hipertension = new SelectList(viewhipertension, "hipertension", "hipertension");
            ViewBag.Diabetes = new SelectList(viewdiabetes, "diabetes", "diabetes");

            #endregion

            HistorialMedico_Usuarios modelo = new HistorialMedico_Usuarios();

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            modelo.historialMedicO = Cliente.visualizarHM(id);
            modelo.usuarios =Usuario.getUser((int)id);
            TempData["id"] = id;
            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST://
        public ActionResult ModificarcmMedico(HistorialMedico_Usuarios historialU)
        {
            #region ViewBag
            List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem { Text = "Si", Value = "1" });
            lst.Add(new SelectListItem { Text = "No", Value = "2" });

            ViewBag.Opciones = lst;
            #endregion

            HistorialMedico historial = historialU.historialMedicO;
            historial.IDUsuario = (int)TempData["id"];

            if (ModelState.IsValid)
            {
                historial = Cliente.ModificarHM(historial);
                return RedirectToAction("medidasMantenimiento");
            }

            return View(historial);
        }

        #endregion

        public ActionResult agregarMedidas()
        {
            TempData["id2"] = TempData["id"];
            return View();
        }
        [HttpPost]
        public ActionResult agregarMedidas(Medidas medid)
        {
            medid.IDUsuario = (int)TempData["id2"];
            medid.IDEvaluador = Usuario.getID(session.ObtenerSession("correo")).ID;
            medid.fecha = DateTime.Now;
            Cliente.agregarMedidas(medid);
            return RedirectToAction("cmMedida",new { id= (int)TempData["id2"] });
        }


        public ActionResult modificarMedidas(int id)
        {
            TempData["id2"] = TempData["id"];
            return View(Cliente.obtenerMedidas(id));
        }
        [HttpPost]
        public ActionResult modificarMedidas(Medidas med)
        {
            med.IDUsuario = (int)TempData["id2"];

            med.IDEvaluador = Usuario.getID(session.ObtenerSession("correo")).ID;
            med.fecha = DateTime.Now;
            Cliente.UpadateMedidas(med);
            return RedirectToAction("cmMedida", new { id = (int)TempData["id2"] });
        }

        
    }
}