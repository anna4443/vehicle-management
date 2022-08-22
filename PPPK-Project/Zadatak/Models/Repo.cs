using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Xml;

namespace Zadatak.Models
{
    public class Repo : IRepo
    {
        private readonly string cs;
        private string XML_PATH = @"path";

        private string XML_PATH_TWO = @"pathtwo";

        private const string SELECT = "select * from TravelOrder";

        private static string csTwo = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        private static SqlDatabase db = new SqlDatabase(csTwo);

        public Repo(String connectionString)
        {
            this.cs = connectionString;
        }

        public IEnumerable<Driver> GetVozaci()
        {
            List<Driver> drivers = new List<Driver>();

            using (SqlConnection con = new SqlConnection(cs))
            {

                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "select * from Driver";
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                drivers.Add(new Driver
                                {
                                    IDDriver = (int)r["IDDriver"],
                                    Name = r["Name"].ToString(),
                                    Surname = r["Surname"].ToString(),
                                    MobilePhone = r["MobilePhone"].ToString(),
                                    DriversLicenseNumber = r["DriversLicenseNumber"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return drivers;
        }

        public Driver GetVozac(int id)
        {
            Driver driver = null;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from Driver WHERE IDDriver=" + id;
                    cmd.Parameters.AddWithValue("@driverID", id);
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            driver = new Driver
                            {
                                IDDriver = (int)r[nameof(Driver.IDDriver)],
                                Name = r[nameof(Driver.Name)].ToString(),
                                Surname = r[nameof(Driver.Surname)].ToString(),
                                MobilePhone = r[nameof(Driver.MobilePhone)].ToString(),
                                DriversLicenseNumber = r[nameof(Driver.DriversLicenseNumber)].ToString()
                            };
                        }
                    }
                }
            }
            return driver;
        }


        public int UpdateVozac(Driver driver)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "update Driver set Name = @NameDriver, Surname = @SurnameDriver,MobilePhone = @MobilePhoneDriver, DriversLicenseNumber = @DriverLicense where IDDriver = @AjdiDriver";
                    cmd.Parameters.AddWithValue("@AjdiDriver", driver.IDDriver);
                    cmd.Parameters.AddWithValue("@NameDriver", driver.Name);
                    cmd.Parameters.AddWithValue("@SurnameDriver", driver.Surname);
                    cmd.Parameters.AddWithValue("@MobilePhoneDriver", driver.MobilePhone);
                    cmd.Parameters.AddWithValue("@DriverLicense", driver.DriversLicenseNumber);
                    return cmd.ExecuteNonQuery();

                }
            }
        }

        public int DeleteVozac(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "delete from Driver where IDDriver = @AjdiDriver";
                    cmd.Parameters.AddWithValue("@AjdiDriver", id);

                    return cmd.ExecuteNonQuery();

                }
            }
        }

        public IEnumerable<Vehicle> GetVozila()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "GetVehicles";
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                vehicles.Add(new Vehicle
                                {
                                    IDVehicle = (int)r["IDVehicle"],
                                    TypeVehicle = r["TypeVehicle"].ToString(),
                                    MarkVehicle = r["MarkVehicle"].ToString(),
                                    YearProduction = (int)r["YearProduction"],
                                    InitialMomentOfKM = (int)r["InitialMomentOfKM"]
                                });
                            }
                        }
                    }
                }
            }
            return vehicles;
        }

        public void InsertVozac(Driver driver)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "insert into Driver values(@NameDriver, @SurnameDriver, @MobilePhoneDriver, @DriverLicense)";
                    cmd.Parameters.AddWithValue("NameDriver", driver.Name);
                    cmd.Parameters.AddWithValue("SurnameDriver", driver.Surname);
                    cmd.Parameters.AddWithValue("MobilePhoneDriver", driver.MobilePhone);
                    cmd.Parameters.AddWithValue("DriverLicense", driver.DriversLicenseNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Vehicle GetVozilo(int id)
        {
            Vehicle vehicle = null;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetVehicle";
                    cmd.Parameters.AddWithValue("@vehicleID", id);
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            vehicle = new Vehicle
                            {
                                IDVehicle = (int)r[nameof(Vehicle.IDVehicle)],
                                TypeVehicle = r[nameof(Vehicle.TypeVehicle)].ToString(),
                                MarkVehicle = r[nameof(Vehicle.MarkVehicle)].ToString(),
                                YearProduction = (int)r[nameof(Vehicle.YearProduction)],
                                InitialMomentOfKM = (int)r[nameof(Vehicle.InitialMomentOfKM)]
                            };
                        }
                    }
                }
            }
            return vehicle;
        }

        public int UpdateVozilo(Vehicle vehicle)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "UpdateVehicle";
                    cmd.Parameters.AddWithValue("@AjdiVehicle", vehicle.IDVehicle);
                    cmd.Parameters.AddWithValue("@TajpVehicle", vehicle.TypeVehicle);
                    cmd.Parameters.AddWithValue("@MarkVeh", vehicle.MarkVehicle);
                    cmd.Parameters.AddWithValue("@YearProd", vehicle.YearProduction);
                    cmd.Parameters.AddWithValue("@NumbKM", vehicle.InitialMomentOfKM);
                    return cmd.ExecuteNonQuery();

                }
            }
        }

        public void InsertVozilo(Vehicle vehicle)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "InsertVehicle";
                    cmd.Parameters.AddWithValue("@TajpVehicle", vehicle.TypeVehicle);
                    cmd.Parameters.AddWithValue("@MarkVeh", vehicle.MarkVehicle);
                    cmd.Parameters.AddWithValue("@YearProd", vehicle.YearProduction);
                    cmd.Parameters.AddWithValue("@NumbKM", vehicle.InitialMomentOfKM);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int DeleteVozilo(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteVehicle";
                    cmd.Parameters.AddWithValue("@VehicleAjdi", id);

                    return cmd.ExecuteNonQuery();

                }
            }
        }

        public IEnumerable<TravelOrderDriverVehicle> GetTravelOrdersDriversVehicles()
        {
            List<TravelOrderDriverVehicle> todv = new List<TravelOrderDriverVehicle>();

            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "GetDetailsTravelOrder";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.HasRows)
                            {
                                while (r.Read())
                                {
                                    todv.Add(new TravelOrderDriverVehicle
                                    {
                                        IDTravelOrder = (int)r["IDTravelOrder"],
                                        Driver = new Driver
                                        {
                                            Name = r["Name"].ToString(),
                                            Surname = r["Surname"].ToString()
                                        },
                                        Vehicle = new Vehicle
                                        {
                                            TypeVehicle = r["TypeVehicle"].ToString(),
                                            MarkVehicle = r["MarkVehicle"].ToString(),
                                            YearProduction = (int)r["YearProduction"],
                                            InitialMomentOfKM = (int)r["InitialMomentOfKM"]
                                        },
                                        StartPlace = r["StartPlace"].ToString(),
                                        Destination = r["Destination"].ToString(),
                                        DateStart = (DateTime)r["DateStart"],
                                        DateEnd = (DateTime)r["DateEnd"],
                                        Order = new TypeOrder
                                        {
                                            Name = r["NameOrder"].ToString()
                                        }
                                    });
                                }
                            }
                        }
                        scope.Complete();
                    }
                }
            }
            return todv;
        }

        public int UpdateNalog(TravelOrderDriverVehicle travelOrder)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "UpdateTravelOrder";
                        cmd.Parameters.AddWithValue("@AjdiTravelOrder", travelOrder.IDTravelOrder);
                        cmd.Parameters.AddWithValue("@DriverAjdi", travelOrder.Driver.IDDriver);
                        cmd.Parameters.AddWithValue("@VehicleAjdi", travelOrder.Vehicle.IDVehicle);
                        cmd.Parameters.AddWithValue("@StartPl", travelOrder.StartPlace);
                        cmd.Parameters.AddWithValue("@Dest", travelOrder.Destination);
                        cmd.Parameters.AddWithValue("@DejtStart", travelOrder.DateStart);
                        cmd.Parameters.AddWithValue("@DejtEnd", travelOrder.DateEnd);
                        cmd.Parameters.AddWithValue("@TajpOrder", travelOrder.Order.Name);

                        scope.Complete();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public TravelOrderDriverVehicle GetNalog(int id)
        {
            TravelOrderDriverVehicle order = null;
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "GetTravelOrder";
                        cmd.Parameters.AddWithValue("@AjdiOrder", id);
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                order = new TravelOrderDriverVehicle
                                {
                                    IDTravelOrder = (int)r[nameof(TravelOrderDriverVehicle.IDTravelOrder)],

                                    Driver = new Driver
                                    {
                                        Name = r["Name"].ToString(),
                                        Surname = r["Surname"].ToString()
                                    },
                                    Vehicle = new Vehicle
                                    {
                                        TypeVehicle = r["TypeVehicle"].ToString()
                                    },
                                    StartPlace = r[nameof(TravelOrderDriverVehicle.StartPlace)].ToString(),
                                    Destination = r[nameof(TravelOrderDriverVehicle.Destination)].ToString(),
                                    DateStart = (DateTime)r[nameof(TravelOrderDriverVehicle.DateStart)],
                                    DateEnd = (DateTime)r[nameof(TravelOrderDriverVehicle.DateEnd)],
                                    Order = new TypeOrder
                                    {
                                        Name = r["Name type"].ToString()
                                    }
                                };
                            }
                        }
                        scope.Complete();
                    }
                }
            }
            return order;
        }

        public int DeleteNalog(int id)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "DeleteTravelOrder";
                        cmd.Parameters.AddWithValue("@TravelOrderAjdi", id);

                        scope.Complete();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void InsertNalog(TravelOrderDriverVehicle travelOrderDriverVehicle)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "InsertTravelOrder";
                        cmd.Parameters.AddWithValue("@DriverAjdi", travelOrderDriverVehicle.Driver.IDDriver);
                        cmd.Parameters.AddWithValue("@VehicleAjdi", travelOrderDriverVehicle.Vehicle.IDVehicle);
                        cmd.Parameters.AddWithValue("@StartPl", travelOrderDriverVehicle.StartPlace);
                        cmd.Parameters.AddWithValue("@Dest", travelOrderDriverVehicle.Destination);
                        cmd.Parameters.AddWithValue("@DejtStart", travelOrderDriverVehicle.DateStart);
                        cmd.Parameters.AddWithValue("@DejtEnd", travelOrderDriverVehicle.DateEnd);
                        cmd.Parameters.AddWithValue("@TajpOrder", travelOrderDriverVehicle.Order.IDTypeTravelOrder);
                        cmd.ExecuteNonQuery();

                        scope.Complete();
                    }
                }
            }
        }

        public IEnumerable<TypeOrder> GetTypes()
        {
            List<TypeOrder> orders = new List<TypeOrder>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "GetTypes";
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                orders.Add(new TypeOrder
                                {
                                    IDTypeTravelOrder = (int)r["IDTypeTravelOrder"],
                                    Name = r["Name"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return orders;
        }

        public void CreateXML()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from TravelOrder", con);

            DataSet ds = new DataSet("Ruta");
            da.Fill(ds);

            ds.Tables[0].TableName = "TravelOrder";

            //ds.WriteXml("PrijedenaRuta.xml", XmlWriteMode.WriteSchema);

            string xmlDS = ds.GetXml();

            ds.WriteXml(XML_PATH, XmlWriteMode.WriteSchema);
        }

        public List<TravelOrderDriverVehicle> ReadXML()
        {
            DataSet ds = new DataSet();

            ds.ReadXml(XML_PATH);

            var orderList = new List<TravelOrderDriverVehicle>();

            orderList = (from rows in ds.Tables[0].AsEnumerable()
                         select new TravelOrderDriverVehicle
                         {
                             IDTravelOrder = Convert.ToInt32(rows[0].ToString()),
                             Driver = new Driver { IDDriver = Convert.ToInt32(rows[1].ToString())},
                             Vehicle = new Vehicle { IDVehicle = Convert.ToInt32(rows[2].ToString())},
                             StartPlace = rows[3].ToString(),
                             Destination = rows[4].ToString(),
                             DateStart = Convert.ToDateTime(rows[5].ToString()),
                             DateEnd = Convert.ToDateTime(rows[6].ToString())

                         }).ToList();

            return orderList;
        }

        public IEnumerable<TravelOrderDriverVehicle> GetDetailsTravelOrder()
        {
            using (IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, nameof(GetDetailsTravelOrder)))
            {
                while (dr.Read())
                {
                    yield return new TravelOrderDriverVehicle
                    {
                        IDTravelOrder = (int)dr[nameof(TravelOrderDriverVehicle.IDTravelOrder)],
                        Driver = new Driver
                        {
                            Name = dr[nameof(Driver.Name)].ToString(),
                            Surname = dr[nameof(Driver.Surname)].ToString()
                        },
                        Vehicle = new Vehicle
                        {
                            TypeVehicle = dr[nameof(Vehicle.TypeVehicle)].ToString(),
                            MarkVehicle = dr[nameof(Vehicle.MarkVehicle)].ToString(),
                            YearProduction = (int)dr[nameof(Vehicle.YearProduction)],
                            InitialMomentOfKM = (int)dr[nameof(Vehicle.InitialMomentOfKM)]
                        },
                        StartPlace = dr[nameof(TravelOrderDriverVehicle.StartPlace)].ToString(),
                        Destination = dr[nameof(TravelOrderDriverVehicle.Destination)].ToString(),
                        DateStart = (DateTime)dr[nameof(TravelOrderDriverVehicle.DateStart)],
                        DateEnd = (DateTime)dr[nameof(TravelOrderDriverVehicle.DateEnd)],
                        Order = new TypeOrder
                        {
                            Name = dr[nameof(TypeOrder.Name)].ToString()
                        }
                    };
                }
            }
        }

        public int InsertTravelOrder(TravelOrderDriverVehicle todv) => db.ExecuteNonQuery(nameof(Repo.InsertTravelOrder), todv.Driver.IDDriver, todv.Vehicle.IDVehicle, todv.StartPlace, todv.Destination, todv.DateStart, todv.DateEnd, todv.Order.IDTypeTravelOrder);

        public int UpdateTravelOrder(int idOrder, TravelOrderDriverVehicle todv) => db.ExecuteNonQuery(nameof(UpdateTravelOrder), idOrder, todv.Driver.IDDriver, todv.Vehicle.IDVehicle, todv.StartPlace, todv.Destination, todv.DateStart, todv.DateEnd, todv.Order.IDTypeTravelOrder);

        public int DeleteTravelOrder(int idOrder) => db.ExecuteNonQuery(nameof(DeleteTravelOrder), idOrder);

        public TravelOrderDriverVehicle GetTravelOrder(int idOrder)
        {

            DataSet ds = db.ExecuteDataSet(nameof(GetTravelOrder), idOrder);
            DataRow dr = ds?.Tables[0]?.Rows[0];
            if (dr != null)
            {
                return new TravelOrderDriverVehicle
                {
                    IDTravelOrder = idOrder,
                     Driver = new Driver
                     {
                         Name = dr[nameof(Driver.Name)].ToString(),
                         Surname = dr[nameof(Driver.Surname)].ToString()
                     },
                     Vehicle = new Vehicle
                     {
                         TypeVehicle = dr[nameof(Vehicle.TypeVehicle)].ToString()
                     },
                    StartPlace = dr[nameof(TravelOrderDriverVehicle.StartPlace)].ToString(),
                    Destination = dr[nameof(TravelOrderDriverVehicle.Destination)].ToString(),
                    DateStart = (DateTime)dr[nameof(TravelOrderDriverVehicle.DateStart)],
                    DateEnd = (DateTime)dr[nameof(TravelOrderDriverVehicle.DateEnd)],
                    Order = new TypeOrder
                    {
                        Name = dr["Name type"].ToString()
                    }
                };
            }

            return null;
        }

        public void CreateXmlDoc()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            XmlWriter writer = XmlWriter.Create(XML_PATH_TWO, settings);
            writer.WriteStartDocument();

            writer.WriteStartElement("DataInfo");

            WriteOrders(writer);

            writer.WriteEndElement();
            writer.Close();
        }

        private void WriteOrders(XmlWriter writer)
        {
            writer.WriteStartElement("Orders");

            foreach (TravelOrderDriverVehicle order in GetDetailsTravelOrder())
            {
                writer.WriteStartElement("IDOrder");
                writer.WriteString(order.IDTravelOrder.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Driver");
                //writer.WriteStartElement("IDDriver");
                //writer.WriteString(order.Driver.IDDriver.ToString());
                //writer.WriteEndElement();
                writer.WriteStartElement("Name");
                writer.WriteString(order.Driver.Name);
                writer.WriteEndElement();
                writer.WriteStartElement("Surname");
                writer.WriteString(order.Driver.Surname);
                writer.WriteEndElement();
                //writer.WriteStartElement("Mobilephone");
                //writer.WriteString(order.Driver.MobilePhone);
                //writer.WriteEndElement();
                //writer.WriteStartElement("DriversLicenseNumber");
                //writer.WriteString(order.Driver.DriversLicenseNumber);
                //writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("Vehicle");
                //writer.WriteStartElement("IDVehicle");
                //writer.WriteString(order.Vehicle.IDVehicle.ToString());
                //writer.WriteEndElement();
                writer.WriteStartElement("Type");
                writer.WriteString(order.Vehicle.TypeVehicle);
                writer.WriteEndElement();
                //writer.WriteStartElement("Mark");
                //writer.WriteString(order.Vehicle.MarkVehicle);
                //writer.WriteEndElement();
                //writer.WriteStartElement("YearProduction");
                //writer.WriteString(order.Vehicle.YearProduction.ToString());
                //writer.WriteEndElement();
                //writer.WriteStartElement("InitialKm");
                //writer.WriteString(order.Vehicle.InitialMomentOfKM.ToString());
                //writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("StartPlace");
                writer.WriteString(order.StartPlace);
                writer.WriteEndElement();
                writer.WriteStartElement("Destination");
                writer.WriteString(order.Destination);
                writer.WriteEndElement();
                writer.WriteStartElement("DateStart");
                writer.WriteString(order.DateStart.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement("DateEnd");
                writer.WriteString(order.DateEnd.ToString());
                writer.WriteEndElement();
                //writer.WriteStartElement("TypeOrder");
                //writer.WriteString(order.Order.IDTypeTravelOrder.ToString());
                //writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        public void ReadXmlDoc()
        {
            List<TravelOrderDriverVehicle> orders = new List<TravelOrderDriverVehicle>();

            XmlDocument doc = LoadDocument();

            XmlNode rootOrders = doc.DocumentElement.FirstChild;

            XmlNodeList ordersXml = rootOrders.SelectNodes("Orders");

            foreach (XmlNode order in ordersXml)
            {
                orders.Add(new TravelOrderDriverVehicle
                {
                    IDTravelOrder = int.Parse(order.SelectSingleNode("IDOrder").InnerText),
                    Driver = new Driver
                    {
                        Name = order.SelectSingleNode("Name").InnerText,
                        Surname = order.SelectSingleNode("Surname").InnerText
                    },
                    Vehicle = new Vehicle
                    {
                        TypeVehicle = order.SelectSingleNode("Type").InnerText
                    },
                    StartPlace = order.SelectSingleNode("StartPlace").InnerText,
                    Destination = order.SelectSingleNode("Destination").InnerText,
                    DateStart = DateTime.Parse(order.SelectSingleNode("DateStart").InnerText),
                    DateEnd = DateTime.Parse(order.SelectSingleNode("DateEnd").InnerText)
                });
            }

        }

        private XmlDocument LoadDocument()
        {
            XmlDocument dom = new XmlDocument();
            dom.Load(XML_PATH_TWO);

            return dom;
        }
    }
}
