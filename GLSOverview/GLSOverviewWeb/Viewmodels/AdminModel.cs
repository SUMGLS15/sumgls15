using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GLSOverviewWeb.Models;

namespace GLSOverviewWeb.Viewmodels {
    public class AdminModel {

        public int EmployeeID { get; set; }
        public int CarID { get; set; }
        public employee Employee { get; set; }
        public car Car { get; set; }
        public int RegID { get; set; }
        public registration Registration { get; set; }

        public virtual List<registration> RegistrationList { get; set; }
    }
}