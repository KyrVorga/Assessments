/* File Information
Title: SDV503 Assessment 3
Author: Rhylei Tremlett
Version: 1.7
Date: 18/06/2022
------------------------------------------------------------- */
using System;

namespace Assessment_3
{
    public class JavaScript : Program
    {
         // creates a jagged array with random values,
         // length is defined by the user.
        private int[][] Construct(int size, int min, int max)
        {
            // initialize an empty array of arrays with length == size
            int[][] jagged = new int[size][];
            // generate a random integer to be used for sub array length
            Random rnd = new Random();
            // iterate over empty jagged
            for (int i = 0; i < jagged.Length; i++)
            {
                // give the sub array a length between 1 - 10
                int col = rnd.Next(5, 10);
                jagged[i] = new int[col];
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    // create a random number to fill index j
                    jagged[i][j] = rnd.Next(min-1, max+1);
                }
            }
            return jagged;
        }

        // Prints out the contents of the jagged array
        private void WriteArray(int[][] jagged)
        {
            for (int i = 0; i < jagged.Length; i++)
            {
                Console.WriteLine("Sub-Array: ", i);
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.WriteLine(jagged[i][j]);
                } 
            }
        }


        public void Begin()
        {
            // clear console
            Console.Clear();
            // Instantiate the Program class as an object
            JavaScript javascript = new JavaScript();

            // explain the program to user
            Console.WriteLine("This program will randomly generate a jagged array, you will be asked to define the length of the jagged array. Each sub-array will have random lengths between 5 and 10. The program will ask for a minimum value and a maximum value and will fill the sub-arrays with numbers inside that range (values are inclusive).\n");
            
            // ask user to enter a value for the array length
            int size = InputInt("Enter the length of the jagged array: ", Int32.MinValue, Int32.MaxValue);

            // take user input and pass it as an argument to the construct method
           int min = InputInt("Define the minimum: ", Int32.MinValue, Int32.MaxValue);
            int max = InputInt("Define the maximum: ", Int32.MinValue, Int32.MaxValue);

            // construct the jagged array
            int[][] jaggedArray = javascript.Construct(size, min, max);

            // setup the array to be returned
            int[] largestNumbers = new int[size];

            // iterate over the entire jagged array
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                int largestNum = min;
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                   if (jaggedArray[i][j] > largestNum)
                    {
                        largestNum = jaggedArray[i][j];
                    } 
                }
                largestNumbers[i] = largestNum;
            }

            // write out all of the elements of the jagged array
            javascript.WriteArray(jaggedArray);

            // write out the largest numbers
            Console.WriteLine("\nLargest Numbers:");
            foreach (int number in largestNumbers) { Console.WriteLine(number); }
            Console.ReadLine();
        }
    }

    public class Calculator : Program
    {
        public void Begin()
        {
            // intialize the calculator class
            Calculator calculator = new Calculator();

            // begin an infinite loop
            bool flag = true;
            while (flag)
            {
                Console.Clear();

                // take input to select a math method
                int choice = InputInt("Please select which operator you would like to use:\n1. Addition\n2. Subtraction\n3. Division\n4. Muliplication\n5. Power\n6. Remainder\n7. EXIT\n", 1, 7);
                // if the user choose to exit, then break the loop
                // Environment.Exit() and flag = false, don't work the way I want them too here...
                if (choice == 7) { break; }

                // take input for first and second numbers
                double first = InputDouble("Enter the first number: ", Double.MinValue, Double.MaxValue);
                double second = InputDouble("Enter the second number: ", Double.MinValue, Double.MaxValue);

                // runs the math method based on 'choice' 
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Answer: " + calculator.Addition(first, second));
                        break;
                    case 2:
                        Console.WriteLine("Answer: " + calculator.Subtraction(first, second));
                        break;
                    case 3:
                        Console.WriteLine("Answer: " + calculator.Division(first, second));
                        break;
                    case 4:
                        Console.WriteLine("Answer: " + calculator.Muliplication(first, second));
                        break;
                    case 5:
                        Console.WriteLine("Answer: " + calculator.Power(first, second));
                        break;
                    case 6:
                        Console.WriteLine("Answer: " + calculator.Remainder(first, second));
                        break;
                }

                // this lets the user continue after reading the answer
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
        }

        // below are all of the mathematical methods that get called each one changes the colour scheme
        private double Addition(double value1, double value2)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            return value1 + value2;
        }
        private double Subtraction(double value1, double value2)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            return value1 - value2;
        }
        private double Division(double value1, double value2)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            return value1 / value2;
        }
        private double Muliplication(double value1, double value2)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            return value1 * value2;
        }
        private double Power(double value1, double value2)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            return Math.Pow(value1, value2);
        }
        private double Remainder(double value1, double value2)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            return value1 % value2;
        }
    }
    public class Program
    {
        /*
        Ive placed this method into this class and made the other 
        classes inherit from it so that this method doesnt need to be
        pasted into all three classes, very DRY :)

        This method takes takes a message and a range as parameters.
        It takes user input and attempts to parse it,
        if it fails it gives an error and asks for input again.

        if it succesfully parses it then is check if the value falls
        insides the range provided, if not it gives an error and repeats
        */
        public int InputInt(string message, int min, int max)
        {
            // write message to console
            Console.Write(message);
            while (true)
            {
                // take input and attempt to parse
                string input = Console.ReadLine();
                int.TryParse(input, out int result);
                // if parse is successful
                if (result != 0)
                {
                    // check if parsed value falls in the range
                    if (result <= max && result >= min)
                    {
                        return result;
                    }
                    else
                    {
                        Console.WriteLine("That was not a valid input, please try again.");
                    }
                }
                // if parse fails
                else
                {
                    Console.WriteLine("That was not a valid input, please try again.");
                }
            }
        }

        // same as above except handles double instead of int
        public double InputDouble(string message, double min, double max)
        {
            // write message to console
            Console.Write(message);
            while (true)
            {
                // take input and attempt to parse
                string input = Console.ReadLine();
                double.TryParse(input, out double result);
                // if parse is successful
                if (result != 0)
                {
                    // check if parsed value falls in the range
                    if (result <= max && result >= min)
                    {
                        return result;
                    }
                    else
                    {
                        Console.WriteLine("That was not a valid input, please try again.");
                    }
                }
                // if parse fails
                else
                {
                    Console.WriteLine("That was not a valid input, please try again.");
                }
            }
        }

        static void Main()
        {
            // initialize the program class
            Program program = new Program();
            
            // set console title
            Console.Title = "Rhylei-Tremlett-SDV503-A3";

            // take input for program selection
            int choice = program.InputInt("Please select which program you would like to run:\n(At any point press CTRL + C to Exit the program)\n1. Calculator\n2. Javascript Converted Code\n", 1, 2);

            // Run either program based on choice
            if (choice == 1)
            {
                Calculator calculator = new Calculator();
                calculator.Begin();
            }
            else if (choice == 2)
            {
                JavaScript javaScript = new JavaScript();
                javaScript.Begin();
            }
        }
    }
}
