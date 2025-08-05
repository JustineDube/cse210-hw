using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    running = false;
                    continue;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to continue...");
                    Console.ReadLine();
                    continue;
            }

            activity.Run();
        }

        Console.WriteLine("Thank you for using the Mindfulness Program!");
    }
}

/*
Extra Feature:
- Each activity logs the date and type of activity completed to "activity_log.txt".
- Ensures prompts in Reflection and Listing activities are not repeated in a single session.
- Advanced breathing animation with progressive text.

*/
