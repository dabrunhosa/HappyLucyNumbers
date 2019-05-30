using System;
using System.Collections.Generic;
using HappyAnalyser;
using LuckyAnalyser;

namespace MainProject
{
    class Program
    {
        //        Casos de Teste
        //1) 7 – Número Sortudo e Feliz.
        //2) 21 – Número Sortudo e Não-Feliz.
        //3) 28 – Número Não-Sortudo e Feliz.
        //4) 142 – Número Não-Sortudo e Não-Feliz
        //5) 37 – Número Sortudo e Não-Feliz
        //6) 100 – Número Não-Sortudo e Feliz.

        private static void runTestCases()
        {
            List<int> testCases = new List<int>(new int[] { 7, 21, 28, 142, 37, 100 });

            testCases.ForEach(delegate (int testCase)
            {
                printMessage(evaluateNumber(testCase),testCase);
            });
        }
        private static Tuple<bool, bool> evaluateNumber(int number) => new Tuple<bool, bool>(Lucky.IsLucky(number), Happy.IsHappy(number));

        private static void printMessage(Tuple<bool,bool> result, int number)
        {
            string messageResult = number.ToString() + " - ";

            messageResult += result.Item1 ? "Lucky" : "Non Lucky ";
            messageResult += " and " + (result.Item2 ? "Happy" : "Non Happy") + " Number.";

            Console.WriteLine(messageResult);
        }

        static void Main(string[] args)
        {
            runTestCases();
            int numberEntered;

            Console.WriteLine("Enter a number to check if it´s happy and/or luck:");
            numberEntered = Convert.ToInt32(Console.ReadLine());

            evaluateNumber(numberEntered);
        }
    }
}
