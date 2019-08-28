using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prototipos.Models
{
    public class MedidasMujer
    {
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
        public double plieguesSubEscapular { get; set; }
        public double plieguesTriceps { get; set; }
        public double plieguesSubPrailiaco { get; set; }
        public double plieguesMuslo { get; set; }
    }
}