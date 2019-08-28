using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataContracts;
using DataLogic;

namespace Prototipos.Controllers
{
    public class PagosController : Controller
    {
        // GET: Pagos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult pagosMantenimiento()
        {
            return View(Pagos.listarPagos());
        }

        public ActionResult pagosConsulta()
        {
            return View(Seguridad.listarClientes());
        }

        public ActionResult pagosEstimados()
        {
            return View();
        }

        public ActionResult agregarPago()
        {
            #region Viewbag
            List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem { Text = "Si", Value = "true" });
            lst.Add(new SelectListItem { Text = "No", Value = "false" });

            ViewBag.OpcionDescuento = lst;
            #endregion

            return View();
        }

        [HttpPost]
        public ActionResult agregarPago(PagosRealizados pago, FormCollection form)
        {
            #region ViewBag
            List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem { Text = "Si", Value = "true" });
            lst.Add(new SelectListItem { Text = "No", Value = "false" });

            ViewBag.OpcionDescuento = lst;
            #endregion
            PagosRealizados pagosRealizados = new PagosRealizados();

            var cedula = form["cedula"];

            pagosRealizados = Pagos.AgregarPago(pago, Convert.ToInt32(cedula));
            if (pagosRealizados.IDUsuario == 0)
            {
                return RedirectToAction("agregarPago");
            }
            else
            {
                return RedirectToAction("pagosMantenimiento");
            }
            
            
        }

        public ActionResult modificarPago(int? id)
        {
            List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem { Text = "Si", Value = "true" });
            lst.Add(new SelectListItem { Text = "No", Value = "false" });

            ViewBag.OpcionDescuento = lst;

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            PagosRealizados pago = Pagos.visualizarModificarPago(id);

            return View(pago);
        }

        [HttpPost]
        public ActionResult modificarPago(PagosRealizados pago)
        {
            List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem { Text = "Si", Value = "true" });
            lst.Add(new SelectListItem { Text = "No", Value = "false" });

            ViewBag.OpcionDescuento = lst;

            PagosRealizados pagos = new PagosRealizados();

            if (ModelState.IsValid)
            {
                pagos = Pagos.modificarPago(pago);
                return RedirectToAction("pagosMantenimiento");
            }


            return View(pagos);
        }
    }
}