﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LuckyAnalyser
{
    public static class IEnumerableExtension
    {
        public static T Pop<T>(this List<T> source)
        {
            T poppedT = source.First();
            source.Remove(poppedT);

            return poppedT;
        }

        //public static List<T> PopWhereIsFalse<T>(this List<T> source, Func<T,bool> predicate)
        //{
        //    var poppedList = source.Where(predicate)
        //    T poppedT = source.First();
        //    source.Rem

        //    return poppedT;
        //}
    }
    public class Lucky
    {
        static Lucky() { }

        /// <summary>
        /// *** Números Sortudos ***

        // Nós começamos com uma lista de inteiros começando em 1: 

        //1, 2, 3, 4, 5, 6, 7, 8, 9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25

        //Então removemos todos os números com posição múltipla de 2 (todos números pares), deixando todos os inteiros ímpares: 

        //1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25

        //O segundo termo desta sequência é 3. 
        //Nós removemos então todos os números com posição múltipla de 3 que sobraram na lista: 

        //1, 3, 7, 9, 13, 15, 19, 21, 25

        //O terceiro termo desta sequência é 7. 
        //Nós removemos então todos os números com posição múltipla de 7 que sobraram na lista: 1, 3, 7, 9, 13, 15, 21, 25

        //Se nós repetirmos este procedimento indefinidamente, os sobreviventes são os números sortudos:

        //1, 3, 7, 9, 13, 15, 21, 25, 31, 33, 37, 43, 49, 51, 63, 67, 69, 73, 75, 79, 87, 93, 99

        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        /// 
        private static List<int> removeNonLucky(List<int> luckyNumbers, List<int> allNumbers, int currentNumber)
        {
            luckyNumbers.Add(allNumbers.Pop());
            allNumbers.RemoveAll(divNumber => (divNumber % currentNumber) == 0);

            return luckyNumbers;
        }

        private static List<int> GenrateLuckyNumbersUpTo(int number)
        {
            List<int> allNumbers = Enumerable.Range(1, number).ToList();
            List<int> luckyNumbers = new List<int>();
            luckyNumbers.Add(allNumbers.Pop()); 
            int currentNumber = allNumbers.Pop();

            while (allNumbers.Count != 0)
            {
                luckyNumbers = removeNonLucky(luckyNumbers, allNumbers, currentNumber);
            }

            return luckyNumbers;
        }

        public static bool IsLucky(int number)
        {
            List<int> luckyNumbers = GenrateLuckyNumbersUpTo(number);
            return luckyNumbers.Exists(lucky => lucky == number);
        }
    }
}
