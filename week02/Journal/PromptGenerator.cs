using System;

class PromptGenerator
{
    private List<string> GetRandomPrompt = new List<string>();

    public void Prompt() {
        GetRandomPrompt.Add("Who was the most interesting person I interacted with today?");
        GetRandomPrompt.Add("What was the best part of my day?");
        GetRandomPrompt.Add("How did I see the hand of the Lord in my life today?");
        GetRandomPrompt.Add("What was the strongest emotion I felt today?");
        GetRandomPrompt.Add("If I had one thing I could do over today, what would it be?");
        GetRandomPrompt.Add("What was the most challenging part of my day?");
        GetRandomPrompt.Add("What did I learn today that I didn't know before?");
        GetRandomPrompt.Add("What is something I am grateful for today?");
        GetRandomPrompt.Add("What is a goal I want to achieve in the next week?");
        GetRandomPrompt.Add("What is something I wish I had done differently today?");
        GetRandomPrompt.Add("What is a positive affirmation I can tell myself?");
        GetRandomPrompt.Add("What is a lesson I learned from a mistake I made today?");
        GetRandomPrompt.Add("What is something that made me smile today?");
        GetRandomPrompt.Add("What is a personal strength I demonstrated today?");
        GetRandomPrompt.Add("What is something I am looking forward to tomorrow?");
        GetRandomPrompt.Add("What is a challenge I overcame today?");
        GetRandomPrompt.Add("What is a new habit I want to develop?");
        GetRandomPrompt.Add("What is a book or article I read today that inspired me?");
        GetRandomPrompt.Add("What is a skill I want to improve?");
        GetRandomPrompt.Add("What is a quote that resonated with me today?");
        GetRandomPrompt.Add("What is a way I can show kindness to someone tomorrow?");
        GetRandomPrompt.Add("What is a fear I faced today?");

        Random random = new Random();
        int index_of_prompt = random.Next(0, GetRandomPrompt.Count);
        string randomPrompt = GetRandomPrompt[index_of_prompt];
        Console.WriteLine(randomPrompt);
    }
}