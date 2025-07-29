public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;
    public string _mood;

    public Entry(string prompt, string response, string mood)
    {
        _date = DateTime.Now.ToShortDateString();
        _prompt = prompt;
        _response = response;
        _mood = mood;
    }

    public string GetFormattedEntry()
    {
        return $"Date: {_date}\nMood: {_mood}\nPrompt: {_prompt}\nResponse: {_response}\n";
    }

    public string GetEntryForFile()
    {
        return $"{_date}|{_mood}|{_prompt}|{_response}";
    }

    public static Entry FromFileLine(string line)
    {
        string[] parts = line.Split('|');
        return new Entry(parts[2], parts[3], parts[1]) { _date = parts[0] };
    }
}
