using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataContracts;
using DataLogic;

namespace Prototipos.Controllers
{
    public class EnviosController : Controller
    {
        // GET: Envios
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult mensajeTexto()
        {
            return View(Envios.listarMensajes());
        }

        public ActionResult notificacionesEnviar(int id)
        {
            return View(Publicar.listarNotificaciones(id));
        }

        public ActionResult AgregarNotificaciones(FormCollection form)
        {
            string titulo = form["titulo"];
            string msj = form["summernote"];
            Envios.AgregarNotificaciones(titulo,msj);
            return RedirectToAction("UsuariosAnotificar");
        }

        public ActionResult UsuariosAnotificar()
        {
            return View(Publicar.listarUsuarios());
        }
    }
}