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
    
    public partial class MD_MIGR_PARAMETER
    {
        public decimal ID { get; set; }
        public decimal CONNECTION_ID_FK { get; set; }
        public decimal OBJECT_ID { get; set; }
        public string OBJECT_TYPE { get; set; }
        public decimal PARAM_EXISTING { get; set; }
        public decimal PARAM_ORDER { get; set; }
        public string PARAM_NAME { get; set; }
        public string PARAM_TYPE { get; set; }
        public string PARAM_DATA_TYPE { get; set; }
        public Nullable<decimal> PERCISION { get; set; }
        public Nullable<decimal> SCALE { get; set; }
        public string NULLABLE { get; set; }
        public string DEFAULT_VALUE { get; set; }
        public decimal SECURITY_GROUP_ID { get; set; }
        public System.DateTime CREATED_ON { get; set; }
        public string CREATED_BY { get; set; }
        public Nullable<System.DateTime> LAST_UPDATED_ON { get; set; }
        public string LAST_UPDATED_BY { get; set; }
    
        public virtual MD_CONNECTIONS MD_CONNECTIONS { get; set; }
    }
}
