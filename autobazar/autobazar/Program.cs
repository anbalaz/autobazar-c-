using autobazar.Enums;
using autobazar.Properties;
using System;
using System.Collections.Generic;


namespace autobazar
{
    class Program
    {
        static void Main(string[] args)
        {

            AutobazarManager.RunTheAutobazar();

            //DatabaseManager file = new DatabaseManager();
            //file.GetDatabase("dbCars.txt");
            //file.InsertNewCar("dbCars.txt");
            //file.DeleteCarFromDb("dbCars.txt",4);
            //file.ShowAllCars("dbCars.txt");
            //file.ChangeInformationInDb("dbCars.txt", 2);
            //Console.WriteLine(file.ShowAllCars("dbCars.txt"));



            //Console.WriteLine(file.ShowAllCars("dbCars.txt"));
            //Console.WriteLine(file.GetStringOfCarById("dbCars.txt", 8));
            //file.FromStringToCar(file.GetStringOfCarById("dbCars.txt", 8));



            Console.ReadLine();
        }
    }
}