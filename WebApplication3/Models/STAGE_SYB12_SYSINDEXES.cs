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
    
    public partial class STAGE_SYB12_SYSINDEXES
    {
        public Nullable<decimal> SVRID_FK { get; set; }
        public Nullable<decimal> DBID_GEN_FK { get; set; }
        public Nullable<decimal> ID_GEN_FK { get; set; }
        public Nullable<decimal> INDID_GEN { get; set; }
        public Nullable<decimal> TABLE_ID { get; set; }
        public string INDEX_NAME { get; set; }
        public string INDEX_DESC { get; set; }
        public string INDEX_KEYS { get; set; }
        public Nullable<int> KEYCNT { get; set; }
        public Nullable<int> INDID { get; set; }
        public Nullable<int> STATUS { get; set; }
        public Nullable<int> STATUS2 { get; set; }
    }
}
