using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _random = new Random();
        _words = new List<Word>();

        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide = 3)
    {
        int hiddenCount = 0;

        List<Word> availableWords = _words.FindAll(w => !w.IsHidden());

        while (hiddenCount < numberToHide && availableWords.Count > 0)
        {
            int index = _random.Next(availableWords.Count);
            availableWords[index].Hide();
            availableWords.RemoveAt(index);
            hiddenCount++;
        }
    }

    public string GetDisplayText()
    {
        string wordsText = string.Join(" ", _words.ConvertAll(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()} {wordsText}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.TrueForAll(w => w.IsHidden());
    }
}