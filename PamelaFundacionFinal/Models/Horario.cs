//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PamelaFundacionFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Horario
    {
        public int Organizacion_ID { get; set; }
        public int Becado_ID { get; set; }
        public string Actividad { get; set; }
        public string Lu { get; set; }
        public string Ma { get; set; }
        public string Mi { get; set; }
        public string Ju { get; set; }
        public string Vi { get; set; }
        public string Sa { get; set; }
        public int Horas { get; set; }
    
        public virtual Becado Becado { get; set; }
        public virtual Organizacion Organizacion { get; set; }
    }
}
