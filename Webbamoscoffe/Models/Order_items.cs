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
    
    public partial class Order_items
    {
        public int order_item_id { get; set; }
        public Nullable<int> order_id { get; set; }
        public Nullable<int> food_id { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<decimal> price { get; set; }
    
        public virtual Order Order { get; set; }
    }
}