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
            AutobazarManager bazar = new AutobazarManager("dbCars.txt");

            bazar.RunTheAutobazar();
            Console.ReadLine();
        }
    }
}