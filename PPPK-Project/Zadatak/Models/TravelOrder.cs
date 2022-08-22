using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zadatak.Models
{
    public class TravelOrder
    {
        public int IDTravelOrder { get; set; }

        [Display(Name = "Driver")]
        public int DriverID { get; set; }

        [Display(Name = "Vehicle")]
        public int VehicleID { get; set; }

        [Display(Name = "Start place")]
        public string StartPlace { get; set; }

        public string Destination { get; set; }


        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        [Display(Name = "Type order")]
        public int TypeOrderID { get; set; }
    }
}