using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Learning02 World!");
        Job job1= new job();
        job1._jobTitle = "Software Engineer";
        job1._company = "CodeLand";
        job1._startYear = 2020;
        job1._endYear = 2026;

        Job job2 = new Job();
        job2._jobTitle = "Assitant";
        job2._company = "Google";
        job2._startYear = 2022;
        job2._endYear = 2023;

        Resume myResume = new Resume();
        myResume._name = "TUYISHIME Eric";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();

    }
}