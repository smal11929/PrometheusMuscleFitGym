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
    public class SeguridadController : Controller
    {
        DatosSession session = new DatosSession();

        // GET: Seguridad
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

        //GET://
        public ActionResult seguridadCambiarContraseña()
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            return View(HomeController.Usercedula);
        }

        //POST://
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult seguridadCambiarContraseña(Usuarios usuarios, FormCollection formCollection)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            var nuevaPass = formCollection["nuevacontraseña"];
            var confirmPass = formCollection["confirmarcontraseña"];

            if (nuevaPass == confirmPass)
            {
                var validate = Seguridad.cambiaContraseña(usuarios, nuevaPass);
                if (validate.contrasena == null)
                {
                    return RedirectToAction("seguridadCambiarContraseña", "Seguridad");
                }
                else
                {
                    return RedirectToAction("principalAdministrador", "Home");
                }
            }

            return RedirectToAction("seguridadCambiarContraseña", "Seguridad");
        }

        public ActionResult seguridadMantenimientoUsuarios()
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

        
        public ActionResult seguridadMantenimientoClientes()
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

        public ActionResult agregarCliente()
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem { Text = "Cliente", Value = "Cliente" });
            lst.Add(new SelectListItem { Text = "Administrador", Value = "Administrador" });
            lst.Add(new SelectListItem { Text = "Entrenador", Value = "Entrenador" });
            lst.Add(new SelectListItem { Text = "Contador", Value = "Contador" });
            lst.Add(new SelectListItem { Text = "Secretaria", Value = "Secretaria" });

            ViewBag.OpcionesTipo = lst;

            List<SelectListItem> civil = new List<SelectListItem>();

            civil.Add(new SelectListItem { Text = "Casado / a", Value = "Casado(a)" });
            civil.Add(new SelectListItem { Text = "Soltero / a", Value = "Soltero(a)" });
            civil.Add(new SelectListItem { Text = "Viudo / a", Value = "Vuido(a)" });
            civil.Add(new SelectListItem { Text = "Divorciado / a", Value = "Divorciado(a)" });

            ViewBag.OpcionesCivil= civil;

            List<SelectListItem> sexo = new List<SelectListItem>();

            sexo.Add(new SelectListItem { Text = "Masculino", Value = "m" });
            sexo.Add(new SelectListItem { Text = "Femenino", Value = "f" });

            ViewBag.OpcionesSexo = sexo;


            return View();
        }

        [HttpPost]
        public ActionResult agregarCliente(Usuarios miUser)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem { Text = "Administrador", Value = "Administrador" });
            lst.Add(new SelectListItem { Text = "Cliente", Value = "Cliente" });
            lst.Add(new SelectListItem { Text = "Entrenador", Value = "Entrenador" });
            lst.Add(new SelectListItem { Text = "Contador", Value = "Contador" });
            lst.Add(new SelectListItem { Text = "Secretaria", Value = "Secretaria" });

            ViewBag.OpcionesTipo = lst;

            List<SelectListItem> civil = new List<SelectListItem>();

            civil.Add(new SelectListItem { Text = "Casado / a", Value = "Casado(a)" });
            civil.Add(new SelectListItem { Text = "Soltero / a", Value = "Soltero(a)" });
            civil.Add(new SelectListItem { Text = "Viudo / a", Value = "Vuido(a)" });
            civil.Add(new SelectListItem { Text = "Divorciado / a", Value = "Divorciado(a)" });

            ViewBag.OpcionesCivil = civil;

            List<SelectListItem> sexo = new List<SelectListItem>();

            sexo.Add(new SelectListItem { Text = "Masculino", Value = "m" });
            sexo.Add(new SelectListItem { Text = "Femenino", Value = "f" });

            ViewBag.OpcionesSexo = sexo;

            try
            {
                if (ModelState.IsValid)
                {
                    Seguridad.AgregarCliente(miUser);
                    return RedirectToAction("seguridadMantenimientoClientes");
                }
                return RedirectToAction("seguridadMantenimientoUsuarios");
            }
            catch (Exception e)
            {
                return View();
            }
            
        }

        
        public ActionResult modificarCliente(int? id)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem { Text = "Administrador", Value = "Administrador" });
            lst.Add(new SelectListItem { Text = "Cliente", Value = "Cliente" });
            lst.Add(new SelectListItem { Text = "Entrenador", Value = "Entrenador" });
            lst.Add(new SelectListItem { Text = "Contador", Value = "Contador" });
            lst.Add(new SelectListItem { Text = "Secretaria", Value = "Secretaria" });

            ViewBag.OpcionesTipo = lst;

            List<SelectListItem> civil = new List<SelectListItem>();

            civil.Add(new SelectListItem { Text = "Casado / a", Value = "Casado(a)" });
            civil.Add(new SelectListItem { Text = "Soltero / a", Value = "Soltero(a)" });
            civil.Add(new SelectListItem { Text = "Viudo / a", Value = "Vuido(a)" });
            civil.Add(new SelectListItem { Text = "Divorciado / a", Value = "Divorciado(a)" });

            ViewBag.OpcionesCivil = civil;

            List<SelectListItem> sexo = new List<SelectListItem>();

            sexo.Add(new SelectListItem { Text = "Masculino", Value = "m" });
            sexo.Add(new SelectListItem { Text = "Femenino", Value = "f" });

            ViewBag.OpcionesSexo = sexo;

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            List<SelectListItem> rutinas = new List<SelectListItem>();
            foreach (DataContracts.Rutinas rut in DataLogic.Rutinas.getRutinas())
            {
                rutinas.Add(new SelectListItem { Text = rut.nombre, Value = rut.ID.ToString() });
            }

            ViewBag.Rutinas = rutinas;

            Usuarios usuario = Seguridad.visualizarModificarCliente(id);

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult modificarCliente(Usuarios miUser)
        {
            if (session.ObtenerSession("correo").Equals(""))
            {
                return RedirectToAction("error404", "Home");
            }

            if (!Seguridad.isAdmin(session.ObtenerSession("correo")))
            {
                return RedirectToAction("getHome", "Home");
            }

            List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem { Text = "Administrador", Value = "Administrador" });
            lst.Add(new SelectListItem { Text = "Cliente", Value = "Cliente" });
            lst.Add(new SelectListItem { Text = "Entrenador", Value = "Entrenador" });
            lst.Add(new SelectListItem { Text = "Contador", Value = "Contador" });
            lst.Add(new SelectListItem { Text = "Secretaria", Value = "Secretaria" });

            ViewBag.OpcionesTipo = lst;

            List<SelectListItem> civil = new List<SelectListItem>();

            civil.Add(new SelectListItem { Text = "Casado / a", Value = "Casado(a)" });
            civil.Add(new SelectListItem { Text = "Soltero / a", Value = "Soltero(a)" });
            civil.Add(new SelectListItem { Text = "Viudo / a", Value = "Vuido(a)" });
            civil.Add(new SelectListItem { Text = "Divorciado / a", Value = "Divorciado(a)" });

            ViewBag.OpcionesCivil = civil;

            List<SelectListItem> sexo = new List<SelectListItem>();

            sexo.Add(new SelectListItem { Text = "Masculino", Value = "m" });
            sexo.Add(new SelectListItem { Text = "Femenino", Value = "f" });

            ViewBag.OpcionesSexo = sexo;

            List<SelectListItem> rutinas = new List<SelectListItem>();
            foreach(DataContracts.Rutinas rut in DataLogic.Rutinas.getRutinas()){
                rutinas.Add(new SelectListItem { Text = rut.nombre, Value = rut.ID.ToString() });
            }

            ViewBag.Rutinas = rutinas;

            Usuarios usuario = new Usuarios();

            if (ModelState.IsValid)
            {
                usuario = Seguridad.modificarCliente(miUser);
                return RedirectToAction("seguridadMantenimientoClientes");
            }
            

            return View(usuario);
        }

        public ActionResult solicitudCliente()
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

        
    }
}