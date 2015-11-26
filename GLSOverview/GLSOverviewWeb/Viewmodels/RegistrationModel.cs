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

        // === Brugt ifm. registration (altså, det der rent faktisk skal ligge i registration model)

        // Brugt i Home/Index view når der klikkes på en bil
        // Brugt i HomeController/EmployeesLogin til at gemme rm.Car 
        // Brugt i Home/EmployeesLogin view til til at vælge bil (querystring-parameter)
        // Brugt i HomeController/RegisterCarChecked til at gemme rm.Car (dvs. EmployeesLogin behøver ikke gemme car)
        public int CarID { get; set; }

        // Brugt i Home controller og Home/Index view
        public IEnumerable<car> Cars { get; set; }

        // Licenseplate, RouteNo og Hauler brugt i Home/Index view, men kun som overskrifter (@Html.DisplayNameFor(model => model.Licenseplate))
        [DisplayName("License Plate: ")]
        public string Licenseplate { get; set; }
        [DisplayName("Route: ")]
        public string RouteNo { get; set; }
        public string Hauler { get; set; }

        // Brugt i Home/Index view til at vise Car.Position
        // Brugt i Home/EmployeesLogin view til at vise Car.Licenseplate
        // Brugt i Home/RegisterCarChecked view til at vise Car.Licenseplate samt Car.Licenseplate (igen) og Car.Position
        public car Car { get; set; }

        // Brugt i HomeController/RegisterCarChecked til at gemme Employee
        public int EmployeeID { get; set; }

        // Brugt i Home/RegisterCarChecked view til at vise Employee.Name
        public employee Employee { get; set; }

        // Gemmes i HomeController/EmployeesLogin
        // Brugt i Home/EmployeesLogin view til at vise 2 lister over employees
        public IEnumerable<employee> Employees { get; set; }

        // Brugt i Home/RegisterCarChecked view til at vise tekstboks med Comment input
        public string Comment { get; set; }

        // Brugt i Home/RegisterCarChecked view til at vise liste over checks
        public string[] CheckList = new string[5] {
            "Check cabin and trunk for parcels", 
            "Close all windows", 
            "Park 0,5 m. from the port", 
            "Engaged the parking brake", 
            "Put the key at the correct spot in the safe" 
        };
        
        // === Det der ikke bliver brugt ifm. registration
        
        [DisplayName("Show overview for date")]
        [DataType(DataType.DateTime)]
        public DateTime? ShowDate { get; set; }

    }
}