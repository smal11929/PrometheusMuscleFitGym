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
    public class PublicarController : Controller
    {
        // GET: Publicar
        DatosSession session = new DatosSession();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult eventoMantenimiento()
        {
            return View(Publicar.listarEventos());
        }

        public ActionResult mantenimientoOfertas()
        {
            return View(Publicar.listarOfertas());
        }

        public ActionResult noticiasMantenimiento()
        {
            return View(Publicar.listarNoticias());
        }

        [ValidateInput(false)]
        public ActionResult agregarEvento()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult agregarEvento(Eventos _eve)
        {
            if (ModelState.IsValid)
            {
                Publicar.AgregarEvento(_eve);
                return RedirectToAction("eventoMantenimiento");
            }
            return View();
        }

        [ValidateInput(false)]
        public ActionResult agregarNoticia()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult agregarNoticia(Noticias noti)
        {
            if (ModelState.IsValid)
            {
                Publicar.AgregarNoticia(noti);
                return RedirectToAction("noticiasMantenimiento");
            }
            return View();
        }

        [ValidateInput(false)]
        public ActionResult agregarOferta()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult agregarOferta(Ofertas etofertas)
        {
            if (ModelState.IsValid)
            {
                Publicar.AgregarOferta(etofertas);
                return RedirectToAction("mantenimientoOfertas");
            }
            return View();
        }

        [ValidateInput(false)]
        public ActionResult modificarEvento(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Eventos eve = Publicar.visualizarMantenimientoEventos(id);

            return View(eve);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult modificarEvento(Eventos eventos)
        {
            Eventos eve = new Eventos();
            if (ModelState.IsValid)
            {
                eve = Publicar.modificarEventos(eventos);
                return RedirectToAction("eventoMantenimiento");
            }

            return View(eventos);

        }

        [ValidateInput(false)]
        public ActionResult modificarNoticia(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Noticias noti = Publicar.visualizarMantenimientoNoticias(id);

            return View(noti);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult modificarNoticia(Noticias noti)
        {
            Noticias noticias = new Noticias();
            if (ModelState.IsValid)
            {
                noticias = Publicar.modificarNoticias(noti);
                return RedirectToAction("noticiasMantenimiento");
            }

            return View(noti);

        }

        [ValidateInput(false)]
        public ActionResult modificarOferta(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Ofertas ofertas = Publicar.visualizarMantenimientoOfertas(id);

            return View(ofertas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult modificarOferta(Ofertas Ofertas)
        {
            Ofertas ofe = new Ofertas();
            if (ModelState.IsValid)
            {
                ofe = Publicar.modificarOfertas(Ofertas);
                return RedirectToAction("mantenimientoOfertas");
            }

            return View(Ofertas);

        }

        public ActionResult ofertasDetalles(int? id)
        {
            return View(Publicar.listarOfertasComentar(id));
        }


        public ActionResult eventosComentar(int? id)
        {
            return View(Publicar.listarEventosComentar(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult eventosComentar(Eventos evento,string coment)
        {
            ComentariosEventos comentario = new ComentariosEventos();
            comentario.IDEvento = evento.ID;
            comentario.fecha = DateTime.Now;
            string correo= session.ObtenerSession("correo");
            Usuarios usuario = Usuario.getID(correo);
            comentario.IDUsuario = usuario.ID;
            comentario.mensaje = coment;
            Publicar.comentarEvento(comentario);
            return RedirectToAction("eventoMantenimiento");
        }

        public ActionResult noticiasComentar(int? id)
        {
            return View(Publicar.listarNoticiasComentar(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult noticiasComentar(Noticias noticia,string coment)
        {
            ComentariosNoticias comentario = new ComentariosNoticias();
            comentario.IDNoticia = noticia.ID;
            comentario.fecha = DateTime.Now;
            string correo = session.ObtenerSession("correo");
            Usuarios usuario = Usuario.getID(correo);
            comentario.IDUsuario = usuario.ID;
            comentario.mensaje = coment;
            Publicar.comentarNoticia(comentario);
            return RedirectToAction("noticiasMantenimiento");
        }

        #region Eliminar

        public ActionResult borrarEvento(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Publicar.eliminarEvento(id);
            return RedirectToAction("eventoMantenimiento");
        }

        public ActionResult borrarOferta(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Publicar.eliminarOferta(id);
            return RedirectToAction("mantenimientoOfertas");
        }

        public ActionResult borrarNoticia(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Publicar.eliminarNoticia(id);
            return RedirectToAction("noticiasMantenimiento");
        }

        #endregion

    }
}