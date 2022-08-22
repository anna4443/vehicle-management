using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zadatak.Models
{
    public class TravelOrderDriverVehicle
    {
        public int IDTravelOrder { get; set; }
        public Driver Driver { get; set; }
        public Vehicle Vehicle { get; set; }
        public string StartPlace { get; set; }
        public string Destination { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public TypeOrder  Order { get; set; }

        public TravelOrderDriverVehicle()
        {

        }
    }
}