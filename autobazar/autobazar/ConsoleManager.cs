using System;

namespace autobazar
{
    public class ConsoleManager
    {
        public void Show(string stringToShow)
        {
            Console.WriteLine(stringToShow);
        }
        public int UserInputInt(int minValue, int maxValue)
        {
            while (true)
            {
                string userInput = Console.ReadLine().ToLower();
                if (userInput == "exit")
                {
                    return -1;
                }
                else
                {
                    bool IsStringParsedToNumber = int.TryParse(userInput, out int parsedInt);
                    if (IsStringParsedToNumber && parsedInt >= minValue && parsedInt <= maxValue)
                    {
                        return parsedInt;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
        public string UserInputString(int minValue, int maxValue)
        {
            while (true)
            {
                string userInput = Console.ReadLine().ToLower();
                if (userInput == "exit")
                {
                    return Constants.ESCAPE_STRING;
                }
                else
                {
                    bool IsStringParsedToNumber = int.TryParse(userInput, out int parsedInt);
                    if (IsStringParsedToNumber && parsedInt >= minValue && parsedInt <= maxValue)
                    {
                        return userInput;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}
