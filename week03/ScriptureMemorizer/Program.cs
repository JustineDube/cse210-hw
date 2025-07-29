using System;
using System.Threading;

// EXCEEDS REQUIREMENTS:
// Hides only words that haven't been hidden yet (stretch feature).
// Modular, extensible design for future enhancements like loading multiple scriptures from files.

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        // Example scripture: Proverbs 3:5-6
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding.";
        Scripture scripture = new Scripture(reference, text);

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
                break;

            scripture.HideRandomWords(3); // Hide 3 words per step
        }

        // Final display
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are now hidden. Good job!");
    }
}
