using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;

namespace DataLogic
{
    public class Envios
    {
        public static List<Mensaje> listarMensajes()
        {
            List<Mensaje> lista = new List<Mensaje>();
            try
            {
                using (PROMETHEUS_DBEntities db = new PROMETHEUS_DBEntities())
                {
                    lista = db.Mensaje.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lista;
        }



    }
}
