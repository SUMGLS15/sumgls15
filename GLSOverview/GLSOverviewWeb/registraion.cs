//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GLSOverviewWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class registraion
    {
        public int registraionID { get; set; }
        public Nullable<System.DateTime> registrationDate { get; set; }
        public string comment { get; set; }
        public int registraion_carID { get; set; }
        public int registraion_employeeID { get; set; }
    
        public virtual car car { get; set; }
        public virtual employee employee { get; set; }
    }
}
