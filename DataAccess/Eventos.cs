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
    
    public partial class Eventos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Eventos()
        {
            this.ComentariosEventos = new HashSet<ComentariosEventos>();
            this.referenciaUsuarios_referenciaEventos = new HashSet<referenciaUsuarios_referenciaEventos>();
        }
    
        public int ID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public System.DateTime fechaRealizacion { get; set; }
        public System.DateTime fechaPublicacion { get; set; }
        public int costo { get; set; }
        public byte[] imagen { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComentariosEventos> ComentariosEventos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<referenciaUsuarios_referenciaEventos> referenciaUsuarios_referenciaEventos { get; set; }
    }
}
