using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zadatak.Models
{
    public class TypeOrder
    {
        public int IDTypeTravelOrder { get; set; }
        public string Name { get; set; }

        public TypeOrder()
        {

        }

        public TypeOrder(string name)
        {
            this.Name = name;
        }
    }
}