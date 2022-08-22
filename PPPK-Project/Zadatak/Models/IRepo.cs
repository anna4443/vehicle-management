using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak.Models
{
    public interface IRepo
    {
        IEnumerable<Driver> GetVozaci();
        Driver GetVozac(int id);
        int UpdateVozac(Driver driver);
        int DeleteVozac(int id);
        IEnumerable<Vehicle> GetVozila();
        Vehicle GetVozilo(int id);
        void InsertVozac(Driver driver);
        int UpdateVozilo(Vehicle vehicle);
        void InsertVozilo(Vehicle vehicle);
        int DeleteVozilo(int id);
        IEnumerable<TravelOrderDriverVehicle> GetTravelOrdersDriversVehicles();
        int UpdateNalog(TravelOrderDriverVehicle travelOrder);
        TravelOrderDriverVehicle GetNalog(int id);
        int DeleteNalog(int id);
        void InsertNalog(TravelOrderDriverVehicle travelOrderDriverVehicle);
        IEnumerable<TypeOrder> GetTypes();
        void CreateXML();
        List<TravelOrderDriverVehicle> ReadXML();
        IEnumerable<TravelOrderDriverVehicle> GetDetailsTravelOrder();
        int InsertTravelOrder(TravelOrderDriverVehicle todv);
        int UpdateTravelOrder(int idOrder, TravelOrderDriverVehicle todv);
        int DeleteTravelOrder(int idOrder);
        TravelOrderDriverVehicle GetTravelOrder(int id);
        void CreateXmlDoc();
        void ReadXmlDoc();
    }
}
