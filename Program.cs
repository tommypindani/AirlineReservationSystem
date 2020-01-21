using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch8_19_AirlineReservationSystemYT
{
    class Program
    {
        public static bool[] seats;
        public static int totalAssignedFirstClass;
        public static int totalAssignedSecondClass;

        static void Main(string[] args)
        {
            seats = new bool[11];
            int selectedClass = 0;

            for (int i = 0; i <= 10; i++)
                seats[i] = false;

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Please type 1 for First Class or 2 for Economy Class");
                selectedClass = Convert.ToInt32(Console.ReadLine());

                while (selectedClass < 1 || selectedClass > 2)
                {
                    Console.WriteLine("Please only enter 1 or 2 for First or Economy Class");
                    selectedClass = Convert.ToInt32(Console.ReadLine());
                }

                if (selectedClass == 1)
                {
                    if (totalAssignedFirstClass == 5 && totalAssignedSecondClass < 5)
                    {
                        Console.WriteLine("Sorry, first class is full. Do you want to get a ticket for economy class? Y-N");
                        if (Console.ReadLine().Equals("N"))
                        {
                            Console.WriteLine("Next plane leaves in 3 hours");
                            i--;
                        }
                        else
                        {
                            assignSecondClass();
                        }
                    }
                    else if (totalAssignedFirstClass < 5)
                    {
                        assignFirstClass();
                    }
                }
                else
                {
                    if (totalAssignedSecondClass == 5 && totalAssignedFirstClass < 5)
                    {
                        Console.WriteLine("Sorry, economy class is full. Do you want to get a ticket for first class? Y-N");
                        if (Console.ReadLine().Equals("N"))
                        {
                            Console.WriteLine("Next plane leaves in 3 hours");
                            i--;
                        }
                        else
                        {
                            assignFirstClass();
                        }
                    }
                    else
                    {
                        assignSecondClass();
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Sorry, The plane is full. Next one leaves in 3 hours.");
            Console.ReadLine();
        }

        public static void assignFirstClass()
        {
            bool noDuplicate = false;
            Random rand = new Random();
            int index = 0;

            //keep generating the seat number until a FREE seat is assigned
            while (!noDuplicate)
            {
                noDuplicate = true;
                index = rand.Next(1, 6);
                if (seats[index] == true)
                    noDuplicate = false;
            }
            seats[index] = true;
            totalAssignedFirstClass++;
            Console.WriteLine("Assigned seat {0:N0}", index);
        }

        public static void assignSecondClass()
        {
            bool noDuplicate = false;
            Random rand = new Random();
            int index = 0;

            //keep generating the seat number until a FREE seat is assigned
            while (!noDuplicate)
            {
                noDuplicate = true;
                index = rand.Next(6, 11);
                if (seats[index] == true)
                    noDuplicate = false;
            }
            seats[index] = true;
            totalAssignedSecondClass++;
            Console.WriteLine("Assigned seat {0:N0}", index);
        }

    }
}

