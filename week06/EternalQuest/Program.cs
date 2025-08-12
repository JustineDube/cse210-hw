// Eternal Quest Program
// Implements full OOP principles: abstraction, encapsulation, inheritance, and polymorphism.
// Includes all required goal types with correct behaviors and saving/loading functionality.
// Exceeds requirements with a leveling system that rewards users as they accumulate points,
// enhancing engagement through gamification.



using System;

namespace EternalQuest
{
    class Program
    {
        static void Main()
        {
            GoalManager goalManager = new GoalManager();

            Console.WriteLine("Welcome to Eternal Quest - Track your goals and level up!");

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Display Score and Level");
                Console.WriteLine("5. Save Goals");
                Console.WriteLine("6. Load Goals");
                Console.WriteLine("7. Quit");
                Console.Write("Select an option: ");

                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        goalManager.CreateGoal();
                        break;

                    case "2":
                        goalManager.DisplayGoals();
                        break;

                    case "3":
                        goalManager.RecordEvent();
                        break;

                    case "4":
                        goalManager.DisplayScore();
                        break;

                    case "5":
                        goalManager.SaveGoals();
                        break;

                    case "6":
                        goalManager.LoadGoals();
                        break;

                    case "7":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid selection, try again.");
                        break;
                }
            }

            Console.WriteLine("Thank you for playing Eternal Quest! Keep conquering your goals!");
        }
    }
}