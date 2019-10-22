// ===============================
// AUTHOR     : Jonathan Lubaway
// CREATE DATE: October 22nd, 2019
// PURPOSE    : Write a program that will recognize invalid user inputs when the
//              user requests information about students in a class
// ===============================
using System;

namespace Lab_8_Get_To_Know_Your_Classmates
{
    class Program
    {
        static void Main(string[] args)
        {
            GetClassMateInfo();
        }

        public static string GetUserInput(string message)
        {
            Console.Write(message + " ");
            string input = Console.ReadLine();
            Console.WriteLine();
            return input;
        }

        public static int ParseRange(int min, int max, string message)
        {
            try
            {
                int number = int.Parse(GetUserInput(message));

                if (number >= min && number <= max)
                {
                    return number;
                }
                else
                {
                    return ParseRange(min, max, $"Please enter a valid number. ({min} - {max})  ");
                }
            }
            catch
            {
                return ParseRange(min, max, message);
            }
        }

        public static void GetClassMateInfo()
        {
            string[,] classmates = new string[6, 4];

            // Names of the students
            classmates[0, 0] = "Vince";
            classmates[1, 0] = "Spinelli";
            classmates[2, 0] = "Mikey";
            classmates[3, 0] = "T.J.";
            classmates[4, 0] = "Gretchen";
            classmates[5, 0] = "Gus";

            // Favorite food of the students
            classmates[0, 1] = "Fajitas";
            classmates[1, 1] = "Fries";
            classmates[2, 1] = "Spaghetti";
            classmates[3, 1] = "Burgers";
            classmates[4, 1] = "Sandwiches";
            classmates[5, 1] = "Roast Lamb";

            // Favorite subjects of the students
            classmates[0, 2] = "Physical Education";
            classmates[1, 2] = "Band";
            classmates[2, 2] = "History";
            classmates[3, 2] = "Math";
            classmates[4, 2] = "Science";
            classmates[5, 2] = "Art";

            // Favorite hobby of the students
            classmates[0, 3] = "Basketball";
            classmates[1, 3] = "Playing Guitar";
            classmates[2, 3] = "Reading";
            classmates[3, 3] = "Hanging with friends";
            classmates[4, 3] = "Chemistry";
            classmates[5, 3] = "Drawing";

            int currentStudent = ParseRange(1, 6, "Welcome to the class of Third Street Elementary " +
                              "School, which student would you like to know more" +
                              "about? (Enter a number from 1-6)");
            Console.Write($"Student {currentStudent} is {classmates[currentStudent, 0]}." +
                              $"What would you like to know about them? (Enter \"food\"," +
                              $"\"subject\", or \"hobby\")");
            string favorites = GetUserInput($"What would you like to know about them? " +
                               $"(Enter \"food\", \"subject\", or \"hobby\")");
            if (favorites == "food")
            {
                Console.WriteLine(classmates[currentStudent, 1]);
            }
            else if (favorites == "subject")
            {
                Console.WriteLine(classmates[currentStudent, 2]);
            }
            else if (favorites == "hobby")
            {
                Console.WriteLine(classmates[currentStudent, 3]);
            }

        }

        public static void GetContinue()
        {
            string input = GetUserInput("Do you want to continue? (y/n)");
            if (input == "y")
            {
                GetClassMateInfo();
            }
            else if (input == "n")
            {
                Console.WriteLine("Thank you!");
            }
            else
            {
                GetContinue();
            }

        }
    }
}
