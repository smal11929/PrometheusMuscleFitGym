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
    public class HomeController : Controller
    {
        public static Usuarios Usercedula = new Usuarios();
        public static string TipoUser;
        DatosSession session = new DatosSession();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string correo, string contrasena)
        {
            try
            {
                if (correo.Equals(String.Empty) || contrasena.Equals(String.Empty))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    string user = correo;
                    string pass = contrasena;
                    
                    var miUsuario = Usuario.Login(user, pass);
                    
                    // toma la cédula de la session actual.
                    Usercedula.cedula = miUsuario.cedula;

                    // toma el rol de la session actual.
                    TipoUser = miUsuario.tipo;

                    if (miUsuario.correo == null && miUsuario.contrasena == null)
                    {
                        miUsuario = new Usuarios();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        session.DarSession("correo", user);
                        ViewBag.User = session.ObtenerSession("correo");
                        miUsuario = new Usuarios();
                        return RedirectToAction("principalAdministrador");
                    }
                }
            }
            catch (Exception ex)
            {
                string mensaje = "-ERROR-HomeController-Index-" + (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

            return View();
        }


        public ActionResult principalAdministrador()
        {
            #region ViewBags
            ViewBag.User = session.ObtenerSession("correo");
            ViewBag.Tipo = TipoUser;
            #endregion

            return View();
        }

        public ActionResult Cerrar()
        {
            session.DestruirSession();
            ViewBag.User = "";
            return RedirectToAction("Index", "Home");
        }

    }
}