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
    
    public partial class Employee
    {
        public int employee_id { get; set; }
        public Nullable<int> account_id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    
        public virtual Account Account { get; set; }
    }
}
