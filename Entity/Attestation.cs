//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _21._102_VorobyevP_4.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Attestation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Attestation()
        {
            this.Vedomosti = new HashSet<Vedomosti>();
        }
    
        public int IdAttestation { get; set; }
        public int IdDiscipline { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int IdTeachers { get; set; }
        public int IdGroup { get; set; }
        public int IdTypeAttestation { get; set; }
        public Nullable<bool> Сompleted { get; set; }
    
        public virtual Group Group { get; set; }
        public virtual Discipline Discipline { get; set; }
        public virtual Teachers Teachers { get; set; }
        public virtual TypeAttestation TypeAttestation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vedomosti> Vedomosti { get; set; }
    }
}
