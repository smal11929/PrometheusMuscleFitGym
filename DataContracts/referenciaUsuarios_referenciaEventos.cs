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
    
    public partial class referenciaUsuarios_referenciaEventos
    {
        public int ID { get; set; }
        public Nullable<int> IDUsuario { get; set; }
        public Nullable<int> IDEvento { get; set; }
    
        public virtual Eventos Eventos { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
