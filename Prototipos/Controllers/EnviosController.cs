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

        public ActionResult notificacionesEnviar()
        {
            return View(Publicar.listarNotificaciones());
        }
    }
}