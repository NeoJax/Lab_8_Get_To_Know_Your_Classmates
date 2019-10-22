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

        // I am sorry for the length of this program
        static void Main(string[] args)
        {
            // Call the Classmate info Method
            GetClassMateInfo();
        }

        // This method defines and sets up a class with info about them
        public static void GetClassMateInfo()
        {

            // Sets up a two-dimensional array that represents the class and their interests
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

            // This try catch makes sure everything is in range of the given numbers
            int currentStudent = -1;

            string check = ParseLife("Would you rather use a students \"number\" or \"name\"");


            currentStudent = ParseStudent(check, classmates);

            string favorites = ValidateInput();

            // This prints out the respective students favorite
            switch (favorites)
            {
                case "food":
                    Console.WriteLine($"{classmates[currentStudent, 0]}'s favorite food is " + classmates[currentStudent, 1]);
                    break;
                case "subject":
                    Console.WriteLine($"{classmates[currentStudent, 0]}'s favorite subject is " + classmates[currentStudent, 2]);
                    break;
                case "hobby":
                    Console.WriteLine($"{classmates[currentStudent, 0]}'s favorite hobby is " + classmates[currentStudent, 3]);
                    break;
            }

            Console.WriteLine();
            GetContinue();
        }

        // This determines whether someone wants to look up a student by name or number
        public static int ParseStudent(string check, string[,] classmates)
        {
            int currentStudent = 0;

            // This catches issues if there is an out of range exception
            try
            {
                switch (check)
                {
                    case "number":
                        currentStudent = ParseInteger("Welcome to our class. " +
                          "Which student would you like to know more about? " +
                          $"(Enter a number from 1-6)") - 1;

                        break;
                    case "name":
                        currentStudent = ParseName("Welcome to our class. " +
                             "Which student would you like to know more about? " +
                             "(Enter a name)");
                        break;
                    default:
                        break;
                }
                Console.Write($"Student {currentStudent + 1} is {classmates[currentStudent, 0]}. ");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Please enter a valid number.");
                currentStudent = ParseStudent(check, classmates);
            }

            return currentStudent;
        }

        // This method prompts the user to get some information
        public static string GetUserInput(string message)
        {
            Console.Write(message + " ");
            string input = Console.ReadLine();
            Console.WriteLine();
            return input;
        }

        // This method takes information from the user and makes sure it is an integer and is in range
        public static int ParseInteger(string message)
        {
            // This try catch makes sure that whatever the user inputs is an integer
            try
            {
                return int.Parse(GetUserInput(message));
            }
            catch (FormatException)
            {
                return ParseInteger(message);
            }
        }

        // This method makes sure the user calls the correct name
        public static int ParseName(string message)
        {
            string name = GetUserInput(message);
            int student = -1;
            switch (name)
            {
                case "Vince":
                    student = 0;
                    break;
                case "Spinelli":
                    student = 1;
                    break;
                case "Mikey":
                    student = 2;
                    break;
                case "T.J.":
                    student = 3;
                    break;
                case "Gretchen":
                    student = 4;
                    break;
                case "Gus":
                    student = 5;
                    break;
                default:
                    Console.WriteLine("Please enter a valid name.");
                    Console.WriteLine();
                    return ParseName(message);
            }
            return student;
        }

        // This method makes sure the answer to the favorites question is valid
        public static string ValidateInput()
        {
            // Prompts the user to pick a topic they want to know about a classmate
            string favorites = GetUserInput($"What would you like to know about them? " +
                                            $"(Enter \"food\", \"subject\", or \"hobby\")");
            switch (favorites)
            {
                case "food":
                    return "food";
                case "subject":
                    return "subject";
                case "hobby":
                    return "hobby";
                default:
                    return ValidateInput();
            }
        }

        // This method checks to see if the user wants to run through the program again
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

        // This method determines whether this program should be longer or not
        public static string ParseLife(string message)
        {
            string check = GetUserInput(message);
            switch (check)
            {
                case "name":
                    return check;
                case "number":
                    return check;
                default:
                    Console.WriteLine("Please return \"name\" or \"number\".\n");
                    return ParseLife(message);
            }
        }
    }
}
