using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3_recap
{
    class Program
    {
        static void Main(string[] args)
        {
            //Conditionals1();
            //Conditionals2();
            //Conditionals3();
            //Conditionals4();

            //Lists1();
            //Lists2();
            Lists3();

        }

        //## Conditionals

        /// <summary>
        /// Write a program and ask the user to enter a number. The number should be between 1 to 10. If the user enters
        /// a valid number, display "Valid" on the console. 
        /// Otherwise, display "Invalid". (This logic is used a lot in applications where values entered into input boxes need to be validated.)
        /// Otherwise, display "Invalid". (This logic is used a lot in 
        /// </summary>
        static void Conditionals1()
        {
            Console.WriteLine("Please enter your number: ");
            int number = int.Parse(Console.ReadLine());
            if (number >= 1 & number <= 10)
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }

        /// <summary>
        /// Write a program which takes two numbers from the console and displays the maximum of the two.
        /// </summary>
        static void Conditionals2()
        {
            Console.WriteLine("Please enter first number: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter second number: ");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("The maximum number is {0}", Math.Max(firstNumber, secondNumber));
        }

        /// <summary>
        /// Write a program and ask the user to enter the width and height of an image. Then tell if the image is landscape or portrait. 
        /// Use an enum for in which to group the landscape and portrait orientations.
        /// </summary>
        enum Orientations {Landscape, Portrait};
       
        static void Conditionals3()
        {
            Console.WriteLine("Please enter the width of your image: ");
            int width = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the height of your image: ");
            int height = int.Parse(Console.ReadLine());
            
            if (width < height)
            {
                Console.WriteLine(Orientations.Portrait);
            }
            else
            {
                Console.WriteLine(Orientations.Landscape);
            }  
        }

        /// <summary>
        /// Your job is to write a program for a speed camera. For simplicity, ignore the details such as camera, sensors, 
        /// etc and focus purely on the logic. Write a program that asks the user to enter the speed limit. Once set, 
        /// the program asks for the speed of a car. If the user enters a value less than the speed limit, program should 
        /// display Ok on the console. If the value is above the speed limit, the program should calculate the number of 
        /// penalty points. For every 5km/hr above the speed limit, 1 penalty point should be incurred and displayed on 
        /// the console. If the number of penalty points is above 12, the program should display License Suspended.
        /// </summary>
        static void Conditionals4()
        {
            Console.WriteLine("Please enter the speed limit: ");
            int speedLimit = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the car speed: ");
            int carSpeed = int.Parse(Console.ReadLine());
            var penaltyPoints = (carSpeed - speedLimit) / 5;
            if (carSpeed > speedLimit)
            {
                if (penaltyPoints > 12)
                {
                    Console.WriteLine("License Suspended");
                }
                else
                {
                    Console.WriteLine("Penalty points: {0}", penaltyPoints);
                }
            }
            else
            {
                Console.WriteLine("Ok");
            }
        }


        //## Lists
        ///<pattern>
        /// 1) John, Mary and 3 others like your post
        /// 2) John and Mary like your post
        /// 3) John likes your post
        /// </pattern>

        /// <summary>
        /// Write a program and continuously ask the user to enter different names, until the user presses Enter 
        /// (without supplying a name). Depending on the number of names provided, display a message based on the above pattern.
        /// </summary>
        static void Lists1()
        {
            var nameNumbers = 0;
            var friends = new List<string>();
            while (true)
            {
                Console.WriteLine("Please give a name");
                string name = Console.ReadLine();
                if (name == "")
                {
                    goto Cases;
                }
                nameNumbers++;
                friends.Add(name);
            }
            Cases:
            switch (nameNumbers)
            {
                case 0:
                    Console.WriteLine("Nobody likes your post");
                    break;
                case 1:
                    Console.WriteLine("{0} likes your post", friends[0]);
                    break;
                case 2:
                    Console.WriteLine("{0} and {1} likes your post", friends[0], friends[1]);
                    break;
                default:
                    Console.WriteLine(" {0}, {1} and {3} others like your post", friends[0], friends[1], nameNumbers-2);
                    break;
            }
        }

        /// <summary>
        /// Ask the user to enter their name. Use an array to reverse the name and then store the result in a new string. 
        /// Display the reversed name on the console.
        /// </summary>
        static void Lists2()
        {
            Console.WriteLine("Please give a name");
            string name = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            for (int i = name.Length - 1; i >= 0; i--)
            {
                sb.Append(name[i]);
            }
            string reversedName = sb.ToString();
            Console.WriteLine(reversedName);
        }

        /// <summary>
        /// Write a program and ask the user to enter 5 numbers. If a number has been previously entered, display 
        /// an error message and ask the user to re-try. Once the user successfully enters 5 unique numbers, sort them 
        /// and display the result on the console.
        /// </summary>
        static void Lists3()
        {
            var numbers = new List<int>();
            while (numbers.Count < 5)
            {
                Console.WriteLine("Enter a number:");
                int number = int.Parse(Console.ReadLine());
                if (numbers.Contains(number))
                {
                    Console.WriteLine("Please re-try with a different number");
                }
                else
                {
                    numbers.Add(number);
                }
            }
            numbers.Sort();
            foreach (var item in numbers)
            {
                Console.Write(item);
            }
        }
    }
}
