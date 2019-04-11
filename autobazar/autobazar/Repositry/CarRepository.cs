using autobazar.Enums;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace autobazar.Repositry
{
    public class CarRepository
    {
        private const string CONNECTION_STRING = "Server=TRANSFORMER5\\SQL16;Database=Autobazar;Trusted_Connection=True;";

        public void GetListOfCars()
        {
            List<object> cars = new List<object>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command= connection.CreateCommand()) 
                {
                    command.CommandText = "Select * FROM Car";
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cars.Add(reader.GetInt32(0));
                                cars.Add(reader.GetInt32(1));
                                cars.Add(reader.GetInt32(2));
                                cars.Add(EnumReader.ParseIntToEnum<CarBrand>(reader.GetInt32(3)));
                                cars.Add(EnumReader.ParseIntToEnum<CarType>(reader.GetInt32(4)));
                                cars.Add(EnumReader.ParseIntToEnum<Fuel>(reader.GetInt32(5)));
                                cars.Add(reader.GetInt32(6));
                                cars.Add(EnumReader.ParseIntToEnum<Town>(reader.GetInt32(7)));
                                cars.Add(reader.GetInt32(8));
                                cars.Add(reader.GetBoolean(9));
                                cars.Add("---------------");

                            }
                            cars.ForEach(car => System.Console.WriteLine(car));
                        }
                    }
                    catch (SqlException ex)
                    {
                        System.Console.WriteLine($"The database could not be read: \n{ex}");
                    }


                }
            }
        }
    }
}
