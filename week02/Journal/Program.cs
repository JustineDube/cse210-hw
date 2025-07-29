using System;
using System.Collections.Generic;

// EXCEEDS CORE REQUIREMENTS:
// I added a mood selector to each journal entry (e.g., Happy, Sad, Grateful).
// The mood is saved and displayed along with each entry.

class Program
{
    static List<string> prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    static List<string> moods = new List<string>()
    {
        "Happy", "Sad", "Grateful", "Stressed", "Excited"
    };

    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteEntry(journal);
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }

    static void WriteEntry(Journal journal)
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        string mood = ChooseMood();

        Entry newEntry = new Entry(prompt, response, mood);
        journal.AddEntry(newEntry);
    }

    static string GetRandomPrompt()
    {
        Random rand = new Random();
        return prompts[rand.Next(prompts.Count)];
    }

    static string ChooseMood()
    {
        Console.WriteLine("Select your mood:");
        for (int i = 0; i < moods.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {moods[i]}");
        }

        int moodIndex;
        while (true)
        {
            Console.Write("Enter number (1–5): ");
            if (int.TryParse(Console.ReadLine(), out moodIndex) && moodIndex >= 1 && moodIndex <= moods.Count)
            {
                return moods[moodIndex - 1];
            }
            Console.WriteLine("Invalid selection. Please try again.");
        }
    }
}
