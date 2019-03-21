using autobazar.Properties;
using System;

namespace autobazar
{
    public class AutobazarManager
    {
        private static string Route = "dbCars.txt";
        private DatabaseManager _manager = new DatabaseManager();
        public void RunTheAutobazar()
        {

            if (_manager.ConnectToDb(Route))
            {
                Console.WriteLine(Resources.AutobazarManager_RunTheAutobazar_ConnectionOk);
            }
            else
            {
                Console.WriteLine(Resources.AutobazarManager_RunTheAutobazar_ConnectionNewFile);
            }
            _manager.GetCarListFromDB(Route);
            bool wishToExit = false;

            while (!wishToExit)
            {
                Console.WriteLine(Resources.AutobazarManager_RunTheAutobazar_Welcome);
                string userInput = Console.ReadLine();
                bool isTheInputCorrect = byte.TryParse(userInput, out byte parsedByte);
                if (isTheInputCorrect && parsedByte >= 0 && parsedByte <= 3)
                {
                    switch (parsedByte)
                    {
                        case 0:
                            Console.Clear();
                            if (_manager.ShowAllCars() == null)
                            {
                                Console.WriteLine(Resources.BazarManager_ShowAllCars_EmptyDb);
                                break;
                            }
                            Console.WriteLine(_manager.ShowAllCars());
                            break;

                        case 1:
                            Console.Clear();
                            if (_manager.InsertNewCar(Route))
                            {
                                Console.WriteLine("Car has been saved");
                            }
                            else
                            {
                                Console.WriteLine("Car has not been saved");
                            }
                            break;

                        case 2:
                            Console.Clear();
                            bool wishToExitMenu = false;
                            while (!wishToExitMenu)
                            {
                                Console.WriteLine(_manager.ShowAllCars());
                                if (_manager.ShowAllCars() == null)
                                {
                                    Console.WriteLine(Resources.BazarManager_ShowAllCars_EmptyDb);
                                    wishToExitMenu = true;
                                }
                                else
                                {
                                    int parsedInt = _manager.ParseStringToInt(Resources.AutobazarManager_RunTheAutobazar_DeleteWelcome, 0, _manager.GetNewId());
                                    if (parsedInt == -1)
                                    {
                                        Console.Clear();
                                        wishToExitMenu = true;
                                    }
                                    else
                                    {
                                        Car car = _manager.GetCarById(parsedInt);

                                        if (car == null)
                                        {
                                            Console.WriteLine("Car Id is not in the DataBase");
                                        }
                                        else
                                        {
                                            _manager.DeleteCarFromDbByID(Route, car);
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
                                Console.WriteLine(_manager.ShowAllCars());
                                if (_manager.ShowAllCars() == null)
                                {
                                    Console.WriteLine(Resources.BazarManager_ShowAllCars_EmptyDb);
                                    wishToExitMenu2 = true;
                                }
                                else
                                {
                                    int parsedInt = _manager.ParseStringToInt(Resources.AutobazarManager_RunTheAutobazar_UpdateWelcome, 0, _manager.GetNewId());
                                    if (parsedInt == -1)
                                    {
                                        Console.Clear();
                                        wishToExitMenu2 = true;
                                    }
                                    else
                                    {
                                        Car car = _manager.GetCarById(parsedInt);

                                        if (car == null)
                                        {
                                            Console.WriteLine("Car Id is not in the DataBase");
                                        }
                                        else
                                        {
                                            _manager.ChangeInformationInDb(parsedInt);
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
                else if (parsedByte == 4)
                {
                    Console.WriteLine(Resources.AutobazarManager_RunTheAutobazar_Goodbye);
                    wishToExit = true;
                    continue;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{Resources.BazarManager_ParseMethods_WrongInput}\n");
                }
            }
        }
    }
}