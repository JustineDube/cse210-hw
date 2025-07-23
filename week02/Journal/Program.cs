using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        int quit = 0;
        int choice;
        do
        {
            Console.WriteLine("Main Menu: ");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save entries to file");
            Console.WriteLine("4. Load entries from file");
            Console.WriteLine("5. Quit");
            choice = int.Parse(Console.ReadLine());

            if (choice < 0 || choice > 5)
            {
                Console.WriteLine("Invalid choise");
            }
            else if (choice == 1)
            {
                Entry entry = new Entry();
                entry.Display();
            }
            else if (choice == 2)
            {
                if (journal.Entries.Count == 0)
                {
                    Console.WriteLine("No entries to display.");
                }
                else
                {
                    journal.DisplayAll();
                }
            }
            else if (choice == 3)
            {
                Console.Write("Enter the filename to save entries:");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
                Console.WriteLine("Entries saved");
            }
            else if (choice == 4)
            {
                Console.Write("Enter the filename to load entries from:");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
                Console.WriteLine("Entries loaded");
            }
            else if (choice == 5)
            {
                quit = 5;
            }
        } while (quit != 5);
    }
}