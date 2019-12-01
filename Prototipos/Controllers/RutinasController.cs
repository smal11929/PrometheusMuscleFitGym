using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLogic;
using DataContracts;
using Prototipos.Models;

namespace Prototipos.Controllers
{
    public class RutinasController : Controller
    {
        DatosSession session = new DatosSession();
        // GET: Rutinas
        public ActionResult Index()
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            return View(DataLogic.Rutinas.getRutinas());
        }
        public ActionResult detallesRutina(int id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            List<DataContracts.Ejercicios> listaRutinas = DataLogic.Rutinas.getEjercicioRutina(id);
            List<DataContracts.Ejercicios> lista = DataLogic.Rutinas.getEjercicios().Except(listaRutinas).ToList();
            ViewBag.Lista = lista;
            ViewBag.ListaRutina = listaRutinas;
            return View(DataLogic.Rutinas.getRutina(id));
        }

        public ActionResult agregarRefereciaClase(int idRutina, int idEjer)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            DataContracts.referenciaRutinas_referenciaEjercicios refer = new DataContracts.referenciaRutinas_referenciaEjercicios();
            refer.IDEjercicio = idEjer;
            refer.IDRutina = idRutina;
            DataLogic.Rutinas.agregraReferencia(refer);
            return View("detallesRutina", idRutina);
        }
        public ActionResult eliminarRefereciaClase(int idRutina, int idEjer, int id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            DataContracts.referenciaRutinas_referenciaEjercicios refer = new DataContracts.referenciaRutinas_referenciaEjercicios();
            refer.IDEjercicio = idEjer;
            refer.IDRutina = idRutina;
            refer.ID = id;
            DataLogic.Rutinas.eliminarReferencia(refer);
            return View("detallesRutina", idRutina);
        }

        public ActionResult agregraRutina()
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            return View();
        }
        [HttpPost]
        public ActionResult agregraRutina(DataContracts.Rutinas rutina)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            DataLogic.Rutinas.agregarRutina(rutina);
            return RedirectToAction("Index");
        }
        public ActionResult modificarRutina(int id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            TempData["id"] = id;
            return View();
        }
        [HttpPost]
        public ActionResult modificarRutina(DataContracts.Rutinas rutina)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            rutina.ID = (int)TempData["id"];
            DataLogic.Rutinas.modificarRutina(rutina);
            return RedirectToAction("Index");
        }

        public ActionResult eliminarRutina(int id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            DataLogic.Rutinas.eliminarRutina(id);
            return RedirectToAction("Index");
        }

        public ActionResult verEjercicios()
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            return View(DataLogic.Rutinas.getEjercicios());
        }

        public ActionResult detalleEjercicio(int id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            return View(DataLogic.Rutinas.getEjercicio(id));
        }

        public ActionResult agregarEjercicio()
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            return View("");
        }
        [HttpPost]
        public ActionResult agregarEjercicio(DataContracts.Ejercicios ejercicio)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            DataLogic.Rutinas.agregraEjercicio(ejercicio);
            return RedirectToAction("verEjercicios");
        }
        public ActionResult modificarEjercicio(int id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            TempData["id"] = id;
            return View();
        }
        [HttpPost]
        public ActionResult modificarEjercicio(DataContracts.Ejercicios ejercicio)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            ejercicio.ID = (int)TempData["id"];
            DataLogic.Rutinas.modificarEjercicios(ejercicio);
            return RedirectToAction("verEjercicios");
        }
        public ActionResult eliminarEjercicio(int id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            DataLogic.Rutinas.eliminarEjercicio(id);
            return RedirectToAction("verEjercicios");
        }

        public ActionResult agregarEjerciciosRutina(int id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            List<SelectListItem> ejercicios = new List<SelectListItem>();
            foreach (Ejercicios ejer in DataLogic.Rutinas.getEjercicios())
            {
                ejercicios.Add(new SelectListItem { Text = ejer.descripcion , Value = ejer.ID.ToString() });
            }
            ViewBag.Ejercicios = ejercicios;
            TempData["id"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult agregarEjerciciosRutina(referenciaRutinas_referenciaEjercicios refe)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            refe.IDRutina = (int)TempData["id"];
            DataLogic.Rutinas.agregraReferencia(refe);
            return RedirectToAction("Index");
        }

        public ActionResult detalleRutina(int id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                ViewBag.Render = true;
            }
            else
            {
                ViewBag.Render = false;
            }

            ViewBag.Ejercicios = DataLogic.Rutinas.getEjerciciosXRutina(id);
            TempData["id"] = id;
            return View(DataLogic.Rutinas.getRutina(id));
        }

        public ActionResult deleteReferenciaEjercicio(int id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            referenciaRutinas_referenciaEjercicios refe = DataLogic.Rutinas.getReferencia(id, (int)TempData["id"]);
            int idRutina = refe.IDRutina;
            DataLogic.Rutinas.eliminarReferencia(refe);
            return RedirectToAction("detalleRutina",new { id= idRutina });
        }
    }
}