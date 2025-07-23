using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        Job job2 = new Job();
        job1._company = "Microsoft";
        job1._jobtitle = "Software Engineer";
        job1._startyear = "2019";
        job1._endyear = "2022";
        job2._company = "Apple";
        job2._jobtitle = "Manager";
        job2._startyear = "2022";
        job2._endyear = "2023";
        //job1.Displayjob();
        //job2.Displayjob();
        Resume myresume = new Resume();
        myresume._name = "Justine Dube";
        myresume._jobs.Add(job1);
        myresume._jobs.Add(job2);
        myresume.Display();
    }
}