using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            //Lists3();
            //Lists4();
            //List5();

            //Loops1();
            //Loops2();
            //Loops3();
            //Loops4();
            //Loops5();

            //Strings1();
            //Strings2();
            //Strings3();
            //Strings4();
            Strings5();



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
        enum Orientations { Landscape, Portrait };

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
                    Console.WriteLine(" {0}, {1} and {3} others like your post", friends[0], friends[1], nameNumbers - 2);
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

        /// <summary>
        /// Write a program and ask the user to continuously enter a number or type "Quit" to exit. The list of numbers may 
        /// include duplicates. Display the unique numbers that the user has entered.
        /// </summary>
        static void Lists4()
        {
            var numbers = new List<int>();
            while (true)
            {
                Console.WriteLine("Enter a number or type Quit to exit:");
                int number;
                bool result = int.TryParse(Console.ReadLine(), out number);
                if (result)
                {
                    numbers.Add(number);
                }
                else break;
            }
            foreach (var item in numbers.Distinct())
            {
                Console.Write(item);
            }
        }

        /// <summary>
        /// Write a program and ask the user to supply a list of comma separated numbers (e.g 5, 1, 9, 2, 10). If the list is 
        /// empty or includes less than 5 numbers, display "Invalid List" and ask the user to re-try; otherwise, display 
        /// the 3 smallest numbers in the list.
        /// </summary>
        static void List5()
        {
            Console.WriteLine("Enter a list of numbers separated by commas: ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                Console.WriteLine("The list cannot be empty or null. Please retry");
            else
            {
                var numbers = input.Split((',')).Select(s => Convert.ToInt32(s.Trim())).ToList();
                numbers.Sort();
                if (numbers.Count < 5)
                    Console.WriteLine("Invalid list, has less than 5 numbers. Please retry.");
                else
                {
                    var smallestThreeNumbers = new List<int>();
                    for (var i = 0; i < 3; i++)
                        smallestThreeNumbers.Add(numbers[i]);

                    smallestThreeNumbers.ForEach(Console.WriteLine);
                }
            }
        }


        //## Loops
        /// <summary>
        /// Write a program to count how many numbers between 1 and 100 are divisible by 3 with no remainder. 
        /// Display the result on the console.
        /// </summary>
        static void Loops1()
        {
            var count = 0;
            for (var i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                    count++;
            }
            Console.WriteLine("There are {0} numbers divisible by 3 between 1 and 100.", count);
        }

        /// <summary>
        /// Write a program and continuously ask the user to enter a number. The loop terminates when the user 
        /// enters “ok". Calculate the sum of all the previously entered numbers and display it on the console.
        /// </summary>
        static void Loops2()
        {
            var numbers = new List<int>();
            while (true)
            {
                Console.WriteLine("Enter a number or type ok to finish:");
                int number;
                bool result = int.TryParse(Console.ReadLine(), out number);
                if (result)
                {
                    numbers.Add(number);
                }
                else break;
            }
            Console.Write(numbers.Sum());

        }

        /// <summary>
        /// Write a program which takes a single number from the user,
        /// calculates the factorial and prints the value on the console.
        /// For example, if the user enters 5, the program should calculate 5 x 4 x 3 x 2 x 1 
        /// and display it as 5! = 120(result of 5 x 4 x 3 x 2 x 1).
        /// </summary>
        static void Loops3()
        {
            Console.WriteLine("Please enter a number: ");
            int input = int.Parse(Console.ReadLine());
            var factorial = 1;
            for (int i = 1; i <= input; i++)
            {
                factorial *= i;
            }
            Console.WriteLine("{0}! = {1}", input, factorial);
        }

        /// <summary>
        /// Write a program that picks a random number between 1 and 10. Give the user 4 chances to guess the number. 
        /// If the user guesses the number, display “You won". Otherwise, display “You lost".
        /// </summary>
        static void Loops4()
        {
            int number = new Random().Next(1, 10);
            var count = 0;
            while (count < 4)
            {
                Console.WriteLine("Please guess a number between 1 and 10");
                int input = int.Parse(Console.ReadLine());
                if (number == input)
                {
                    Console.WriteLine("You won");
                    break;
                }
                else
                {
                    Console.WriteLine("You lost");
                    count++;
                }
            }
            Console.WriteLine("The correct number is {0}", number);
        }

        /// <summary>
        /// Write a program and ask the user to enter a series of numbers separated by comma. Find the maximum of the 
        /// numbers and display it on the result. For example, if the user enters “5, 3, 8, 1, 4", the program should 
        /// display 8 on the console.
        /// </summary>
        static void Loops5()
        {
            Console.WriteLine("Enter a list of numbers separated by commas: ");
            var input = Console.ReadLine();
            var numbers = input.Split((',')).Select(s => Convert.ToInt32(s.Trim())).ToList();
            Console.WriteLine(numbers.Max());
        }


        /// ## Strings
        /// <summary>
        /// Write a program and ask the user to enter a few numbers separated by a hyphen(minus). Work out 
        /// if the numbers are consecutive. For example, if the input is "5-6-7-8-9" or "20-19-18-17-16", 
        /// display a message: "Consecutive"; otherwise, display "Not Consecutive".
        /// </summary>
        static void Strings1()
        {
            Console.WriteLine("Enter a list of numbers separated by hyphen: ");
            var input = Console.ReadLine();
            var numbers = input.Split(('-'));
            int firstValue = Convert.ToInt32(numbers[0]);
            bool consecutive = true;
            
            for (int i = 0; i < numbers.Length; i++)
            {
                if (Convert.ToInt32(numbers[i])-i != firstValue && Convert.ToInt32(numbers[i]) + i != firstValue)
                {
                    consecutive = false;
                    break;
                }
            }
            if (consecutive)
            {
                Console.WriteLine("Consecutive");
            }
            else
            {
                Console.WriteLine("Not Consecutive");
            }
        }

        /// <summary>
        /// Write a program and ask the user to enter a few numbers separated by a hyphen(minus). If the user simply 
        /// presses Enter without supplying an input, exit immediately; otherwise, check to see if there are 
        /// any duplicates. If so, display "Duplicate" on the console.
        /// </summary>
        static void Strings2()
        {
            Console.WriteLine("Enter a list of numbers separated by hyphen: "); 
            var numberList = Console.ReadLine().Split(('-')).ToList();
            bool duplicate = numberList.GroupBy(n => n).Any(c => c.Count() > 1);

            if (duplicate)
            {
                Console.WriteLine("Duplicate");
            }
        }

        /// <summary>
        /// Write a program and ask the user to enter a time value in the 24-hour time format (e.g. 19:00).
        /// A valid time should be between 00:00 and 23:59. If the time is valid, display "Ok"; otherwise, 
        /// display "Invalid Time". If the user doesn't provide any values, consider it as invalid time. 
        /// </summary>
        static void Strings3()
        {
            Console.WriteLine("Please enter a time value in the 24-hour time format (e.g. 19:00): ");
            var input = Console.ReadLine();
            bool isDateTime = false;

            if (string.IsNullOrEmpty(input))
            {
                isDateTime = false;
            }

            isDateTime = DateTime.TryParse(input, out DateTime dateTime);

            if (isDateTime)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("Invalid Time");
            }
        }

        /// <summary>
        /// Write a program and ask the user to enter a few words separated by a space. Use the words to 
        /// create a variable name with PascalCase convention. For example, if the user types: 
        /// "number of students", display "NumberOfStudents". Make sure the program is not dependent on 
        /// the casing of the input. So if the input is "NUMBER OF STUDENTS", it should still display 
        /// "NumberOfStudents". If the user doesn't supply any words, display "Error".
        /// </summary
        static void Strings4()
        {
            Console.WriteLine("Please enter a few words separated by space: ");
            var input = Console.ReadLine();
            var myString = input.ToLower();
            TextInfo info = CultureInfo.CurrentCulture.TextInfo;
            myString = info.ToTitleCase(myString).Replace(" ", string.Empty);
            if (input == string.Empty)
            {
                Console.WriteLine("Error");
            }
            else
            {
                Console.WriteLine(myString);
            }  
        }


        /// <summary>
        /// Write a program and ask the user to enter an English word. Count the number of vowels 
        /// (a, e, o, u, i) in the word. So, if the user enters "inadequate", the program should display 
        /// 6 on the console. Make sure the program calculates the number of vowels irrespective of the 
        /// casing of the word (eg "Inadequate", "inadequate" and "INADEQUATE" all include 6 vowels).
        /// </summary>
        static void Strings5()
        {
            Console.WriteLine("Please enter an English word: ");
            var input = Console.ReadLine().ToLower();
            var vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };
            int vowelsNumber = input.Count(n =>vowels.Contains(n));
            Console.WriteLine("Your total number of vowels is: {0}", vowelsNumber);
        }
    }
}
