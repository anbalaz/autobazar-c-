using autobazar.Enums;
using autobazar.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace autobazar
{
    public class DatabaseManager
    {
        private static List<string> _cars = new List<string>();

        private List<string> GetDb(String localDatabase)
        {
            return File.ReadAllLines(localDatabase).ToList();
        }

        private void CheckIfFileExists(String localDatabase)
        {
            if (!File.Exists(localDatabase))
            {
                File.Create(localDatabase).Close();
            }
        }

        /// <summary>
        /// Insert introducing string of property you wish to set. Returns int that is parsed or -1 if user pressed exit.
        /// </summary>
        public int ParseStringToInt(string settingAProperty, int minValue, int maxValue)
        {
            bool isExit = false;
            while (!isExit)
            {
                Console.WriteLine(settingAProperty);
                string userInput = Console.ReadLine();
                if (userInput == "exit")
                {
                    isExit = true;
                    continue;
                }
                else
                {
                    bool IsStringParsedToNumber = int.TryParse(userInput, out int parsedNumber);
                    if (IsStringParsedToNumber && parsedNumber >= minValue && parsedNumber <= maxValue)
                    {
                        return parsedNumber;
                    }
                    else
                    {
                        Console.WriteLine(Resources.BazarManager_ParseMethods_WrongInput);
                        continue;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// Insert introducing string of property you wish to set. Returns int that is parsed or 0 if user pressed exit.
        /// </summary>
        private T ParseStringToEnum<T>(string settingAProperty)
        {
            bool isExit = false;
            while (!isExit)
            {
                int enumLength = Enum.GetValues(typeof(T)).Length;
                for (int i = 1; i < enumLength; i++)
                {
                    Console.Write(Enum.GetName(typeof(T), i) + ": " + i + "; ");
                }
                Console.WriteLine($"\n{settingAProperty}");
                string userInput = Console.ReadLine();
                if (userInput == "exit")
                {
                    isExit = true;
                }
                else
                {
                    bool IsInputNumber = int.TryParse(userInput, out int parsedNumber);
                    if (IsInputNumber && Enum.IsDefined(typeof(T), parsedNumber) && parsedNumber != 0)
                    {
                        return (T)Enum.Parse(typeof(T), userInput, true);
                    }
                    else
                    {
                        Console.WriteLine(Resources.BazarManager_ParseMethods_WrongInput);
                        continue;
                    }
                }
            }
            return default(T);
        }

        private bool ParseStringToBool(string settingAProperty)
        {
            bool isExit = false;
            while (!isExit)
            {
                Console.WriteLine(settingAProperty);
                string userinput = Console.ReadLine();
                bool IsInputNumber = Int32.TryParse(userinput, out int parsedNumber);

                if (IsInputNumber && parsedNumber > 0 && parsedNumber < 3)
                {
                    return (parsedNumber < 2) ? true : false;
                }
                else
                {
                    Console.WriteLine(Resources.BazarManager_ParseMethods_WrongInput);
                    continue;
                }
            }
            return false;
        }

        private int ChangeCarProperty(int intProperty, string updateTheProperty, string settingAProperty, int minValue, int maxValue)
        {
            bool isExit = false;
            while (!isExit)
            {
                Console.Write($"{updateTheProperty} current ({intProperty})\n");
                string userInput = Console.ReadLine();

                bool IsStringParsedToInt = int.TryParse(userInput, out int parsedInt);
                if (IsStringParsedToInt && parsedInt >= 0 && parsedInt <= 1)
                {
                    return (parsedInt == 0) ? ParseStringToInt(settingAProperty, minValue, maxValue) : intProperty;
                }
                else
                {
                    Console.WriteLine(Resources.BazarManager_ParseMethods_WrongInput);
                    continue;
                }
            }
            return intProperty;
        }

        private bool ChangeCarProperty(bool boolProperty, string updateTheProperty, string settingAProperty)
        {
            bool isExit = false;
            while (!isExit)
            {
                Console.Write($"{updateTheProperty} current ({boolProperty})\n");
                string userInput = Console.ReadLine();

                bool IsStringParsedToInt = int.TryParse(userInput, out int parsedInt);
                if (IsStringParsedToInt && parsedInt >= 0 && parsedInt <= 1)
                {
                    return (parsedInt == 0) ? ParseStringToBool(settingAProperty) : boolProperty;
                }
                else
                {
                    Console.WriteLine(Resources.BazarManager_ParseMethods_WrongInput);
                    continue;
                }
            }
            return boolProperty;
        }

        private T ChangeCarProperty<T>(T enumProperty, string updateTheProperty, string settingAProperty)
        {
            bool isExit = false;
            while (!isExit)
            {
                Console.Write($"{updateTheProperty} current ({Enum.GetName(typeof(CarBrand), enumProperty)})\n");
                string userInput = Console.ReadLine();


                bool IsStringParsedToInt = int.TryParse(userInput, out int parsedInt);
                if (IsStringParsedToInt && parsedInt >= 0 && parsedInt <= 1)
                {
                    return (parsedInt == 0) ? ParseStringToEnum<T>(settingAProperty) : enumProperty;
                }
                else
                {
                    Console.WriteLine(Resources.BazarManager_ParseMethods_WrongInput);
                    continue;
                }
            }
            return enumProperty;
        }

        private Car ChangeInformationInCar(Car car)
        {
            car.Vintage = ChangeCarProperty(car.Vintage, Resources.BazarManager_ChangeCarProperty_Vintage, Resources.BazarManager_ParseStringToInt_Vintage, 1990, DateTime.Today.Year);
            car.Kilometers = ChangeCarProperty(car.Kilometers, Resources.BazarManager_ChangeCarProperty_Kilometers, Resources.BazarManager_ParseStringToInt_Doors, 0, 2000000);
            car.Price = ChangeCarProperty(car.Price, Resources.BazarManager_ChangeCarProperty_Price, Resources.BazarManager_ParseStringToInt_Price, 100, 2000000);
            car.NumberOfDoors = ChangeCarProperty(car.NumberOfDoors, Resources.BazarManager_ChangeCarProperty_Doors, Resources.BazarManager_ParseStringToInt_Doors, 0, 15);
            car.Brand = ChangeCarProperty(car.Brand, Resources.BazarManager_ChangeCarProperty_CarBrand, Resources.BazarManager_ParseStringToEnum_CarBrand);
            car.Type = ChangeCarProperty(car.Type, Resources.BazarManager_ChangeCarProperty_CarType, Resources.BazarManager_ParseStringToEnum_CarType);
            car.TypeOfFuel = ChangeCarProperty(car.TypeOfFuel, Resources.BazarManager_ChangeCarProperty_Fuel, Resources.BazarManager_ParseStringToEnum_Fuel);
            car.TownOfSelling = ChangeCarProperty(car.TownOfSelling, Resources.BazarManager_ChangeCarProperty_Fuel, Resources.BazarManager_ParseStringToEnum_Fuel);
            car.IsCarCrashed = ChangeCarProperty(car.IsCarCrashed, Resources.BazarManager_ChangeCarProperty_IsCarCrashed, Resources.BazarManager_ParseStringToBool_IsTheCrashed);

            return car;
        }

        public void PopulateCarList(String localDatabase)
        {
            _cars = GetDb(localDatabase);
        }

        public String GetStringOfCarById(int numberID)
        {
            String carString = String.Empty;
            for (int i = 0; i < _cars.Count; i++)
            {
                if (numberID == Convert.ToInt32(_cars[i].Substring(0, _cars[i].IndexOf('\t'))))
                {
                    return _cars[i];
                }
            }
            return carString;
        }

        public void AddCarToList(String localDatabase, Car car)
        {
            _cars.Add(car.ToString());
            File.WriteAllLines(localDatabase, _cars);
        }

        public void DeleteCarFromDbbyID(String localDatabase, string carString)
        {
            int numberID = Convert.ToInt32(carString.Substring(0, carString.IndexOf('\t')));
            _cars = GetDb(localDatabase);

            _cars = _cars.Where(car => Convert.ToInt32(car.Substring(0, car.IndexOf('\t'))) != numberID).ToList();

            for (int i = 0; i < _cars.Count; i++)
            {
                if (numberID == Convert.ToInt32(_cars[i].Substring(0, _cars[i].IndexOf('\t'))))
                {
                    _cars.Remove(_cars[i]);
                    break;
                }
            }
            //_cars.Remove(_cars[])
            Console.WriteLine();
            File.WriteAllLines(localDatabase, _cars);
        }

        public void ChangeInformationInDb(int numberID)
        {
            string carString = GetStringOfCarById(numberID);

            Console.WriteLine($"Car you selected is: \n{carString}");

            Car updatedCar = ChangeInformationInCar(FromStringToCar(carString));

            for (int i = 0; i < _cars.Count; i++)
            {
                if (updatedCar.ID == Convert.ToInt32(_cars[i].Substring(0, _cars[i].IndexOf('\t'))))
                {
                    _cars[i] = updatedCar.ToString();
                }
            }
        }

        public String ShowAllCars()
        {

            if (_cars.Count != 0)
            {
                string cars = string.Empty;
                _cars.ForEach(car => cars += car + "\n");
                return cars;
            }
            return Resources.BazarManager_ShowAllCars_EmptyDb;
        }

        public int GetNewId()
        {
            List<int> idList = new List<int>();
            if (_cars.Count != 0)
            {
                _cars.ForEach(car => idList.Add(Convert.ToInt32(car.Substring(0, car.IndexOf('\t')))));
            }
            else
            {
                return 0;
            }
            return idList.Max() + 1;
        }

        public Car FromStringToCar(string carString)
        {
            string[] properties = carString.Split('\t');
            // string to int
            bool isStringConvertedToInt = Int32.TryParse(properties[0], out int id);
            if (!isStringConvertedToInt)

            {
                Console.WriteLine("The File or data are corrupted");
            }
            // string to short

            bool isStringConvertedToShort = int.TryParse(properties[1], out int vintage);
            if (!isStringConvertedToInt)
            {
                Console.WriteLine("The File or data are corrupted");
            }

            // string to int
            bool isStringConvertedToInt1 = int.TryParse(properties[2], out int kilometers);
            if (!isStringConvertedToInt1)

            {
                Console.WriteLine("The File or data are corrupted");
            }
            // string to Enum
            bool isStringConvertedToEnum = Enum.TryParse(properties[3], out CarBrand carBrand);
            if (!isStringConvertedToEnum)
            {
                Console.WriteLine("The File or data are corrupted");
            }
            // string to Enum
            bool isStringConvertedToEnum1 = Enum.TryParse(properties[4], out CarType carType);
            if (!isStringConvertedToEnum1)
            {
                Console.WriteLine("The File or data are corrupted");
            }
            // string to Enum
            bool isStringConvertedToEnum2 = Enum.TryParse(properties[5], out Fuel fuel);
            if (!isStringConvertedToEnum2)
            {
                Console.WriteLine("The File or data are corrupted");
            }
            // string to decimal
            bool isStringConvertedToDecimal = int.TryParse(properties[6], out int price);
            if (!isStringConvertedToDecimal)
            {
                Console.WriteLine("The File or data are corrupted");
            }
            // string to Enum
            bool isStringConvertedToEnum3 = Enum.TryParse(properties[7], out Town town);
            if (!isStringConvertedToEnum3)
            {
                Console.WriteLine("The File or data are corrupted");
            }
            // string to int
            bool isStringConvertedToInt2 = int.TryParse(properties[8], out int doors);
            if (!isStringConvertedToInt2)

            {
                Console.WriteLine("The File or data are corrupted");
            }
            // string to bool
            bool isStringConvertedToBool = bool.TryParse(properties[9], out bool isCarCrashed);
            if (!isStringConvertedToBool)

            {
                Console.WriteLine("The File or data are corrupted");
            }

            Car car = new Car(id, vintage, kilometers, carBrand, carType, fuel, price, town, doors, isCarCrashed);
            return car;
        }

        public bool InsertNewCar(String localDatabase)
        {
            int vintageNumber = ParseStringToInt(Resources.BazarManager_ParseStringToInt_Vintage, 1990, DateTime.Today.Year);
            if (vintageNumber == -1)
            {
                return false;
            }
            int kilometers = ParseStringToInt(Resources.BazarManager_ParseStringToInt_Kilometers, 0, 2000000);
            if (kilometers == -1)
            {
                return false;
            }
            int price = ParseStringToInt(Resources.BazarManager_ParseStringToInt_Price, 100, 2000000);
            if (price == -1)
            {
                return false;
            }
            int numberOfDoors = ParseStringToInt(Resources.BazarManager_ParseStringToInt_Doors, 0, 15);
            if (numberOfDoors == -1)
            {
                return false;
            }
            CarBrand carBrandEnum = ParseStringToEnum<CarBrand>(Resources.BazarManager_ParseStringToEnum_CarBrand);
            if (carBrandEnum == 0)
            {
                return false;
            }
            CarType carTypeEnum = ParseStringToEnum<CarType>(Resources.BazarManager_ParseStringToEnum_CarType);
            if (carTypeEnum == 0)
            {
                return false;
            }
            Fuel fuelEnum = ParseStringToEnum<Fuel>(Resources.BazarManager_ParseStringToEnum_Fuel);
            if (fuelEnum == 0)
            {
                return false;
            }
            Town townEnum = ParseStringToEnum<Town>(Resources.BazarManager_ParseStringToEnum_Town);
            if (townEnum == 0)
            {
                return false;
            }
            bool isCrashed = ParseStringToBool(Resources.BazarManager_ParseStringToBool_IsTheCrashed);

            Car car = new Car(GetNewId(), vintageNumber, kilometers, carBrandEnum, carTypeEnum, fuelEnum, price, townEnum, numberOfDoors, isCrashed);
            AddCarToList(localDatabase, car);
            return true;
        }
    }
}