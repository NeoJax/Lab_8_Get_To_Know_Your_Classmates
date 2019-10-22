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
            // Classmate: Favorite Food, Hometown, Favorite Hobby 
        }

        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static int ParseInteger(string message)
        {
            try
            {
                return int.Parse(GetUserInput(message));
            }
            catch
            {
                return ParseInteger(message);
            }
        }

        public static void GetClassMateInfo()
        {

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
