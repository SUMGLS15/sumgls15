﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GLSOverviewWeb.Models;

namespace GLSOverviewWeb.Viewmodels
{
    public class RegistrationModel {
        public int CarID { get; set; }

        public car Car { get; set; }

        public int EmployeeID { get; set; }

        public employee Employee { get; set; }

        public string Licenseplate { get; set; }
        public string RouteNo { get; set; }
        public string Hauler { get; set; }
        public string Comment { get; set; }
        public IEnumerable<employee> Employees { get; set; }
        public IEnumerable<car> Cars { get; set; } 

    }
}