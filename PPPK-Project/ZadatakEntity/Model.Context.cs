﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZadatakEntity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class VehicleManagementEntities1 : DbContext
    {
        public VehicleManagementEntities1()
            : base("name=VehicleManagementEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<ServiceVehicle> ServiceVehicle { get; set; }
        public virtual DbSet<Stavka> Stavka { get; set; }
        public virtual DbSet<TravelOrder> TravelOrder { get; set; }
        public virtual DbSet<TypeTravelOrder> TypeTravelOrder { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
    
        public virtual int DeleteDriver(Nullable<int> driverAjdi)
        {
            var driverAjdiParameter = driverAjdi.HasValue ?
                new ObjectParameter("DriverAjdi", driverAjdi) :
                new ObjectParameter("DriverAjdi", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteDriver", driverAjdiParameter);
        }
    
        public virtual int DeleteServicesVehicle(Nullable<int> ajdiServicesVehicle)
        {
            var ajdiServicesVehicleParameter = ajdiServicesVehicle.HasValue ?
                new ObjectParameter("AjdiServicesVehicle", ajdiServicesVehicle) :
                new ObjectParameter("AjdiServicesVehicle", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteServicesVehicle", ajdiServicesVehicleParameter);
        }
    
        public virtual int DeleteTravelOrder(Nullable<int> travelOrderAjdi)
        {
            var travelOrderAjdiParameter = travelOrderAjdi.HasValue ?
                new ObjectParameter("TravelOrderAjdi", travelOrderAjdi) :
                new ObjectParameter("TravelOrderAjdi", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteTravelOrder", travelOrderAjdiParameter);
        }
    
        public virtual int DeleteVehicle(Nullable<int> vehicleAjdi)
        {
            var vehicleAjdiParameter = vehicleAjdi.HasValue ?
                new ObjectParameter("VehicleAjdi", vehicleAjdi) :
                new ObjectParameter("VehicleAjdi", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteVehicle", vehicleAjdiParameter);
        }
    
        public virtual ObjectResult<GetDetailsTravelOrder_Result> GetDetailsTravelOrder()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDetailsTravelOrder_Result>("GetDetailsTravelOrder");
        }
    
        public virtual ObjectResult<GetDriver_Result> GetDriver(Nullable<int> driverID)
        {
            var driverIDParameter = driverID.HasValue ?
                new ObjectParameter("driverID", driverID) :
                new ObjectParameter("driverID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDriver_Result>("GetDriver", driverIDParameter);
        }
    
        public virtual ObjectResult<GetDrivers_Result> GetDrivers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDrivers_Result>("GetDrivers");
        }
    
        public virtual ObjectResult<GetService_Result> GetService(Nullable<int> serviceID)
        {
            var serviceIDParameter = serviceID.HasValue ?
                new ObjectParameter("serviceID", serviceID) :
                new ObjectParameter("serviceID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetService_Result>("GetService", serviceIDParameter);
        }
    
        public virtual ObjectResult<GetServiceForVehicle_Result> GetServiceForVehicle(Nullable<int> vehicleID)
        {
            var vehicleIDParameter = vehicleID.HasValue ?
                new ObjectParameter("vehicleID", vehicleID) :
                new ObjectParameter("vehicleID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetServiceForVehicle_Result>("GetServiceForVehicle", vehicleIDParameter);
        }
    
        public virtual ObjectResult<GetServicesVehicle_Result> GetServicesVehicle()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetServicesVehicle_Result>("GetServicesVehicle");
        }
    
        public virtual ObjectResult<GetStavka_Result> GetStavka(Nullable<int> vehicleID)
        {
            var vehicleIDParameter = vehicleID.HasValue ?
                new ObjectParameter("vehicleID", vehicleID) :
                new ObjectParameter("vehicleID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStavka_Result>("GetStavka", vehicleIDParameter);
        }
    
        public virtual ObjectResult<GetTravelOrder_Result> GetTravelOrder(Nullable<int> ajdiOrder)
        {
            var ajdiOrderParameter = ajdiOrder.HasValue ?
                new ObjectParameter("AjdiOrder", ajdiOrder) :
                new ObjectParameter("AjdiOrder", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetTravelOrder_Result>("GetTravelOrder", ajdiOrderParameter);
        }
    
        public virtual ObjectResult<GetTravelOrders_Result> GetTravelOrders()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetTravelOrders_Result>("GetTravelOrders");
        }
    
        public virtual ObjectResult<GetTypes_Result> GetTypes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetTypes_Result>("GetTypes");
        }
    
        public virtual ObjectResult<GetVehicle_Result> GetVehicle(Nullable<int> vehicleID)
        {
            var vehicleIDParameter = vehicleID.HasValue ?
                new ObjectParameter("vehicleID", vehicleID) :
                new ObjectParameter("vehicleID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetVehicle_Result>("GetVehicle", vehicleIDParameter);
        }
    
        public virtual ObjectResult<GetVehicles_Result> GetVehicles()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetVehicles_Result>("GetVehicles");
        }
    
        public virtual int InsertDriver(string nameDriver, string surnameDriver, string mobilePhoneDriver, string driverLicense)
        {
            var nameDriverParameter = nameDriver != null ?
                new ObjectParameter("NameDriver", nameDriver) :
                new ObjectParameter("NameDriver", typeof(string));
    
            var surnameDriverParameter = surnameDriver != null ?
                new ObjectParameter("SurnameDriver", surnameDriver) :
                new ObjectParameter("SurnameDriver", typeof(string));
    
            var mobilePhoneDriverParameter = mobilePhoneDriver != null ?
                new ObjectParameter("MobilePhoneDriver", mobilePhoneDriver) :
                new ObjectParameter("MobilePhoneDriver", typeof(string));
    
            var driverLicenseParameter = driverLicense != null ?
                new ObjectParameter("DriverLicense", driverLicense) :
                new ObjectParameter("DriverLicense", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertDriver", nameDriverParameter, surnameDriverParameter, mobilePhoneDriverParameter, driverLicenseParameter);
        }
    
        public virtual int InsertServiceVehicle(Nullable<int> vehicleAjdi, string changeTire, string changeBelt)
        {
            var vehicleAjdiParameter = vehicleAjdi.HasValue ?
                new ObjectParameter("VehicleAjdi", vehicleAjdi) :
                new ObjectParameter("VehicleAjdi", typeof(int));
    
            var changeTireParameter = changeTire != null ?
                new ObjectParameter("ChangeTire", changeTire) :
                new ObjectParameter("ChangeTire", typeof(string));
    
            var changeBeltParameter = changeBelt != null ?
                new ObjectParameter("ChangeBelt", changeBelt) :
                new ObjectParameter("ChangeBelt", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertServiceVehicle", vehicleAjdiParameter, changeTireParameter, changeBeltParameter);
        }
    
        public virtual int InsertTravelOrder(Nullable<int> driverAjdi, Nullable<int> vehicleAjdi, string startPl, string dest, Nullable<System.DateTime> dejtStart, Nullable<System.DateTime> dejtEnd, Nullable<int> tajpOrder)
        {
            var driverAjdiParameter = driverAjdi.HasValue ?
                new ObjectParameter("DriverAjdi", driverAjdi) :
                new ObjectParameter("DriverAjdi", typeof(int));
    
            var vehicleAjdiParameter = vehicleAjdi.HasValue ?
                new ObjectParameter("VehicleAjdi", vehicleAjdi) :
                new ObjectParameter("VehicleAjdi", typeof(int));
    
            var startPlParameter = startPl != null ?
                new ObjectParameter("StartPl", startPl) :
                new ObjectParameter("StartPl", typeof(string));
    
            var destParameter = dest != null ?
                new ObjectParameter("Dest", dest) :
                new ObjectParameter("Dest", typeof(string));
    
            var dejtStartParameter = dejtStart.HasValue ?
                new ObjectParameter("DejtStart", dejtStart) :
                new ObjectParameter("DejtStart", typeof(System.DateTime));
    
            var dejtEndParameter = dejtEnd.HasValue ?
                new ObjectParameter("DejtEnd", dejtEnd) :
                new ObjectParameter("DejtEnd", typeof(System.DateTime));
    
            var tajpOrderParameter = tajpOrder.HasValue ?
                new ObjectParameter("TajpOrder", tajpOrder) :
                new ObjectParameter("TajpOrder", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertTravelOrder", driverAjdiParameter, vehicleAjdiParameter, startPlParameter, destParameter, dejtStartParameter, dejtEndParameter, tajpOrderParameter);
        }
    
        public virtual int InsertVehicle(string tajpVehicle, string markVeh, Nullable<int> yearProd, Nullable<int> numbKM)
        {
            var tajpVehicleParameter = tajpVehicle != null ?
                new ObjectParameter("TajpVehicle", tajpVehicle) :
                new ObjectParameter("TajpVehicle", typeof(string));
    
            var markVehParameter = markVeh != null ?
                new ObjectParameter("MarkVeh", markVeh) :
                new ObjectParameter("MarkVeh", typeof(string));
    
            var yearProdParameter = yearProd.HasValue ?
                new ObjectParameter("YearProd", yearProd) :
                new ObjectParameter("YearProd", typeof(int));
    
            var numbKMParameter = numbKM.HasValue ?
                new ObjectParameter("NumbKM", numbKM) :
                new ObjectParameter("NumbKM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertVehicle", tajpVehicleParameter, markVehParameter, yearProdParameter, numbKMParameter);
        }
    
        public virtual int UpdateDriver(Nullable<int> ajdiDriver, string nameDriver, string surnameDriver, string mobilePhoneDriver, string driverLicense)
        {
            var ajdiDriverParameter = ajdiDriver.HasValue ?
                new ObjectParameter("AjdiDriver", ajdiDriver) :
                new ObjectParameter("AjdiDriver", typeof(int));
    
            var nameDriverParameter = nameDriver != null ?
                new ObjectParameter("NameDriver", nameDriver) :
                new ObjectParameter("NameDriver", typeof(string));
    
            var surnameDriverParameter = surnameDriver != null ?
                new ObjectParameter("SurnameDriver", surnameDriver) :
                new ObjectParameter("SurnameDriver", typeof(string));
    
            var mobilePhoneDriverParameter = mobilePhoneDriver != null ?
                new ObjectParameter("MobilePhoneDriver", mobilePhoneDriver) :
                new ObjectParameter("MobilePhoneDriver", typeof(string));
    
            var driverLicenseParameter = driverLicense != null ?
                new ObjectParameter("DriverLicense", driverLicense) :
                new ObjectParameter("DriverLicense", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateDriver", ajdiDriverParameter, nameDriverParameter, surnameDriverParameter, mobilePhoneDriverParameter, driverLicenseParameter);
        }
    
        public virtual int UpdateServicesVehicle(Nullable<int> ajdiServicesVehicle, Nullable<int> vehicleAjdi, string changeTire, string changeBelt)
        {
            var ajdiServicesVehicleParameter = ajdiServicesVehicle.HasValue ?
                new ObjectParameter("AjdiServicesVehicle", ajdiServicesVehicle) :
                new ObjectParameter("AjdiServicesVehicle", typeof(int));
    
            var vehicleAjdiParameter = vehicleAjdi.HasValue ?
                new ObjectParameter("VehicleAjdi", vehicleAjdi) :
                new ObjectParameter("VehicleAjdi", typeof(int));
    
            var changeTireParameter = changeTire != null ?
                new ObjectParameter("ChangeTire", changeTire) :
                new ObjectParameter("ChangeTire", typeof(string));
    
            var changeBeltParameter = changeBelt != null ?
                new ObjectParameter("ChangeBelt", changeBelt) :
                new ObjectParameter("ChangeBelt", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateServicesVehicle", ajdiServicesVehicleParameter, vehicleAjdiParameter, changeTireParameter, changeBeltParameter);
        }
    
        public virtual int UpdateTravelOrder(Nullable<int> ajdiTravelOrder, Nullable<int> driverAjdi, Nullable<int> vehicleAjdi, string startPl, string dest, Nullable<System.DateTime> dejtStart, Nullable<System.DateTime> dejtEnd, string tajpOrder)
        {
            var ajdiTravelOrderParameter = ajdiTravelOrder.HasValue ?
                new ObjectParameter("AjdiTravelOrder", ajdiTravelOrder) :
                new ObjectParameter("AjdiTravelOrder", typeof(int));
    
            var driverAjdiParameter = driverAjdi.HasValue ?
                new ObjectParameter("DriverAjdi", driverAjdi) :
                new ObjectParameter("DriverAjdi", typeof(int));
    
            var vehicleAjdiParameter = vehicleAjdi.HasValue ?
                new ObjectParameter("VehicleAjdi", vehicleAjdi) :
                new ObjectParameter("VehicleAjdi", typeof(int));
    
            var startPlParameter = startPl != null ?
                new ObjectParameter("StartPl", startPl) :
                new ObjectParameter("StartPl", typeof(string));
    
            var destParameter = dest != null ?
                new ObjectParameter("Dest", dest) :
                new ObjectParameter("Dest", typeof(string));
    
            var dejtStartParameter = dejtStart.HasValue ?
                new ObjectParameter("DejtStart", dejtStart) :
                new ObjectParameter("DejtStart", typeof(System.DateTime));
    
            var dejtEndParameter = dejtEnd.HasValue ?
                new ObjectParameter("DejtEnd", dejtEnd) :
                new ObjectParameter("DejtEnd", typeof(System.DateTime));
    
            var tajpOrderParameter = tajpOrder != null ?
                new ObjectParameter("TajpOrder", tajpOrder) :
                new ObjectParameter("TajpOrder", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateTravelOrder", ajdiTravelOrderParameter, driverAjdiParameter, vehicleAjdiParameter, startPlParameter, destParameter, dejtStartParameter, dejtEndParameter, tajpOrderParameter);
        }
    
        public virtual int UpdateVehicle(Nullable<int> ajdiVehicle, string tajpVehicle, string markVeh, Nullable<int> yearProd, Nullable<int> numbKM)
        {
            var ajdiVehicleParameter = ajdiVehicle.HasValue ?
                new ObjectParameter("AjdiVehicle", ajdiVehicle) :
                new ObjectParameter("AjdiVehicle", typeof(int));
    
            var tajpVehicleParameter = tajpVehicle != null ?
                new ObjectParameter("TajpVehicle", tajpVehicle) :
                new ObjectParameter("TajpVehicle", typeof(string));
    
            var markVehParameter = markVeh != null ?
                new ObjectParameter("MarkVeh", markVeh) :
                new ObjectParameter("MarkVeh", typeof(string));
    
            var yearProdParameter = yearProd.HasValue ?
                new ObjectParameter("YearProd", yearProd) :
                new ObjectParameter("YearProd", typeof(int));
    
            var numbKMParameter = numbKM.HasValue ?
                new ObjectParameter("NumbKM", numbKM) :
                new ObjectParameter("NumbKM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateVehicle", ajdiVehicleParameter, tajpVehicleParameter, markVehParameter, yearProdParameter, numbKMParameter);
        }
    }
}
