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
    
    public partial class MD_GROUPS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MD_GROUPS()
        {
            this.MD_GROUP_MEMBERS = new HashSet<MD_GROUP_MEMBERS>();
            this.MD_GROUP_MEMBERS1 = new HashSet<MD_GROUP_MEMBERS>();
            this.MD_GROUP_PRIVILEGES = new HashSet<MD_GROUP_PRIVILEGES>();
        }
    
        public decimal ID { get; set; }
        public decimal SCHEMA_ID_FK { get; set; }
        public string GROUP_NAME { get; set; }
        public string GROUP_FLAG { get; set; }
        public string NATIVE_SQL { get; set; }
        public string NATIVE_KEY { get; set; }
        public string COMMENTS { get; set; }
        public decimal SECURITY_GROUP_ID { get; set; }
        public System.DateTime CREATED_ON { get; set; }
        public string CREATED_BY { get; set; }
        public Nullable<System.DateTime> LAST_UPDATED_ON { get; set; }
        public string LAST_UPDATED_BY { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MD_GROUP_MEMBERS> MD_GROUP_MEMBERS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MD_GROUP_MEMBERS> MD_GROUP_MEMBERS1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MD_GROUP_PRIVILEGES> MD_GROUP_PRIVILEGES { get; set; }
        public virtual MD_SCHEMAS MD_SCHEMAS { get; set; }
    }
}