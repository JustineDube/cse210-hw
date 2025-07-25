using System;

public class Job
{
    public string _jobtitle;
    public string _company;
    public string _startyear;
    public string _endyear;

    public void Displayjob()
    {
        Console.WriteLine($"\t{ _jobtitle} ({_company}) {_startyear}-{_endyear}");
    }
}