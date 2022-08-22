using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zadatak.Models
{
    public static class CustomHelperi
    {
        public static MvcHtmlString DDLImenaVozaca(this HtmlHelper html, List<Driver> kolekcijaVozaca)
        {
            TagBuilder selectTag = new TagBuilder("select");
            selectTag.MergeAttribute("id", "DriverID");
            selectTag.MergeAttribute("name", "DriverID");
            foreach (Driver d in kolekcijaVozaca)
            {
                TagBuilder optionTag = new TagBuilder("option");
                optionTag.MergeAttribute("value", d.IDDriver.ToString());
                optionTag.SetInnerText(d.Name);
                selectTag.InnerHtml += optionTag.ToString();
            }
            return new MvcHtmlString(selectTag.ToString());
        }

        public static MvcHtmlString DDLPrezimenaVozaca(this HtmlHelper html, List<Driver> kolekcijaVozaca)
        {
            TagBuilder selectTag = new TagBuilder("select");
            selectTag.MergeAttribute("id", "DriverID");
            selectTag.MergeAttribute("surname", "DriverID");
            foreach (Driver d in kolekcijaVozaca)
            {
                TagBuilder optionTag = new TagBuilder("option");
                optionTag.MergeAttribute("value", d.IDDriver.ToString());
                optionTag.SetInnerText(d.Surname);
                selectTag.InnerHtml += optionTag.ToString();
            }
            return new MvcHtmlString(selectTag.ToString());
        }

        public static MvcHtmlString DDLVozila(this HtmlHelper html, List<Vehicle> kolekcijaVozila)
        {
            TagBuilder selectTag = new TagBuilder("select");
            selectTag.MergeAttribute("id", "DriverID");
            selectTag.MergeAttribute("name", "DriverID");
            foreach (Vehicle v in kolekcijaVozila)
            {
                TagBuilder optionTag = new TagBuilder("option");
                optionTag.MergeAttribute("value", v.IDVehicle.ToString());
                optionTag.SetInnerText(v.MarkVehicle);
                selectTag.InnerHtml += optionTag.ToString();
            }
            return new MvcHtmlString(selectTag.ToString());
        }
    }
}