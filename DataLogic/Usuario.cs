using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLogic
{
    public class Usuario
    {
        
        public static Usuarios Login(string correo, string pass)
        {
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    var paso = db.Usuarios.Where(x => x.correo == correo&&x.tipo!="Cliente"&&x.tipo!="Invitado"&&x.habilitado).FirstOrDefault();
                    string password = paso.contrasena;
                    pass = Encriptado.Encriptar(pass);
                    var miUser = db.Usuarios.Where(x => x.correo ==  correo && password == pass && x.tipo != "Cliente" && x.tipo != "Invitado"&&x.habilitado).FirstOrDefault();

                    if (miUser == null)
                    {
                        miUser = new Usuarios();
                    }
                    return miUser;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Usuarios getID(string correo)
        {
            try
            {
                Usuarios usuario;
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    usuario= db.Usuarios.Where(o => o.correo == correo).FirstOrDefault();
                    return usuario;
                }
            }catch(Exception e)
            {
                return null;
            }
            
                
        }

        public static Usuarios getUser(int id)
        {
            try
            {
                Usuarios usuario;
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    usuario = db.Usuarios.Find(id);
                    return usuario;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }



    }
}
