using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadatakEntity.Models
{
    public interface IRepo
    {
        List<Vehicle> GetVehicles();
        void UpdateVehicle(int id, Vehicle v);
        Vehicle GetVehicle(int id);
        void DeleteVehicle(int id);
        List<ServiceVehicle> GetServiceForVehicle(int vehicleID);
        void UpdateServicesVehicle(int id, ServiceVehicle s);
        ServiceVehicle GetServiceVehicle(int id);
        void DeleteServiceVehicle(int id);
        List<Stavka> GetStavka(int id);
        void InsertServiceVehicle(ServiceVehicle s);
    }
}
