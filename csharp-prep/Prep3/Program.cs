using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Prep3 World!");
       //Console.Write("guess the number");
        //string userInput = Console.ReadLine();
        //int number = int.Parse(userInput);

        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 25);


        int guess = 4;

        while (guess != number)
        {
        Console.Write("what is your guess?");
        guess = int.Parse(Console.ReadLine());

        if (number > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (number < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
        





    }
}