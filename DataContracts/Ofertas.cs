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
    
    public partial class Ofertas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ofertas()
        {
            this.referenciaUsuarios_referenciaOfertas = new HashSet<referenciaUsuarios_referenciaOfertas>();
        }
    
        public int ID { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public int porcentaje { get; set; }
        public int monto { get; set; }
        public System.DateTime fechaInicio { get; set; }
        public System.DateTime fechaFin { get; set; }
        public byte[] imagen { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<referenciaUsuarios_referenciaOfertas> referenciaUsuarios_referenciaOfertas { get; set; }
    }
}