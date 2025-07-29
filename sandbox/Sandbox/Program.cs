using System;

class Program
{
    static void Main(string[] args)
    {
      Console.Write("What is the magic number: ");
      string input = Console.ReadLine();
      int MagicNumber = int.Parse(input);


      Console.Write("What is your guess: ");
      string userinput = Console.ReadLine();
      int guess = int.Parse(input);
      if(MagicNumber> guess)
      {
        Console.Write("Higher");
      }
      else{
        Console.Write("lower");
      }


    }
}