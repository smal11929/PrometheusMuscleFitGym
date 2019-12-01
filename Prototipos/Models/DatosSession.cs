using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prototipos.Models
{
    public class DatosSession
    {
        private static String session;
        

        public String ObtenerSession(String correo)
        {
            session = Convert.ToString(HttpContext.Current.Session[correo]);
            return session;
        }

        public void DarSession(String correo, String dato)
        {
            HttpContext.Current.Session[correo] = dato;
        }

        public void DestruirSession()
        {
            session = null;
            HttpContext.Current.Session["correo"] = null;
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.RemoveAll();
        }





    }
}