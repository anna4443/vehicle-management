use master
GO

drop database VehicleManagement
GO

create database VehicleManagement
GO

use VehicleManagement
GO

create table Driver
(
	IDDriver int primary key identity,
	Name nvarchar(100) not null,
	Surname nvarchar(100) not null,
	MobilePhone nvarchar(100) not null,
	DriversLicenseNumber nvarchar(max) not null
)
GO

create proc InsertDriver
	@NameDriver nvarchar(100),
	@SurnameDriver nvarchar(100),
	@MobilePhoneDriver nvarchar(100),
	@DriverLicense nvarchar(max) 
AS
insert into Driver (Name, Surname, MobilePhone, DriversLicenseNumber)
values (@NameDriver, @SurnameDriver, @MobilePhoneDriver, @DriverLicense)
GO

exec InsertDriver 'Miro', 'Miric', '094563213156', '1234567890098765476'
exec InsertDriver 'Pero', 'Peric', '0964567890978', '5654615215644511534'
exec InsertDriver 'Marko', 'Maric', '095744525444', '8746451465485155468'
exec InsertDriver 'Matija', 'Matijic', '07855556654', '234567867544345676'
GO

create proc GetDrivers
AS 
select * from Driver
GO

exec GetDrivers
GO

create proc UpdateDriver 
	@AjdiDriver int,
	@NameDriver nvarchar(100),
	@SurnameDriver nvarchar(100),
	@MobilePhoneDriver nvarchar(100),
	@DriverLicense nvarchar(max) 

AS
update Driver
set Name = @NameDriver,
	Surname = @SurnameDriver,
	MobilePhone = @MobilePhoneDriver,
	DriversLicenseNumber = @DriverLicense
where IDDriver = @AjdiDriver
GO

exec UpdateDriver 2, 'Pero', 'Peric', '0964567890978', '0111111111111111111'
exec UpdateDriver 3, 'Marko', 'Maric', '095744525444', '1222222222222222222'
GO

exec GetDrivers
GO

create proc DeleteDriver
	@DriverAjdi int
AS
delete from Driver
where IDDriver = @DriverAjdi
GO

exec DeleteDriver 2
GO

exec GetDrivers
GO

create proc GetDriver
	@driverID int
AS
SELECT * FROM Driver WHERE IDDriver = @driverID
GO

create table Vehicle
(
	IDVehicle int primary key identity,
	TypeVehicle nvarchar(max) not null,
	MarkVehicle nvarchar(max) not null,
	YearProduction int not null,
	InitialMomentOfKM int not null
)
GO

create proc InsertVehicle
	@TajpVehicle nvarchar(max),
	@MarkVeh nvarchar(max),
	@YearProd int, 
	@NumbKM int
AS
insert into Vehicle(TypeVehicle, MarkVehicle, YearProduction, InitialMomentOfKM)
values (@TajpVehicle, @MarkVeh, @YearProd, @NumbKM)
GO

exec InsertVehicle 'Peugeot', '407', 2004, 60
exec InsertVehicle 'Audi', 'A8', 2004, 17
exec InsertVehicle 'Mercedes', 'E280', 2006, 23
exec InsertVehicle 'Opel', 'COMBO', 2008, 20
GO

create proc GetVehicles
AS
select * from Vehicle
GO

exec GetVehicles
GO

create proc UpdateVehicle
	@AjdiVehicle int,
	@TajpVehicle nvarchar(max),
	@MarkVeh nvarchar(max),
	@YearProd int, 
	@NumbKM int
AS
update Vehicle
set TypeVehicle = @TajpVehicle,
	MarkVehicle = @MarkVeh,
	YearProduction = @YearProd,
	InitialMomentOfKM = @NumbKM
where IDVehicle = @AjdiVehicle
GO

create proc GetVehicle
	@vehicleID int
AS
SELECT * FROM Vehicle WHERE IDVehicle = @vehicleID
GO

create proc DeleteVehicle
	@VehicleAjdi int
AS
delete from Vehicle where IDVehicle = @VehicleAjdi
GO

exec GetDrivers
GO

exec GetVehicles
GO

create table TypeTravelOrder
(
	IDTypeTravelOrder int primary key identity,
	Name nvarchar(100) not null
)
GO

insert into TypeTravelOrder (Name)
values ('Otvoren'),
	   ('Zatvoren'),
	   ('Buduæi')
GO

create table TravelOrder
(
	IDTravelOrder int primary key identity,
	DriverID int,
	VehicleID int,
	StartPlace nvarchar(max),
	Destination nvarchar(max),
	DateStart date,
	DateEnd date,
	TypeOrderID int,

	CONSTRAINT FK_TravelOrder_Driver FOREIGN KEY(DriverID) REFERENCES Driver(IDDriver),
	CONSTRAINT FK_TravelOrder_Vehicle FOREIGN KEY(VehicleID) REFERENCES Vehicle(IDVehicle),
	CONSTRAINT FK_TravelOrder_TypeTravelOrder FOREIGN KEY(TypeOrderID) REFERENCES TypeTravelOrder(IDTypeTravelOrder)
)
GO

select * from TypeTravelOrder
GO


create proc InsertTravelOrder
	@DriverAjdi int,
	@VehicleAjdi int, 
	@StartPl nvarchar(max),
	@Dest nvarchar(max),
	@DejtStart date,
	@DejtEnd date,
	@TajpOrder int
AS
insert into TravelOrder (DriverID, VehicleID, StartPlace, Destination, DateStart, DateEnd, TypeOrderID)
values (@DriverAjdi, @VehicleAjdi, @StartPl, @Dest, @DejtStart, @DejtEnd, @TajpOrder)
GO

exec InsertTravelOrder 1, 2, 'Zagreb', 'Ljubljana', '20180321', '20180321', 2
exec InsertTravelOrder 3, 3, 'Berlin', 'Pariz', '20181221', '20181221', 3
GO

create proc GetTravelOrders
AS
select * from TravelOrder
GO

exec GetTravelOrders
GO

create proc UpdateTravelOrder
	@AjdiTravelOrder int,
	@DriverAjdi int,
	@VehicleAjdi int, 
	@StartPl nvarchar(max),
	@Dest nvarchar(max),
	@DejtStart date,
	@DejtEnd date,
	@TajpOrder nvarchar(100)
AS
update TravelOrder 
set DriverID = @DriverAjdi,
	VehicleID = @VehicleAjdi,
	StartPlace = @StartPl,
	Destination = @Dest,
	DateStart = @DejtStart,
	DateEnd = @DejtEnd,
	TypeOrderID = (select IDTravelOrder from TypeTravelOrder where Name=@TajpOrder)
where IDTravelOrder = @AjdiTravelOrder
GO

exec UpdateTravelOrder 1,1,2,'Amsterdam','Prag', '2018-12-21', '2018-12-21', 'Otvoren'
GO

create proc GetDetailsTravelOrder
AS
select t.IDTravelOrder, t.DriverID, t.VehicleID, t.StartPlace, t.Destination, t.DateStart, t.DateEnd, tto.Name as 'NameOrder', d.Name, d.Surname, d.MobilePhone, d.DriversLicenseNumber, v.TypeVehicle, v.MarkVehicle, v.YearProduction, v.InitialMomentOfKM
 from TravelOrder as t

inner join Driver AS d
ON t.DriverID = d.IDDriver

inner join Vehicle AS v
ON t.VehicleID = v.IDVehicle

inner join TypeTravelOrder AS tto
ON t.TypeOrderID = tto.IDTypeTravelOrder
GO

exec GetDetailsTravelOrder
GO

create proc GetTravelOrder
	@AjdiOrder int
AS
select t.IDTravelOrder, d.Name, d.Surname, v.TypeVehicle, t.StartPlace, t.Destination, t.DateStart, t.DateEnd, tto.Name as 'Name type' from TravelOrder as t 

inner join Driver as d
on t.DriverID = d.IDDriver

inner join TypeTravelOrder as tto
on t.TypeOrderID = tto.IDTypeTravelOrder

inner join Vehicle as v
on t.VehicleID = v.IDVehicle

where t.IDTravelOrder = @AjdiOrder
GO

exec GetTravelOrder 2
GO

create proc DeleteTravelOrder
	@TravelOrderAjdi int
AS
delete from TravelOrder where IDTravelOrder = @TravelOrderAjdi
GO

select * from Driver
GO

exec InsertDriver 'Leon', 'Leonic', '097551112323323', '45675433456789778'
exec InsertDriver 'Patrik', 'Pat', '091452256325', '122312121322121212'
exec InsertDriver 'Pero', 'Peric', '09721212145', '98789889988988988'
exec InsertDriver 'Liam', 'Li', '092878898989', '4567898765456789'
GO


exec InsertVehicle 'Audi', 'B2', 2014, 54
exec InsertVehicle 'Cadillac', 'A12', 2003, 43
exec InsertVehicle 'BMW', 'C32', 2001, 55
exec InsertVehicle 'Citroen', '213', 2013 ,21
GO


select * from Driver
GO

select * from Vehicle
GO

exec InsertTravelOrder 4, 3, 'Zagreb', 'Budimpešta', '20181221', '20181222', 3
exec InsertTravelOrder 5, 2, 'Rim', 'Beè', '20180903', '20180904', 2
exec InsertTravelOrder 6, 7, 'Karlovac', 'Prag', '20181010', '20181012', 2
exec InsertTravelOrder 1, 4, 'London', 'Zagreb', '20180816', '20180820', 2
exec InsertTravelOrder 8, 5, 'Zadar', 'Krakov', '20181121', '20181201', 3
GO

create proc CleanDatabase
AS
delete from TravelOrder
delete from TypeTravelOrder
delete from Driver
delete from Vehicle
GO

create proc GetTypes 
AS
select * from TypeTravelOrder
GO

select * from Driver
GO

select * from Vehicle
GO

exec InsertDriver 'Baba', 'Greda', '5678976556789', '5241422141'
GO

create table ServiceVehicle
(
	IDServiceVehicle int primary key identity, 
	VehicleID int,
	ChangeTire nvarchar(10),
	ChangeBelt nvarchar(10),

	CONSTRAINT FK_ServiceVehicle_Vehicle FOREIGN KEY(VehicleID) REFERENCES Vehicle(IDVehicle)
)

create proc InsertServiceVehicle
	@VehicleAjdi int,
	@ChangeTire nvarchar(10),
	@ChangeBelt nvarchar(10)
AS
insert into ServiceVehicle (VehicleID, ChangeTire, ChangeBelt)
values (@VehicleAjdi, @ChangeTire, @ChangeBelt)
GO

exec InsertServiceVehicle 2, 'yes', 'no'
exec InsertServiceVehicle 7, 'no', 'no'
exec InsertServiceVehicle 3, 'yes', 'yes'
GO

create proc GetServicesVehicle
AS
select sv.IDServiceVehicle, sv.VehicleID, v.MarkVehicle, v.TypeVehicle, sv.ChangeTire, sv.ChangeBelt
from ServiceVehicle as sv

inner join Vehicle as v
on sv.VehicleID = v.IDVehicle
GO

exec GetServicesVehicle
GO

create proc UpdateServicesVehicle 
	@AjdiServicesVehicle int, 
	@VehicleAjdi int, 
	@ChangeTire nvarchar(10),
	@ChangeBelt nvarchar(10)
AS
update ServiceVehicle
set VehicleID = @VehicleAjdi,
	ChangeTire = @ChangeTire,
	ChangeBelt = @ChangeBelt

where IDServiceVehicle = @AjdiServicesVehicle
GO

exec UpdateServicesVehicle 3, 6, 'yes','no'
GO

create proc DeleteServicesVehicle
	@AjdiServicesVehicle int
AS 
delete from ServiceVehicle where IDServiceVehicle = @AjdiServicesVehicle
GO

create proc GetService
	@serviceID int
AS
select * from ServiceVehicle where IDServiceVehicle = @serviceID
GO

exec GetService 2
GO

create proc GetServiceForVehicle 
	@vehicleID int
AS
select sv.IDServiceVehicle, v.MarkVehicle, v.TypeVehicle, sv.ChangeTire, sv.ChangeBelt
from ServiceVehicle as sv

inner join Vehicle as v
ON v.IDVehicle = sv.VehicleID

where v.IDVehicle = @vehicleID
GO

exec InsertServiceVehicle 2, 'yes', 'yes'
GO

exec GetServiceForVehicle 2
Go

create table Stavka 
(
	IDStavka int primary key identity, 
	VehicleID int, 
	ServiceVehicleID int,

	CONSTRAINT FK_Stavka_Vehicle FOREIGN KEY(VehicleID) REFERENCES Vehicle(IDVehicle),
	CONSTRAINT FK_Stavka_ServiceVehicle FOREIGN KEY(ServiceVehicleID) REFERENCES ServiceVehicle(IDServiceVehicle)
)
GO

create proc GetStavka 
@vehicleID int
AS
select s.IDStavka, s.VehicleID, v.MarkVehicle, v.TypeVehicle, sv.IDServiceVehicle, sv.ChangeTire, sv.ChangeBelt
from Stavka as s

inner join ServiceVehicle as sv
ON sv.IDServiceVehicle = s.ServiceVehicleID

inner join Vehicle as v
ON v.IDVehicle = s.VehicleID

where v.IDVehicle = @vehicleID
GO

exec GetStavka 2
GO

select * from Vehicle
GO

select * from Driver
GO

select * from TypeTravelOrder
GO

