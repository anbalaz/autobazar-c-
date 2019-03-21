using autobazar.Enums;
using System;
using System.Text;

namespace autobazar
{
    public class Car
    {
        public readonly int ID;
        public int Vintage { get; set; }
        public int Kilometers { get; set; }
        public CarBrand Brand { get; set; }
        public CarType Type { get; set; }
        public Fuel TypeOfFuel { get; set; }
        public int Price { get; set; }
        public Town TownOfSelling { get; set; }
        public int NumberOfDoors { get; set; }
        public bool IsCarCrashed { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{ID}\t");
            sb.Append($"{Vintage}\t");
            sb.Append($"{Kilometers}\t");
            sb.Append($"{Enum.GetName(typeof(CarBrand), Brand)}\t");
            sb.Append($"{Enum.GetName(typeof(CarType), Type)}\t");
            sb.Append($"{Enum.GetName(typeof(Fuel), TypeOfFuel)}\t");
            sb.Append($"{Price}\t");
            sb.Append($"{Enum.GetName(typeof(Town), TownOfSelling)}\t");
            sb.Append($"{NumberOfDoors}\t");
            sb.Append($"{IsCarCrashed}");

            return sb.ToString();
        }

        public Car(int carId, int vintage, int kilometers, CarBrand brand, CarType type,
            Fuel fuelInTank, int price, Town townOfSelling, int numberOfDoors, bool isCarCrashed)
        {
            ID = carId;
            Vintage = vintage;
            Kilometers = kilometers;
            Brand = brand;
            Type = type;
            TypeOfFuel = fuelInTank;
            Price = price;
            TownOfSelling = townOfSelling;
            NumberOfDoors = numberOfDoors;
            IsCarCrashed = isCarCrashed;
        }
        public Car()
        {

        }
    }
}