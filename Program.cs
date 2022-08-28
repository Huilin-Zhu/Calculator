// See https://aka.ms/new-console-template for more information
using System;

namespace Calculator
{
   class Calculate
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            // Initiate a new variable. If the operation results in an error, we have the default result defined here.
            double result = double.NaN;
            switch(op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
    }


    class Program
    {
        // The Calculator program starts here.
        static void Main(string[] args)
        {
            bool endApp = false;
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                // Initiate variables that will be used later in this class. 
                //Of course we can also initiate them without initial value. But then, if the calculation goes wrong, we will have random error outputs.
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                Console.Write("Type a number, and then press Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                //double.TryParse will turn string numInput1 to a double and store the turned result in double cleanNum1, and return True.
                // If it cannot turn the string into a double, cleanNum1 will equal to 0, and return False.
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not valid input. Please enter an integer: ");
                    numInput1 = Console.ReadLine();
                }

                Console.Write("Type another number, and then press Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("This is not valid input. Please enter an integer: ");
                    numInput2 = Console.ReadLine();
                }

                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Your option? ");

                string op = Console.ReadLine();

                try
                {
                    result = Calculate.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result)) // Means we enter the default case in Calculate Class
                    {
                        Console.WriteLine("This operation will result in NaN.\n");
                    }
                    else Console.WriteLine("Your result {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no, an exception occurred.\nDetails: " + e.Message);
                }
                Console.WriteLine("-------------------------\n");

                Console.Write("Press 'n' and Enter to closs the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n")
                { endApp = true; }
                Console.WriteLine("\n");
            }
            return;
        }
    }
}