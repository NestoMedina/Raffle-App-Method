using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Party!!");
            GetUserInfo();
            MultiLineAnimation();
            PrintGuestsName();
            PrintWinner();
            Console.ReadLine();

        }
        //variables
        private static Dictionary<int, string> guests = new Dictionary<int, string>();
        private static int min = 1000;
        private static int max = 9999;
        private static Random rdm = new Random();

        //Create Methods for assignment

        //1 Method GetUserInput()
        static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string answer = Console.ReadLine();
            return answer;
        }
        //2nd Method GetUserInfo()
        static void GetUserInfo()
        {
            string userName = GetUserInput("Please enter your name");
            int userNum = GenerateRandomNumber(min, max);
            guests.Add(userNum, userName);

            int num;
            string guestNames = GetUserInput("Do you want add another name? 'yes' or 'no'");

            while (guestNames == "" || guestNames == null)
            {
                guestNames = GetUserInput("Cannot enter empty value, please enter 'yes' or 'no'");     
            }
            while (guestNames.ToLower() == "yes")
            {
                string anotherName = GetUserInput("Please enter another name");
                while (anotherName == "")
                {
                    anotherName = GetUserInput("Cannot enter empty value, please enter a name");
                }
                num = GenerateRandomNumber(min, max);
                while (guests.ContainsKey(num) == true)
                {
                    num = GenerateRandomNumber(min, max);
                }
                guests.Add(num, anotherName);
                guestNames = GetUserInput("Do you want add another name? 'yes' or 'no'");
                if (guestNames == "" || guestNames == null)
                {
                    while (guestNames == "" || guestNames == null)
                    {
                        guestNames = GetUserInput("Cannot enter empty value, please enter 'yes' or 'no'");
                    }
                }
            }

        }
        //3rd GenerateRandomNumber()
        static int GenerateRandomNumber(int min, int max)
        {
            return rdm.Next(min, max);
        }
        //5th Print GuestsName()
        static void PrintGuestsName()
        {
            foreach(KeyValuePair<int, string> kvp in guests)
            {
                Console.WriteLine($"{kvp.Value} =======> {kvp.Key}");
            }
        }
        //6th GetRaffleNumber()
        static int GetRaffleNumber(Dictionary<int, string> people)
        {
            List<int> newList = people.Keys.ToList();
            int random = rdm.Next(newList.Count);
            int chosen = newList[random];
            return chosen;
        }
        //7th PrintWinner()
        static void PrintWinner()
        {
            int winner = GetRaffleNumber(guests);
            Console.WriteLine($"The winner is {guests[winner]} and the winning number is {winner}");
        }

        static void MultiLineAnimation() // Credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();

                switch (counter % 4)
                {
                    case 0:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    │││ \\   ║");
                            Console.WriteLine("         ║    │││  O  ║");
                            Console.WriteLine("         ║    OOO     ║");
                            break;
                        };
                    case 1:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                    case 2:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║   / │││    ║");
                            Console.WriteLine("         ║  O  │││    ║");
                            Console.WriteLine("         ║     OOO    ║");
                            break;
                        };
                    case 3:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                }

                counter++;
                Thread.Sleep(200);
            }
        }
    }
}
