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
    public class PagosController : Controller
    {
        DatosSession session = new DatosSession();
        // GET: Pagos
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

            return View();
        }

        public ActionResult pagosMantenimiento()
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            Dictionary<int, int> clientes = new Dictionary<int, int>();
            foreach (Usuarios user in Usuario.getUsers().Where(x => x.tipo == "Cliente").ToList())
            {
                clientes.Add(user.ID, user.cedula);
            }
            ViewBag.Clientes = clientes;

            if (Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                ViewBag.Render = true;
                return View(Pagos.listarPagos());
            }
            else
            {
                ViewBag.Render = false;
                string correo = session.ObtenerSession("correo");
                Usuarios usuario = Usuario.getID(correo);
                return View(Pagos.listarPagos().Where(x=>x.IDUsuario== usuario.ID).ToList());
            }

            
            
        }

        public ActionResult pagosConsulta()
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            return View(Seguridad.listarClientes());
        }

        public ActionResult agregarPago()
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            List<SelectListItem> clientes = new List<SelectListItem>();
            foreach(Usuarios user in Usuario.getUsers().Where(x => x.tipo == "Cliente").ToList())
            {
                clientes.Add(new SelectListItem { Text = user.cedula.ToString(), Value = user.ID.ToString() });
            }
            ViewBag.Clientes = clientes;
            return View();
        }

        [HttpPost]
        public ActionResult agregarPago(PagosRealizados pago)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            PagosRealizados pagosRealizados = new PagosRealizados();

            pagosRealizados = Pagos.AgregarPago(pago);

            return RedirectToAction("pagosMantenimiento");
        }

        public ActionResult modificarPago(int idpago)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            List<SelectListItem> clientes = new List<SelectListItem>();
            foreach (Usuarios user in Usuario.getUsers().Where(x => x.tipo == "Cliente").ToList())
            {
                clientes.Add(new SelectListItem { Text = user.cedula.ToString(), Value = user.ID.ToString() });
            }
            ViewBag.Clientes = clientes;
            
            PagosRealizados pago = Pagos.visualizarModificarPago(idpago);
            TempData["id"] = pago.ID;
            return View(pago);
        }

        [HttpPost]
        public ActionResult modificarPago(PagosRealizados pago)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            pago.ID = (int)TempData["id"];
                Pagos.modificarPago(pago);
                return RedirectToAction("pagosMantenimiento");
        }

        public ActionResult eliminarPago(int id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            Pagos.eliminarPago(id);
            return RedirectToAction("pagosMantenimiento");
        }
    }
}