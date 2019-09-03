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
            return View();
        }

        [HttpPost]
        public ActionResult agregarPago(PagosRealizados pago, FormCollection form)
        {
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

        public ActionResult modificarPago(int? idusuario, int idpago)
        {
            int cedula = Pagos.getUsu(idusuario);
            ViewBag.Usuario = cedula;

            PagosRealizados pago = Pagos.visualizarModificarPago(idpago);

            return View(pago);
        }

        [HttpPost]
        public ActionResult modificarPago(PagosRealizados pago)
        {
            PagosRealizados pagos = new PagosRealizados();
            int usu = Pagos.getUsu(pago.IDUsuario);
            ViewBag.Usuario = usu;
            if (ModelState.IsValid)
            {
                pagos = Pagos.modificarPago(pago);
                return RedirectToAction("pagosMantenimiento");
            }


            return View(pagos);
        }

        public ActionResult eliminarPago(int id)
        {
            Pagos.eliminarPago(id);
            return RedirectToAction("pagosMantenimiento");
        }
    }
}