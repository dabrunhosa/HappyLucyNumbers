using System;
using HappyAnalyser;

namespace MainProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberEntered;

            Console.WriteLine("Enter a number to check if it´s happy and/or luck:");
            numberEntered = Convert.ToInt32(Console.ReadLine());

            Happy.IsHappy(numberEntered);
        }
    }
}
