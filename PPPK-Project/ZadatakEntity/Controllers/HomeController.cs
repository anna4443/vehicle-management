using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZadatakEntity.Models;

namespace ZadatakEntity.Controllers
{
    public class HomeController : Controller
    {
        private IRepo repo = new Repo();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MeniOptions()
        {
            return View();
        }

        public ActionResult PrikaziVozila()
        {
            try
            {
               
                return View("PrikaziVozila", repo.GetVehicles());
            }
            catch (Exception ex)
            {

                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult UrediVozilo(int id)
        {
            try
            {
                
                return View(repo.GetVehicle(id));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult UrediVozilo(int id, Vehicle model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repo.UpdateVehicle(id, model);
                    ViewBag.poruka = "Podaci vozila uspješno uređeni!";
                    return View("Potvrda");
                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.GetBaseException().Message;
                    return View("Error");
                }
            }
            else
            {
                return View("UrediVozilo", repo.GetVehicle(model.IDVehicle));
            }
        }

        [HttpGet]
        public ActionResult ObrisiVozilo(int id)
        {
            repo.DeleteVehicle(id);

            return RedirectToAction("PrikaziVozila");
        }

        [HttpGet]
        public ActionResult PrikaziServise(int id)
        {
            try
            {
                return View("PrikaziServise", repo.GetServiceForVehicle(id));
            }
            catch (Exception ex)
            {

                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult UrediServis(int id)
        {
            try
            {

                return View(repo.GetServiceVehicle(id));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult UrediServis(int id, ServiceVehicle model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repo.UpdateServicesVehicle(id, model);
                    ViewBag.poruka = "Podaci vozila uspješno uređeni!";
                    return View("Potvrda");
                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.GetBaseException().Message;
                    return View("Error");
                }
            }
            else
            {
                return View("UrediServis", repo.GetServiceVehicle(model.IDServiceVehicle));
            }
        }

        [HttpGet]
        public ActionResult ObrisiServis(int id)
        {
            try
            {
                repo.DeleteServiceVehicle(id);

                return RedirectToAction("PrikaziServise");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.GetBaseException().Message;
                return View("ErrorDelete");
            }
        }

        [HttpGet]
        public ActionResult PrikaziStavke(int id)
        {
            try
            {
                return View("PrikaziStavke", repo.GetStavka(id));
            }
            catch (Exception ex)
            {

                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult UnosServisa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UnosServisa(ServiceVehicle model)
        {
            try
            {
                repo.InsertServiceVehicle(model);
                ViewBag.poruka = "Servis uspješno dodan!";
                return View("Potvrda");
            }
            catch (Exception ex)
            {

                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }

    }
}