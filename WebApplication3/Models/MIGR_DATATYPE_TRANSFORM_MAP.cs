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
    
    public partial class MIGR_DATATYPE_TRANSFORM_MAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MIGR_DATATYPE_TRANSFORM_MAP()
        {
            this.MIGR_DATATYPE_TRANSFORM_RULE = new HashSet<MIGR_DATATYPE_TRANSFORM_RULE>();
        }
    
        public decimal ID { get; set; }
        public decimal PROJECT_ID_FK { get; set; }
        public string MAP_NAME { get; set; }
        public decimal SECURITY_GROUP_ID { get; set; }
        public System.DateTime CREATED_ON { get; set; }
        public string CREATED_BY { get; set; }
        public Nullable<System.DateTime> LAST_UPDATED_ON { get; set; }
        public string LAST_UPDATED_BY { get; set; }
    
        public virtual MD_PROJECTS MD_PROJECTS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MIGR_DATATYPE_TRANSFORM_RULE> MIGR_DATATYPE_TRANSFORM_RULE { get; set; }
    }
}