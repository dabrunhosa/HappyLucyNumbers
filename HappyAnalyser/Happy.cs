using System;
using System.Collections.Generic;
using System.Linq;

namespace HappyAnalyser
{
    public class Happy
    {
        private static readonly int maxIterations;
        static Happy() => maxIterations = 100;

        /// <summary>
        /// Um número é considerado feliz, se em algum ponto a soma de seus dígitos ao quadrado equivale a 1.

        //        Ex: 7 é um número feliz? 
        //7² = 49 
        //4² + 9² = 97 
        //9² + 7² = 130 
        //1² + 3² + 0² = 10 
        //1² + 0² = 1 

        //Logo, 7 é um número feliz.No seu programa você deve considerar um máximo de 100 iterações.

        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        /// 
        public static bool IsHappy(int number)
        {
            bool happyIdentified = false;
            List<char> strNumber = new List<char>();
            double numberBeingChecked = number;
            for (int i = 0; i < maxIterations; i++)
            {
                if (numberBeingChecked == 1)
                {
                    happyIdentified = true;
                    break;
                }

                strNumber = numberBeingChecked.ToString().ToList();
                if (strNumber.Count > 1)
                {
                    numberBeingChecked = 0;
                    strNumber.ForEach(delegate (char digit)
                    {
                        numberBeingChecked += Math.Pow(Convert.ToDouble(digit.ToString()), 2);
                    });
                }
                else
                    numberBeingChecked = Math.Pow(numberBeingChecked, 2);
            }

            return happyIdentified;
        }
    }
}
