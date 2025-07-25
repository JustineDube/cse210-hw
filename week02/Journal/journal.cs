using System;
using System.IO;

class Journal
{
    public List<Entry> Entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {

        Entries.Add(newEntry);
    }
    public void DisplayAll()
    {
        foreach (Entry entry in Entries)
        {
            Console.WriteLine($"Date: {entry._date}");
            Console.WriteLine($"Prompt: {entry._prompt}");
            Console.WriteLine($"Entry: {entry._entryText}");
            Console.WriteLine("-----------------------------");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in Entries)
            {
                outputFile.WriteLine($"{entry._date}: {entry._prompt}: {entry._entryText}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split(":");

            string date = parts[0];
            string prompt = parts[1];
            string entry = parts[2];
        }
    }
}