using autobazar.Enums;
using autobazar.Properties;
using autobazar.Repositry;
using System;
using System.Collections.Generic;


namespace autobazar
{
    class Program
    {
        static void Main(string[] args)
        {

            CarRepository carRepository = new CarRepository();
            carRepository.GetListOfCars();



            //AutobazarManager bazar = new AutobazarManager("dbCars.txt");

            //bazar.RunTheAutobazar();
            Console.ReadLine();
        }
    }
}