//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GLSOverviewWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class registration
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Comment { get; set; }
        public int CarId { get; set; }
        public int EmployeeId { get; set; }
    
        public virtual car car { get; set; }
        public virtual employee employee { get; set; }
    }
}