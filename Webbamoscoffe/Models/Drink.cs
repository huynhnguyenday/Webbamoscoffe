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
    
    public partial class Drink
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Drink()
        {
            this.Orders = new HashSet<Order>();
            this.Cart_Item = new HashSet<Cart_Item>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string detail { get; set; }
        public decimal price { get; set; }
        public decimal sell_price { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<int> category_id { get; set; }
        public string image_url { get; set; }
        public string seo_title { get; set; }
        public string seo_description { get; set; }
        public string seo_keywords { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string image { get; set; }
        public string slug { get; set; }
        public bool ishome { get; set; }
        public bool ishot { get; set; }
        public bool issale { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart_Item> Cart_Item { get; set; }
    }
}
