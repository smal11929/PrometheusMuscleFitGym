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
    
    public partial class Medidas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medidas()
        {
            this.PlieguesHombres = new HashSet<PlieguesHombres>();
            this.PlieguesMujeres = new HashSet<PlieguesMujeres>();
        }
    
        public int ID { get; set; }
        public int edad { get; set; }
        public double pesoLB { get; set; }
        public double pesoKg { get; set; }
        public double estatura { get; set; }
        public double imc { get; set; }
        public double diametroHumero { get; set; }
        public double diametroFemur { get; set; }
        public double pesoMuscular { get; set; }
        public double pesoResidual { get; set; }
        public double pesoGrasa { get; set; }
        public double pesoOseo { get; set; }
        public double porcentajeGrasa { get; set; }
        public double pesoLibreGrasa { get; set; }
        public double circunferenciaTorax { get; set; }
        public double circuferenciaBrazo { get; set; }
        public double circunferenciaAntebrazo { get; set; }
        public double circuferenciaCintura { get; set; }
        public double circunferenciaCadera { get; set; }
        public double circunferenciaMuslo { get; set; }
        public double circunferenciaPierna { get; set; }
        public System.DateTime fecha { get; set; }
        public int IDUsuario { get; set; }
        public int IDEvaluador { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlieguesHombres> PlieguesHombres { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlieguesMujeres> PlieguesMujeres { get; set; }
        public virtual Usuarios Usuarios1 { get; set; }
    }
}
