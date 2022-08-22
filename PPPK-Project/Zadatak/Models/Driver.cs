using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zadatak.Models
{
    public class Driver
    {
        public int IDDriver { get; set; }

        [Required(ErrorMessage = "Obavezan unos")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Obavezan unos")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Obavezan unos")]
        public string MobilePhone { get; set; }

        [Required(ErrorMessage = "Obavezan unos")]
        [Display(Name = "Licence number")]
        public string DriversLicenseNumber { get; set; }

        public Driver()
        {

        }

        public Driver(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
    }
}