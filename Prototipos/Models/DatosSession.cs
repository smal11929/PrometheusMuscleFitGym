using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prototipos.Models
{
    public class DatosSession
    {
        private String session;
        

        public String ObtenerSession(String correo)
        {
            this.session = Convert.ToString(HttpContext.Current.Session[correo]);
            return session;
        }

        public void DarSession(String correo, String dato)
        {
            HttpContext.Current.Session[correo] = dato;
        }

        public void DestruirSession()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.RemoveAll();
        }





    }
}