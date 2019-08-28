using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataContracts;
using Prototipos.Models;
using DataLogic;

namespace Prototipos.Controllers
{
    public class HorariosController : Controller
    {
        // GET: Horarios
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult horariosEntrenadorClase()
        {
            return View();
        }

        public ActionResult horariosClienteClase(int id)
        {

            return View(Clas.getClientesClase(id));
        }

        #region Insertar

        //GET://
        public ActionResult agregarClase()
        {
            List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem { Text = "Lunes", Value = "Lunes" });
            lst.Add(new SelectListItem { Text = "Martes", Value = "Martes" });
            lst.Add(new SelectListItem { Text = "Miercoles", Value = "Miercoles" });
            lst.Add(new SelectListItem { Text = "Jueves", Value = "Jueves" });
            lst.Add(new SelectListItem { Text = "Viernes", Value = "Viernes" });
            lst.Add(new SelectListItem { Text = "Sabado", Value = "Sabado" });
            lst.Add(new SelectListItem { Text = "Domingo", Value = "Domingo" });
            ViewBag.Dias = lst;
            return View();
        }

        //POST://
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult agregarClase(Clases clases)
        {
            if (ModelState.IsValid)
            {
                Clas.AgregarClases(clases);
                return RedirectToAction("horariosMantenimiento");
            }

            return View();
        }

        #endregion

        #region Modificar
        //GET://
        public ActionResult modificarClase(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            return View(Clas.visualizarClase(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST://
        public ActionResult modificarClase(Clases clases)
        {
            Clases cl = new Clases();
            if (ModelState.IsValid)
            {
                cl = Clas.modificarClase(clases);
                return RedirectToAction("horariosMantenimiento");
            }

            return View(clases);
        }

        #endregion

        #region Borrar

        //GET://
        public ActionResult borrarClase(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("horariosMantenimiento");
            }
            else
            {
                Clas.eliminarHorario(id);
            }

            return RedirectToAction("horariosMantenimiento");
        }

        //GET://
        public ActionResult horariosMantenimiento()
        {
            List<ClasesModel> listaModel = new List<ClasesModel>();
            foreach(Clases clase in Clas.ListarMantenimiento())
            {
                ClasesModel clas = new ClasesModel();
                clas.ID = clase.ID;
                clas.nombre = clase.nombre;
                clas.dia = clase.dia;
                clas.horaInicio = clase.horaInicio.ToString("hh:mm tt");
                clas.horaFin = clase.horaFin.ToString("hh:mm tt");
                listaModel.Add(clas);
            }
            return View(listaModel);
        }

        #endregion


    }

}