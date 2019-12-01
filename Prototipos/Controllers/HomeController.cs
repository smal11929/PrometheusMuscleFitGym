using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
                        if (miUsuario.tipo.Equals("Administrador"))
                        {
                            miUsuario = new Usuarios();
                            return RedirectToAction("principalAdministrador");
                        }
                        else
                        {
                            miUsuario = new Usuarios();
                            return RedirectToAction("principalCliente");
                        }
                        
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
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }
            if (Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                ViewBag.User = session.ObtenerSession("correo");
                ViewBag.Tipo = TipoUser;

                return View(); 
            }
            else
            {
                return RedirectToAction("getHome", "Home");
            }
            
        }

        public ActionResult principalCliente()
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }
            #region ViewBags
            ViewBag.User = session.ObtenerSession("correo");
            ViewBag.Tipo = TipoUser;
            string correo = session.ObtenerSession("correo");
            Usuarios usuario = Usuario.getID(correo);
            ViewBag.IDRutina = usuario.IDRutina;
            ViewBag.IDUser = usuario.ID;
            #endregion

            return View();
        }

        public ActionResult getHome() {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }
            Usuarios miUsuario = new Usuarios();
            miUsuario = Usuario.getID(session.ObtenerSession("correo"));
            if (miUsuario.tipo.Equals("Administrador"))
            {
                return RedirectToAction("principalAdministrador");
            }
            else
            {
                return RedirectToAction("principalCliente");
            }
        }

        public ActionResult Cerrar()
        {
            session.DestruirSession();
            ViewBag.User = "";
            return RedirectToAction("Index", "Home");
        }

        public ActionResult error404()
        {
            return View();
        }

        [HttpPost]
        // Desabilitar el modo protegido del correo 
        public ActionResult enviarCorreo(FormCollection form)
        {
            string nombre = form["nombreMensaje"];
            string correo = form["correoMensaje"];
            string mensaje = form["mensajeMensaje"];

            MailMessage ec = new MailMessage();

            if (string.IsNullOrEmpty(correo))
            {

            }

            else
            {
                ec.From = new MailAddress(correo);

                ec.To.Add("smal11929@gmail.com"); // Correo cuenta
                ec.Subject = nombre;
                ec.Body = mensaje;
                ec.IsBodyHtml = true;
                ec.Priority = MailPriority.Normal;
            }


            SmtpClient smtp = new SmtpClient();
            string cuentaCorreo = "smal11929@gmail.com"; // Correo cuenta
            string cuentaContraseña = "Ec123*";// Contraseña cuenta
            smtp.Credentials = new NetworkCredential(cuentaCorreo, cuentaContraseña);

            smtp.Host = "smtp.live.com";//smtp.live.com || smtp.office365.com || smtp_mail.outlook.com
            smtp.Port = 587;
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(ec);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View("index");
        }

    }
}