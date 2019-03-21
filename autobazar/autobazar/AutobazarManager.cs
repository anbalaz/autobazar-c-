using autobazar.Properties;
using System;

namespace autobazar
{
    public class AutobazarManager
    {
        private static string route = "dbCars.txt";

        public static void RunTheAutobazar()
        {
            DatabaseManager manager = new DatabaseManager();
            if (manager.ConnectToDb(route))
            {
                Console.WriteLine(Resources.AutobazarManager_RunTheAutobazar_ConnectionOk);
            }
            else
            {
                Console.WriteLine(Resources.AutobazarManager_RunTheAutobazar_ConnectionNewFile);
            }
            manager.GetCarListFromDB(route);
            bool wishToExit = false;

            while (!wishToExit)
            {
                Console.WriteLine(Resources.AutobazarManager_RunTheAutobazar_Welcome, "\n", "\n", "\n", "\n", "\n");
                string userInput = Console.ReadLine();
                bool isTheInputCorrect = byte.TryParse(userInput, out byte parsedByte);
                if (isTheInputCorrect && parsedByte >= 0 && parsedByte <= 3)
                {
                    switch (parsedByte)
                    {
                        case 0:
                            Console.Clear();
                            Console.WriteLine(manager.ShowAllCars());
                            break;

                        case 1:
                            Console.Clear();
                            if (manager.InsertNewCar(route))
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
                                Console.WriteLine(manager.ShowAllCars());
                                if (manager.ShowAllCars().Equals(Resources.BazarManager_ShowAllCars_EmptyDb))
                                {
                                    wishToExitMenu = true;
                                }
                                else
                                {
                                    int parsedInt = manager.ParseStringToInt(Resources.AutobazarManager_RunTheAutobazar_DeleteWelcome, 0, manager.GetNewId());
                                    if (parsedInt == -1)
                                    {
                                        Console.Clear();
                                        wishToExitMenu = true;
                                    }
                                    else
                                    {
                                        Car car = manager.GetCarById(parsedInt);

                                        if (car == null)
                                        {
                                            Console.WriteLine("Car Id is not in the DataBase");
                                        }
                                        else
                                        {
                                            manager.DeleteCarFromDbByID(route, car);
                                            wishToExitMenu = true;
                                        }
                                    }
                                }
                            }
                            break;

                        default:
                            Console.Clear();
                            bool wishToExitMenu2 = false;

                            while (!wishToExitMenu2)
                            {
                                Console.WriteLine(manager.ShowAllCars());
                                if (manager.ShowAllCars().Equals(Resources.BazarManager_ShowAllCars_EmptyDb))
                                {
                                    wishToExitMenu2 = true;
                                }
                                else
                                {
                                    int parsedInt = manager.ParseStringToInt(Resources.AutobazarManager_RunTheAutobazar_UpdateWelcome, 0, manager.GetNewId());
                                    if (parsedInt == -1)
                                    {
                                        Console.Clear();
                                        wishToExitMenu2 = true;
                                    }
                                    else
                                    {
                                        Car car = manager.GetCarById(parsedInt);

                                        if (car == null)
                                        {
                                            Console.WriteLine("Car Id is not in the DataBase");
                                        }
                                        else
                                        {
                                            manager.ChangeInformationInDb(parsedInt);
                                            wishToExitMenu2 = true;
                                        }
                                    }
                                }
                            }
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