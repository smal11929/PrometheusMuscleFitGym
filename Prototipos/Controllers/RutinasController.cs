using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLogic;
using DataContracts;

namespace Prototipos.Controllers
{
    public class RutinasController : Controller
    {
        // GET: Rutinas
        public ActionResult Index()
        {
            return View(DataLogic.Rutinas.getRutinas());
        }
        public ActionResult detallesRutina(int id)
        {
            List<DataContracts.Ejercicios> listaRutinas = DataLogic.Rutinas.getEjercicioRutina(id);
            List<DataContracts.Ejercicios> lista = DataLogic.Rutinas.getEjercicios().Except(listaRutinas).ToList();
            ViewBag.Lista = lista;
            ViewBag.ListaRutina = listaRutinas;
            return View(DataLogic.Rutinas.getRutina(id));
        }

        public ActionResult agregarRefereciaClase(int idRutina, int idEjer)
        {
            DataContracts.referenciaRutinas_referenciaEjercicios refer = new DataContracts.referenciaRutinas_referenciaEjercicios();
            refer.IDEjercicio = idEjer;
            refer.IDRutina = idRutina;
            DataLogic.Rutinas.agregraReferencia(refer);
            return View("detallesRutina", idRutina);
        }
        public ActionResult eliminarRefereciaClase(int idRutina, int idEjer, int id)
        {
            DataContracts.referenciaRutinas_referenciaEjercicios refer = new DataContracts.referenciaRutinas_referenciaEjercicios();
            refer.IDEjercicio = idEjer;
            refer.IDRutina = idRutina;
            refer.ID = id;
            DataLogic.Rutinas.eliminarReferencia(refer);
            return View("detallesRutina", idRutina);
        }

        public ActionResult agregraRutina()
        {
            return View();
        }
        [HttpPost]
        public ActionResult agregraRutina(DataContracts.Rutinas rutina)
        {
            DataLogic.Rutinas.agregarRutina(rutina);
            return RedirectToAction("Index");
        }
        public ActionResult modificarRutina(int id)
        {
            TempData["id"] = id;
            return View();
        }
        [HttpPost]
        public ActionResult modificarRutina(DataContracts.Rutinas rutina)
        {
            rutina.ID = (int)TempData["id"];
            DataLogic.Rutinas.modificarRutina(rutina);
            return RedirectToAction("Index");
        }

        public ActionResult eliminarRutina(int id)
        {
            DataLogic.Rutinas.eliminarRutina(id);
            return RedirectToAction("Index");
        }

        public ActionResult verEjercicios()
        {
            return View(DataLogic.Rutinas.getEjercicios());
        }

        public ActionResult detalleEjercicio(int id)
        {
            return View(DataLogic.Rutinas.getEjercicio(id));
        }

        public ActionResult agregarEjercicio()
        {
            return View("");
        }
        [HttpPost]
        public ActionResult agregarEjercicio(DataContracts.Ejercicios ejercicio)
        {
            DataLogic.Rutinas.agregraEjercicio(ejercicio);
            return RedirectToAction("verEjercicios");
        }
        public ActionResult modificarEjercicio(int id)
        {
            TempData["id"] = id;
            return View();
        }
        [HttpPost]
        public ActionResult modificarEjercicio(DataContracts.Ejercicios ejercicio)
        {
            ejercicio.ID = (int)TempData["id"];
            DataLogic.Rutinas.modificarEjercicios(ejercicio);
            return RedirectToAction("verEjercicios");
        }
        public ActionResult eliminarEjercicio(int id)
        {
            DataLogic.Rutinas.eliminarEjercicio(id);
            return RedirectToAction("verEjercicios");
        }
    }
}