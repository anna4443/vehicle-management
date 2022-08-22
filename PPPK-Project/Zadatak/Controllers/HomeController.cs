using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Zadatak.Models;

namespace Zadatak.Controllers
{
    public class HomeController : Controller
    {
        private IRepo repo = new Repo(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);

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

        public ActionResult Meni()
        {
            return View();
        }

        public ActionResult PregledVozaca()
        {
            try
            {
                return View(repo.GetVozaci());
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult UrediVozaca(int id)
        {
            try
            {
                return View(repo.GetVozac(id));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult UrediVozaca(Driver model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repo.UpdateVozac(model);
                    ViewBag.poruka = "Podaci vozača uspješno uređeni!";
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
                return View("UrediVozaca", repo.GetVozac(model.IDDriver));
            }
       }

            [HttpGet]
        public ActionResult ObrisiVozaca(int id)
        {
            
                repo.DeleteVozac(id);
                return RedirectToAction("PregledVozaca");
            
        }

        [HttpGet]
        public ActionResult ObrisiVozilo(int id)
        {
            repo.DeleteVozilo(id);
            return RedirectToAction("PregledVozila");
        }

        [HttpGet]
        public ActionResult UnosVozaca()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UnosVozaca(Driver model)
        {
            try
            {
                repo.InsertVozac(model);
                ViewBag.poruka = "Vozač uspješno dodan!";
                return View("Potvrda");
            }
            catch (Exception ex)
            {

                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }

        public ActionResult PregledVozila()
        {
            try
            {
                return View(repo.GetVozila());
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
            //try
            //{
                return View(repo.GetVozilo(id));
            //}
            //catch (Exception ex)
            //{
            //    //ViewBag.error = ex.GetBaseException().Message;
            //    return View("Error");
            //}
        }

        [HttpPost]
        public ActionResult UrediVozilo(Vehicle model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repo.UpdateVozilo(model);
                    ViewBag.poruka = "Podaci vozila uspješno uređeni!";
                    return View("Potvrda2");
                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.GetBaseException().Message;
                    return View("Error");
                }
            }
            else
            {
                return View("UrediVozilo", repo.GetVozilo(model.IDVehicle));
            }
        }

        [HttpGet]
        public ActionResult UnosVozila()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UnosVozila(Vehicle model)
        {
            try
            {
                repo.InsertVozilo(model);
                ViewBag.poruka = "Vozilo uspješno dodano!";
                return View("Potvrda2");
            }
            catch (Exception ex)
            {

                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }

        public ActionResult PregledPutnihNaloga2()
        {
            try
            {
                repo.CreateXML();
                return View("PregledPutnihNaloga2",repo.GetDetailsTravelOrder());
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult UrediNalog(int id)
        {
            try
            {
                //return View(repo.GetNalog(id));
                return View(repo.GetTravelOrder(id));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult UrediNalog(int id, TravelOrderDriverVehicle model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //repo.UpdateNalog(model);
                    repo.UpdateTravelOrder(id, model);
                    ViewBag.poruka = "Podaci naloga uspješno uređeni!";
                    return View("Potvrda3");
                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.GetBaseException().Message;
                    return View("Error");
                }
            }
            else
            {
                //return View("UrediNalog", repo.GetNalog(model.IDTravelOrder));
                return View("UrediNalog", repo.GetTravelOrder(model.IDTravelOrder));
            }
        }

        public ActionResult ObrisiNalog(int id)
        {
            //repo.DeleteNalog(id);
            repo.DeleteTravelOrder(id);
            return RedirectToAction("PregledPutnihNaloga2", "Home");
        }

        [HttpGet]
        public ActionResult UnosNaloga()
        {
            ViewBag.types = repo.GetTypes();
            ViewBag.names = repo.GetVozaci();
            ViewBag.typesVehicle = repo.GetVozila();
            return View();
        }

        [HttpPost]
        public ActionResult UnosNaloga(TravelOrderDriverVehicle model)
        {
            try
            {
                //ViewBag.types = repo.GetTypes();
                //ViewBag.names = repo.GetVozaci();
                //ViewBag.typesVehicle = repo.GetVozila();
                //repo.InsertNalog(model);
                repo.InsertTravelOrder(model);
                ViewBag.poruka = "Nalog uspješno dodan!";
                return View("Potvrda3");
            }
            catch (Exception ex)
            {

                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }

        public ActionResult PrikaziPodatke()
        {
            var data = new List<TravelOrderDriverVehicle>();

            data = repo.ReadXML();

            return View("PrikaziPodatke",data);
        }

        public ActionResult PrikaziPutneNaloge()
        {
            try
            {
                repo.CreateXmlDoc(); 
                return View("PrikaziPutneNaloge", repo.GetDetailsTravelOrder());
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }

        public ActionResult IscitajNaloge()
        {
            try
            {
                repo.ReadXmlDoc();
                return View("IscitajNaloge", repo.GetDetailsTravelOrder());
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }
    }
}