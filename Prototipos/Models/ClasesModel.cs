using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prototipos.Models
{
    public class ClasesModel
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public string dia { get; set; }
        public string horaInicio { get; set; }
        public string horaFin { get; set; }
    }
}