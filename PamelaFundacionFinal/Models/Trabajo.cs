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
    
    public partial class Trabajo
    {
        public Trabajo()
        {
            this.Tutor = new HashSet<Tutor>();
        }
    
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    
        public virtual ICollection<Tutor> Tutor { get; set; }
    }
}
