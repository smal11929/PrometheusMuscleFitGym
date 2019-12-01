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
    public class EnviosController : Controller
    {
        DatosSession session = new DatosSession();
        // GET: Envios
        public ActionResult Index()
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            return View();
        }

        public ActionResult mensajeTexto()
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            Usuarios usuario = Usuario.getID(session.ObtenerSession("correo"));
            List<Mensaje> lista = Envios.listarMensajes(usuario.ID);
            Dictionary<int, string> clientes = new Dictionary<int, string>();
            foreach (Usuarios user in Usuario.getAllUsers())
            {
                clientes.Add(user.ID,user.nombre + " " + user.apellido1 + " " + user.apellido2);
            }
            ViewBag.Clientes = clientes;
            return View(lista);
        }

        public ActionResult agrgarMensaje()
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            List<SelectListItem> clientes = new List<SelectListItem>();
            foreach (Usuarios user in Usuario.getAllUsers())
            {
                clientes.Add(new SelectListItem { Text = user.nombre+" "+user.apellido1+" "+user.apellido2, Value = user.ID.ToString() });
            }
            ViewBag.Clientes = clientes;
            return View();
        }

        [HttpPost]
        public ActionResult agrgarMensaje(Mensaje mensaje)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            Usuarios user = Usuario.getID(session.ObtenerSession("correo"));
            mensaje.IDEmisor = user.ID;
            Envios.agregarMensaje(mensaje);
            return RedirectToAction("mensajeTexto");
        }


        public ActionResult notificacionesEnviar(int id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            return View(Publicar.listarNotificaciones(id));
        }

        public ActionResult AgregarNotificaciones()
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
        public ActionResult AgregarNotificaciones(Notificaciones notificacion)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            int id=Envios.AgregarNotificaciones(notificacion);
            List<Usuarios> usuarios = Usuario.getAllUsers();
            foreach(Usuarios user in usuarios){
                referenciaUsuarios_referenciaNotificaciones referencia= new referenciaUsuarios_referenciaNotificaciones();
                referencia.IDNotificacion = id;
                referencia.IDUsuario = user.ID;
                Envios.AgregarRefe(referencia);
            }
            ViewBag.Usuarios = usuarios;
            return RedirectToAction("listaNotificaciones");
        }

        public ActionResult listaNotificaciones()
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            return View(Envios.getNotificaciones());
        }

        public ActionResult UsuariosAnotificar()
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            return View(Publicar.listarUsuarios());
        }

        public ActionResult deleteNotificacion(int id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            Envios.deleteNotificaciones(id);
            return RedirectToAction("listaNotificaciones");
        }

        public ActionResult updateNotificacion(int id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            return View(Envios.getNotificacion(id));
        }

        [HttpPost]
        public ActionResult updateNotificacion(Notificaciones notificacion)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            Envios.updateNotificaciones(notificacion);
            return RedirectToAction("listaNotificaciones");
        }
    }
}