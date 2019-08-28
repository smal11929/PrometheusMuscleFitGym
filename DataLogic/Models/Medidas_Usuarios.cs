using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataContracts;

namespace Prototipos.Models
{
    public class Medidas_Usuarios
    {
        public Usuarios Usuarios { get; set; }
        public Medidas Medidas { get; set; }
        public PlieguesHombres PlieguesHombres { get; set; }
        public PlieguesMujeres PlieguesMujeres { get; set; }
    }
}