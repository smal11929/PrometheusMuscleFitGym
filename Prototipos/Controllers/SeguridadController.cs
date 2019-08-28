using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataContracts;
using DataLogic;

namespace Prototipos.Controllers
{
    public class SeguridadController : Controller
    {
        // GET: Seguridad
        public ActionResult Index()
        {
            return View();
        }

        //GET://
        public ActionResult seguridadCambiarContraseña()
        {
            return View(HomeController.Usercedula);
        }

        //POST://
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult seguridadCambiarContraseña(Usuarios usuarios, FormCollection formCollection)
        {
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
            return View();
        }

        
        public ActionResult seguridadMantenimientoClientes()
        {
            return View(Seguridad.listarClientes());
        }

        public ActionResult agregarCliente()
        {
            #region viewbag

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

            #endregion

            return View();
        }

        [HttpPost]
        public ActionResult agregarCliente(Usuarios miUser)
        {
            #region viewbag

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

            #endregion
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
            #region viewbag

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

            #endregion

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Usuarios usuario = Seguridad.visualizarModificarCliente(id);

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult modificarCliente(Usuarios miUser)
        {
            #region viewbag Tipo

            List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem { Text = "Administrador", Value = "Administrador" });
            lst.Add(new SelectListItem { Text = "Cliente", Value = "Cliente" });
            lst.Add(new SelectListItem { Text = "Entrenador", Value = "Entrenador" });
            lst.Add(new SelectListItem { Text = "Contador", Value = "Contador" });
            lst.Add(new SelectListItem { Text = "Secretaria", Value = "Secretaria" });

            ViewBag.OpcionesTipo = lst;

            #endregion

            #region Viewbag civil

            List<SelectListItem> civil = new List<SelectListItem>();

            civil.Add(new SelectListItem { Text = "Casado / a", Value = "Casado(a)" });
            civil.Add(new SelectListItem { Text = "Soltero / a", Value = "Soltero(a)" });
            civil.Add(new SelectListItem { Text = "Viudo / a", Value = "Vuido(a)" });
            civil.Add(new SelectListItem { Text = "Divorciado / a", Value = "Divorciado(a)" });

            ViewBag.OpcionesCivil = civil;

            #endregion

            #region Viewbag sexo

            List<SelectListItem> sexo = new List<SelectListItem>();

            sexo.Add(new SelectListItem { Text = "Masculino", Value = "m" });
            sexo.Add(new SelectListItem { Text = "Femenino", Value = "f" });

            ViewBag.OpcionesSexo = sexo;

            #endregion

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
            return View(Seguridad.listarClientes());
        }

        
    }
}