//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Develop.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Catalogue
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<short> Qty { get; set; }
        public Nullable<long> Price { get; set; }
        public Nullable<System.DateTime> Createddate { get; set; }
        public bool IsDeleted { get; set; }
    }
}