//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MIGRLOG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MIGRLOG()
        {
            this.MIGRLOG1 = new HashSet<MIGRLOG>();
        }
    
        public decimal ID { get; set; }
        public Nullable<decimal> PARENT_LOG_ID { get; set; }
        public System.DateTime LOG_DATE { get; set; }
        public short SEVERITY { get; set; }
        public string LOGTEXT { get; set; }
        public string PHASE { get; set; }
        public Nullable<decimal> REF_OBJECT_ID { get; set; }
        public string REF_OBJECT_TYPE { get; set; }
        public Nullable<decimal> CONNECTION_ID_FK { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MIGRLOG> MIGRLOG1 { get; set; }
        public virtual MIGRLOG MIGRLOG2 { get; set; }
    }
}
