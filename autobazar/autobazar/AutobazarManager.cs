using autobazar.Properties;
using System;

namespace autobazar
{
    public class AutobazarManager
    {
        public readonly string Route; 
        private DatabaseManager _manager = new DatabaseManager();

        public AutobazarManager(string route)
        {
            Route = route;
        }

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
                            //Show all cars in db
                            Console.Clear();
                            if (_manager.ShowAllCars() == null)
                            {
                                Console.WriteLine(Resources.BazarManager_ShowAllCars_EmptyDb);
                                break;
                            }
                            Console.WriteLine(_manager.ShowAllCars());
                            break;

                        case 1:
                            //Inserting new car
                            Console.Clear();
                            if (_manager.InsertNewCar(Route))
                            {
                                Console.WriteLine(Resources.AutobazarManager_RunTheAutobazar_SaveNewCar);
                            }
                            else
                            {
                                Console.WriteLine(Resources.AutobazarManager_RunTheAutobazar_NoSaveCar);
                            }
                            break;

                        case 2:
                            //Delete car
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
                                            Console.WriteLine(Resources.AutobazarManager_RunTheAutobazar_CarNotInDb);
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
                            //Update existing car
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
                                            Console.WriteLine(Resources.AutobazarManager_RunTheAutobazar_CarNotInDb);
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
                //exit Autobazar
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