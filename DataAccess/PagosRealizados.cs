//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class PagosRealizados
    {
        public int ID { get; set; }
        public int monto { get; set; }
        public System.DateTime fecha { get; set; }
        public bool descuento { get; set; }
        public int montoDescuento { get; set; }
        public int IDUsuario { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
    }
}
