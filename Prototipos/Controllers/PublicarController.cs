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

        #region Eventos

        public ActionResult eventoMantenimiento()
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                ViewBag.Render = true;
            }
            else
            {
                ViewBag.Render = false;
            }

                return View(Publicar.listarEventos());
        }

        [ValidateInput(false)]
        public ActionResult agregarEvento()
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return View();
            }
            else
            {
                return RedirectToAction("getHome", "Home");
            }

        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult agregarEvento(Eventos _eve)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                if (ModelState.IsValid)
                {
                    Publicar.AgregarEvento(_eve);
                    return RedirectToAction("eventoMantenimiento");
                }
                return View();
            }
            else
            {
                return RedirectToAction("getHome", "Home");
            }

        }

        [ValidateInput(false)]
        public ActionResult modificarEvento(int? id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                }

                Eventos eve = Publicar.visualizarMantenimientoEventos(id);

                return View(eve);
            }
            else
            {
                return RedirectToAction("getHome", "Home");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult modificarEvento(Eventos eventos)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                Eventos eve = new Eventos();
                if (ModelState.IsValid)
                {
                    eve = Publicar.modificarEventos(eventos);
                    return RedirectToAction("eventoMantenimiento");
                }

                return View(eventos);
            }
            else
            {
                return RedirectToAction("getHome", "Home");
            }
            

        }

        public ActionResult eventosComentar(int? id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }
            
            return View(Publicar.listarEventosComentar(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult eventosComentar(Eventos evento, string coment)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }
            ComentariosEventos comentario = new ComentariosEventos();
            comentario.IDEvento = (int)TempData["Evento"];
            comentario.fecha = DateTime.Now;
            string correo = session.ObtenerSession("correo");
            Usuarios usuario = Usuario.getID(correo);
            comentario.IDUsuario = usuario.ID;
            comentario.mensaje = coment;
            Publicar.comentarEvento(comentario);
            return RedirectToAction("detalleEvento", new { id = (int)TempData["Evento"] });
        }

        public ActionResult detalleEvento(int id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }
            Eventos evento = Publicar.visualizarMantenimientoEventos(id);
            ViewBag.Comentarios = ComentarioEventoBean.getComents(Publicar.getComentariosEventos((int)id));
            TempData["Evento"] = id;
            return View(evento);
        }

        public ActionResult borrarEvento(int? id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Publicar.eliminarEvento(id);
            return RedirectToAction("eventoMantenimiento");
        }

        #endregion

        #region Noticias

        public ActionResult noticiasMantenimiento()
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                ViewBag.Render = true;
            }
            else
            {
                ViewBag.Render = false;
            }

            return View(Publicar.listarNoticias());
        }

        [ValidateInput(false)]
        public ActionResult agregarNoticia()
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

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult agregarNoticia(Noticias noti)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            if (ModelState.IsValid)
            {
                Publicar.AgregarNoticia(noti);
                return RedirectToAction("noticiasMantenimiento");
            }
            return View();
        }

        [ValidateInput(false)]
        public ActionResult modificarNoticia(int? id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

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
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            Noticias noticias = new Noticias();
            if (ModelState.IsValid)
            {
                noticias = Publicar.modificarNoticias(noti);
                return RedirectToAction("noticiasMantenimiento");
            }

            return View(noti);

        }

        public ActionResult noticiasComentar(int? id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }
            return View(Publicar.listarNoticiasComentar(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult noticiasComentar(Noticias noticia, string coment)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }
            ComentariosNoticias comentario = new ComentariosNoticias();
            comentario.IDNoticia = (int)TempData["Noticia"];
            comentario.fecha = DateTime.Now;
            string correo = session.ObtenerSession("correo");
            Usuarios usuario = Usuario.getID(correo);
            comentario.IDUsuario = usuario.ID;
            comentario.mensaje = coment;
            Publicar.comentarNoticia(comentario);
            return RedirectToAction("detalleNoticia", new { id = (int)TempData["Noticia"] });
        }

        public ActionResult detalleNoticia(int id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }
            Noticias noticia = Publicar.visualizarMantenimientoNoticias(id);
            ViewBag.Comentarios = ComentarioNoticiaBean.getComents(Publicar.getComentariosNoticias((int)id));
            TempData["Noticia"] = id;
            return View(noticia);
        }

        public ActionResult borrarNoticia(int? id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Publicar.eliminarNoticia(id);
            return RedirectToAction("noticiasMantenimiento");
        }

        #endregion

        #region Ofertas

        public ActionResult mantenimientoOfertas()
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                ViewBag.Render = true;
            }
            else
            {
                ViewBag.Render = false;
            }

            return View(Publicar.listarOfertas());
        }

        [ValidateInput(false)]
        public ActionResult agregarOferta()
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
        [ValidateInput(false)]
        public ActionResult agregarOferta(Ofertas etofertas)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            if (ModelState.IsValid)
            {
                Publicar.AgregarOferta(etofertas);
                return RedirectToAction("mantenimientoOfertas");
            }
            return View();
        }

        [ValidateInput(false)]
        public ActionResult modificarOferta(int? id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

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
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

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
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }
            return View(Publicar.listarOfertasComentar(id));
        }

        public ActionResult borrarOferta(int? id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Publicar.eliminarOferta(id);
            return RedirectToAction("mantenimientoOfertas");
        }

        #endregion

    }
}