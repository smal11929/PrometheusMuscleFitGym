using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic
{
    public class Seguridad
    {
        public static void AgregarCliente(Usuarios elUsuario)
        {
            //string textEncryp = elUsuario.contrasena;
            //var contra = Encriptado.Encriptar(textEncryp);
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    db.insertUsuarios(elUsuario.cedula,
                    elUsuario.nombre,
                    elUsuario.apellido1,
                    elUsuario.apellido2,
                    elUsuario.correo,
                    Encriptado.Encriptar(elUsuario.contrasena),
                    elUsuario.tipo,
                    elUsuario.sexo,
                    elUsuario.telefono1,
                    elUsuario.telefono2,
                    elUsuario.ocupacion,
                    elUsuario.estadoCivil,
                    elUsuario.habilitado = true,
                    elUsuario.fechaIngreso,
                    elUsuario.fechaPago,
                    elUsuario.IDRutina);

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

            
        }

        public static Usuarios modificarCliente(Usuarios miUser)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    db.updateUsuario(miUser.ID,
                    miUser.cedula,
                    miUser.nombre,
                    miUser.apellido1,
                    miUser.apellido2,
                    miUser.correo,
                    Encriptado.Encriptar(miUser.contrasena),
                    miUser.tipo,
                    miUser.sexo,
                    miUser.telefono1,
                    miUser.telefono2,
                    miUser.ocupacion,
                    miUser.estadoCivil,
                    miUser.habilitado,
                    miUser.fechaIngreso,
                    miUser.fechaPago,
                    miUser.IDRutina);

                    db.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return miUser;
        }

        public static Usuarios visualizarModificarCliente(int? id)
        {
            Usuarios ElUsu = new Usuarios();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    ElUsu = db.Usuarios.Find(id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return ElUsu;
        }

        public static List<Usuarios> listarClientes()
        {
            List<Usuarios> lista = new List<Usuarios>();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    lista = db.Usuarios.ToList();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lista;
        }

        public static Usuarios cambiaContraseña(Usuarios usuarios, String confirmPass)
        {
            Usuarios pass = new Usuarios();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    usuarios = db.Usuarios.Where(o => o.cedula == usuarios.cedula).FirstOrDefault();
                    pass = db.Usuarios.Where(x => x.contrasena == usuarios.contrasena && x.cedula == usuarios.cedula).FirstOrDefault();
                    if (pass == null)
                    {
                        pass = new Usuarios();
                    }
                    else
                    {
                        pass.contrasena = Encriptado.Encriptar(confirmPass);
                        db.Entry(pass).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return pass;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






    }
}
