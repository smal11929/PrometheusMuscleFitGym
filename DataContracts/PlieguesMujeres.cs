//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataContracts
{
    using System;
    using System.Collections.Generic;
    
    public partial class PlieguesMujeres
    {
        public int ID { get; set; }
        public double plieguesSubEscapular { get; set; }
        public double plieguesTriceps { get; set; }
        public double plieguesSubPrailiaco { get; set; }
        public double plieguesMuslo { get; set; }
        public int IDMedidas { get; set; }
    
        public virtual Medidas Medidas { get; set; }
    }
}
