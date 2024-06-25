//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Webbamoscoffe.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Delivery
    {
        public int delivery_id { get; set; }
        public Nullable<int> order_id { get; set; }
        public Nullable<int> deliverer_id { get; set; }
        public Nullable<System.DateTime> assigned_at { get; set; }
        public Nullable<System.DateTime> accepted_at { get; set; }
        public Nullable<System.DateTime> completed_at { get; set; }
        public string status { get; set; }
    
        public virtual Deliverer Deliverer { get; set; }
        public virtual Order Order { get; set; }
    }
}
