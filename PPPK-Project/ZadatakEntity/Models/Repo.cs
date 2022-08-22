using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZadatakEntity.Models
{
    public class Repo : IRepo
    {
        public void DeleteServiceVehicle(int id)
        {
            using (var db = new VehicleManagementEntities1())
            {
                ServiceVehicle s = db.ServiceVehicle.Find(id); // uvjet u sqlu!
                db.ServiceVehicle.Remove(s);

                db.SaveChanges();
            }
        }

        public void DeleteVehicle(int id)
        {
            using (var db = new VehicleManagementEntities1())
            {
                Vehicle v = db.Vehicle.Find(id); // uvjet u sqlu!
                db.Vehicle.Remove(v);

                db.SaveChanges();
            }
        }

        public List<ServiceVehicle> GetServiceForVehicle(int id)
        {
            using (var db = new VehicleManagementEntities1())
            {

                return db.ServiceVehicle.Where(s => s.Vehicle.IDVehicle == id).ToList();
                
            }

        }

        public ServiceVehicle GetServiceVehicle(int id)
        {
            using (var db = new VehicleManagementEntities1())
            {
                foreach (var service in db.ServiceVehicle)
                {
                    if (id == service.IDServiceVehicle)
                    {
                        return service;
                    }
                }
                return null;
            }
        }

        public List<Stavka> GetStavka(int id)
        {
            using (var db = new VehicleManagementEntities1())
            {

                 return db.Stavka.Where(s => s.ServiceVehicle.IDServiceVehicle == id).ToList();
            }
        }

        public Vehicle GetVehicle(int id)
        {
            using (var db = new VehicleManagementEntities1())
            {
                foreach (var vehicle in db.Vehicle)
                {
                    if (id == vehicle.IDVehicle)
                    {
                        return vehicle;
                    }
                }
                return null;
            }
        }

        public List<Vehicle> GetVehicles()
        {
            using (var db = new VehicleManagementEntities1())
            {
                //List<Vehicle> vehicles = new List<Vehicle>(db.Vehicle);

                //return vehicles;

                return db.Vehicle.ToList();
            } 
        }

        public void InsertServiceVehicle(ServiceVehicle s)
        {
            using (var db = new VehicleManagementEntities1())
            {
                db.ServiceVehicle.Add(s);
                db.SaveChanges();
            }
        }

        public void UpdateServicesVehicle(int id, ServiceVehicle s)
        {
            using (var db = new VehicleManagementEntities1())
            {
                ServiceVehicle dbServiceVehicle = db.ServiceVehicle.Find(id); // zbog wherea u sqlu
                dbServiceVehicle.VehicleID = s.VehicleID;
                dbServiceVehicle.ChangeTire = s.ChangeTire;
                dbServiceVehicle.ChangeBelt = s.ChangeBelt;

                db.SaveChanges();
            }
        }

        public void UpdateVehicle(int id, Vehicle v)
        {
            using (var db = new VehicleManagementEntities1())
            {
                Vehicle dbVehicle = db.Vehicle.Find(id); // zbog wherea u sqlu
                dbVehicle.TypeVehicle = v.TypeVehicle;
                dbVehicle.MarkVehicle = v.MarkVehicle;
                dbVehicle.YearProduction = v.YearProduction;
                dbVehicle.InitialMomentOfKM = v.InitialMomentOfKM;

                db.SaveChanges();
            }
        }
    }
}