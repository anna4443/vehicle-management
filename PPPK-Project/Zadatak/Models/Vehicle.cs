using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zadatak.Models
{
    public class Vehicle
    {
        public int IDVehicle { get; set; }

        [Required(ErrorMessage = "Obavezan unos")]
        [Display(Name = "Type vehicle")]
        public string TypeVehicle { get; set; }

        [Required(ErrorMessage = "Obavezan unos")]
        [Display(Name = "Mark vehicle")]
        public string MarkVehicle { get; set; }

        [Required(ErrorMessage = "Obavezan unos")]
        [Display(Name = "Year production")]
        public int YearProduction { get; set; }

        [Required(ErrorMessage = "Obavezan unos")]
        [Display(Name = "Initial moment of kilometers")]
        public int InitialMomentOfKM { get; set; }

        public Vehicle()
        {

        }

        public Vehicle(string type, string mark, int year, int initialKM)
        {
            this.TypeVehicle = type;
            this.MarkVehicle = mark;
            this.YearProduction = year;
            this.InitialMomentOfKM = initialKM;
        }
    }
}