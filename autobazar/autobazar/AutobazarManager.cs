using autobazar.Enums;
using autobazar.Properties;
using System;

namespace autobazar
{
    public class AutobazarManager
    {
        private static string Route = "dbCars.txt";
        private DatabaseManager _database = new DatabaseManager();
        private ConsoleManager _console = new ConsoleManager();
        public void RunTheAutobazar()
        {

            if (_database.ConnectToDb(Route))
            {
                _console.Show(Resources.AutobazarManager_RunTheAutobazar_ConnectionOk);
            }
            else
            {
                _console.Show(Resources.AutobazarManager_RunTheAutobazar_ConnectionNewFile);
            }
            _database.GetCarListFromDB(Route);
            bool wishToExit = false;

            while (!wishToExit)
            {
                _console.Show(Resources.AutobazarManager_RunTheAutobazar_Welcome);
                int parsedUserInputToInt = _console.UserInputInt(0, 4);
                if (parsedUserInputToInt >= 0 && parsedUserInputToInt <= 3)
                {
                    switch (parsedUserInputToInt)
                    {
                        case 0:
                            Console.Clear();
                            if (_database.ShowAllCars() == null)
                            {
                                _console.Show(Resources.BazarManager_ShowAllCars_EmptyDb);
                                break;
                            }
                            _console.Show(_database.ShowAllCars());
                            break;

                        case 1:
                            Console.Clear();
                            if (InsertNewCar(Route))
                            {
                                _console.Show("Car has been saved");
                            }
                            else
                            {
                                _console.Show("Car has not been saved");
                            }
                            break;

                        case 2:
                            Console.Clear();
                            bool wishToExitMenu = false;
                            while (!wishToExitMenu)
                            {
                                _console.Show(_database.ShowAllCars());
                                if (_database.ShowAllCars() == null)
                                {
                                    _console.Show(Resources.BazarManager_ShowAllCars_EmptyDb);
                                    wishToExitMenu = true;
                                }
                                else
                                {
                                    int parsedInt = _database.ParseStringToInt(Resources.AutobazarManager_RunTheAutobazar_DeleteWelcome, 0, _database.GetNewId());
                                    if (parsedInt == -1)
                                    {
                                        Console.Clear();
                                        wishToExitMenu = true;
                                    }
                                    else
                                    {
                                        Car car = _database.GetCarById(parsedInt);

                                        if (car == null)
                                        {
                                            _console.Show("Car Id is not in the DataBase");
                                        }
                                        else
                                        {
                                            _database.DeleteCarFromDbByID(Route, car);
                                            wishToExitMenu = true;
                                        }
                                    }
                                }
                            }
                            break;

                        case 3:
                            Console.Clear();
                            bool wishToExitMenu2 = false;

                            while (!wishToExitMenu2)
                            {
                                _console.Show(_database.ShowAllCars());
                                if (_database.ShowAllCars() == null)
                                {
                                    _console.Show(Resources.BazarManager_ShowAllCars_EmptyDb);
                                    wishToExitMenu2 = true;
                                }
                                else
                                {
                                    int parsedInt = _database.ParseStringToInt(Resources.AutobazarManager_RunTheAutobazar_UpdateWelcome, 0, _database.GetNewId());
                                    if (parsedInt == -1)
                                    {
                                        Console.Clear();
                                        wishToExitMenu2 = true;
                                    }
                                    else
                                    {
                                        Car car = _database.GetCarById(parsedInt);

                                        if (car == null)
                                        {
                                            _console.Show("Car Id is not in the DataBase");
                                        }
                                        else
                                        {
                                            _database.ChangeInformationInDb(parsedInt);
                                            wishToExitMenu2 = true;
                                        }
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }

                else if (parsedUserInputToInt == 4)
                {
                    _console.Show(Resources.AutobazarManager_RunTheAutobazar_Goodbye);
                    wishToExit = true;
                    continue;
                }
                else
                {
                    Console.Clear();
                    _console.Show($"{Resources.BazarManager_ParseMethods_WrongInput}\n");
                }
            }
        }
        public bool InsertNewCar(String localDatabase)
        {
            _console.Show(Resources.BazarManager_ParseStringToInt_Vintage);
            int vintageNumber = _console.UserInputInt(1900, DateTime.Today.Year);
            if (vintageNumber == -1)
            {
                return false;
            }
            _console.Show(Resources.BazarManager_ParseStringToInt_Kilometers);
            int kilometers = _console.UserInputInt(0, 2000000);
            if (kilometers == -1)
            {
                return false;
            }
            _console.Show(Resources.BazarManager_ParseStringToInt_Price);
            int price = _console.UserInputInt( 100, 2000000);
            if (price == -1)
            {
                return false;
            }
            _console.Show(Resources.BazarManager_ParseStringToInt_Doors);
            int numberOfDoors = _console.UserInputInt(0, 15);
            if (numberOfDoors == -1)
            {
                return false;
            }
            _console.Show(Resources.BazarManager_ParseStringToEnum_CarBrand);
            string parsedBrandEnumString = _console.UserInputString(1, Enum.GetValues(typeof(CarBrand)).Length);
            CarBrand carBrandEnum = (CarBrand)Enum.Parse(typeof(CarBrand), parsedBrandEnumString);
            if (carBrandEnum == 0)
            {
                return false;
            }
            _console.Show(Resources.BazarManager_ParseStringToEnum_CarType);
            string parsedTypeEnumString = _console.UserInputString(1, Enum.GetValues(typeof(CarType)).Length);
            CarType carTypeEnum = (CarType)Enum.Parse(typeof(CarType), parsedTypeEnumString);
            if (carTypeEnum == 0)
            {
                return false;
            }
            _console.Show(Resources.BazarManager_ParseStringToEnum_Fuel);
            string parsedFuelEnumString = _console.UserInputString(1, Enum.GetValues(typeof(Fuel)).Length);
            Fuel fuelEnum = (Fuel)Enum.Parse(typeof(Fuel), parsedFuelEnumString);
            if (fuelEnum == 0)
            {
                return false;
            }
            _console.Show(Resources.BazarManager_ParseStringToEnum_Town);
            string parsedTownEnumString = _console.UserInputString(1, Enum.GetValues(typeof(Town)).Length);
            Town townEnum = (Town)Enum.Parse(typeof(Town), parsedFuelEnumString);
            if (townEnum == 0)
            {
                return false;
            }
            _console.Show(Resources.BazarManager_ParseStringToBool_IsTheCrashed);
            bool isCrashed = false;
            if (_console.UserInputInt(0, 1) == 1)
            {
                isCrashed = true;
            }
            else
            {
                return false;
            }
            Car car = new Car(_database.GetNewId(), vintageNumber, kilometers, carBrandEnum, carTypeEnum, fuelEnum, price, townEnum, numberOfDoors, isCrashed);
            _database.AddCar(car);
            _database.UpdateCarsToDb(localDatabase);
            return true;
        }
    }
}