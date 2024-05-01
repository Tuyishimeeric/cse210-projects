using System;

class Program
{
    static void Main(string[] args)
    {
       Console.Write("what is your grade percantage?");
       string userInput = Console.ReadLine();
       int grade = int.Parse(userInput);

       string letter = "";

       if (grade >=90)
       {
       //Console.WriteLine("the grade is A");
        letter = "A";

       }

       else if (grade >= 80)
       {
       //Console.WriteLine("the grade is B");
        letter = "B";
       }

       else if (grade >= 70)
       {
       //Console.WriteLine("the grade is C");
        letter = "C";
       }

       else if (grade >= 60)
       {
       //Console.WriteLine("the grade is D");
        letter ="D";
       }

       else
       {

       //Console.WriteLine("The grade is F");
       letter ="F";
       }

       Console.WriteLine($"the grade is: {letter}");

       if (grade >= 70)
       {
        Console.WriteLine("You have passed!");
       }
      else
      {
        Console.WriteLine("Try again");
      }

    

    }
}