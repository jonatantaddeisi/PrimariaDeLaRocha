//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Maestros_Grupos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Maestros_Grupos()
        {
            this.Maestros_Grupos_Materias = new HashSet<Maestros_Grupos_Materias>();
        }
    
        public int id { get; set; }
        public Nullable<int> id_grupo { get; set; }
        public Nullable<int> id_maestro { get; set; }
    
        public virtual Grupo Grupo { get; set; }
        public virtual Maestro Maestro { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Maestros_Grupos_Materias> Maestros_Grupos_Materias { get; set; }
    }
}
