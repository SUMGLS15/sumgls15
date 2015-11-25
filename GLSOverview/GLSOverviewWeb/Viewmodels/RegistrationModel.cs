﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GLSOverviewWeb.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GLSOverviewWeb.Viewmodels
{
    public class RegistrationModel
    {
        public int CarID { get; set; }

        public car Car { get; set; }

        public int EmployeeID { get; set; }

        public employee Employee { get; set; }

        [DisplayName("License Plate: ")]
        public string Licenseplate { get; set; }
        [DisplayName("Route: ")]
        public string RouteNo { get; set; }
        public string Hauler { get; set; }
        public string Comment { get; set; }
        public IEnumerable<employee> Employees { get; set; }
        public IEnumerable<car> Cars { get; set; }

        public string[] CheckList = new string[5] {
            "Check cabin and trunk for parcels", 
            "Close all windows", 
            "Park 0,5 m. from the port", 
            "Engaged the parking brake", 
            "Put the key at the correct spot in the safe" 
        };

        [DisplayName("Show overview for date")]
        [DataType(DataType.DateTime)]
        public DateTime? ShowDate { get; set; }

    }
}