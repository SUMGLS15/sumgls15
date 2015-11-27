using System;
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
        public car Car { get; set; }
        
        public employee Employee { get; set; }

        public List<employee> Employees { get; set; }

        public string Comment { get; set; }

        // Brugt i Home/ParkCarStep2 view til at vise liste over checks
        public string[] CheckList = {
            "checked cabin and trunk for parcels", 
            "closed all windows", 
            "parked 0,5 m. from the port", 
            "engaged the parking brake", 
            "put the key at the correct spot in the safe" 
        };
    }
}