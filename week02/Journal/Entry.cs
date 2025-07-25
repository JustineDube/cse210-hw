using System;

class Entry
{
    public string _date;
    public string _prompt;
    public string _entryText;

    public void Display()
    {
        PromptGenerator prompt = new PromptGenerator();
        _date = DateTime.Now.ToString("MM/dd/yyyy");
        Console.WriteLine("Enter something");
        Console.Write(">>");
        _entryText = Console.ReadLine();
        _date = DateTime.Now.ToString("MM/dd/yyyy");
    }
}