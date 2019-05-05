using System;
using System.Collections.Generic;
using System.Linq;

// Complexity of O(n^2) 

namespace PrimeFactorizationOfNumber
{
    internal class Program
    {
        private static List<long> _listOfMultiNum;

        private static bool CheckInput(long num)
        {
            if (num < 0)
            {
                throw new ArgumentException(string.Format("num: {0} is not a valid number", num));
            }

            if (num == 0)
            {
                Console.WriteLine("The number {0} has zero factors.", num);
                return true;
            }

            if (!CheckNumIfPrime(num)) return false;
            Console.WriteLine("the number {0} is a prime number. It hasn't any prime factors.", num);
            return true;
        }
        private static void PrintPrimeFactors(long num)
        {
            if (CheckInput(num)) return;

            var tempNum = num;
            var listOfPrimes = new List<long>();
            for (var i = 2; i <= (int)Math.Sqrt(tempNum); i++)
            {
                if (tempNum % i != 0) continue;
                listOfPrimes.Add(i);
                tempNum /= i;
                i = 1;
                if (!CheckNumIfPrime(tempNum)) continue;
                listOfPrimes.Add(tempNum);
                break;
            }

            var counter = 1;
            _listOfMultiNum = new List<long>();
            for (int i = 0; i < listOfPrimes.Count - 1; i++)
            {
                if (listOfPrimes[i] == listOfPrimes[i + 1])
                {
                    counter++;
                }
                else
                {
                    _listOfMultiNum.Add(counter);
                    counter = 1;
                }
            }

            _listOfMultiNum.Add(counter);

            listOfPrimes = listOfPrimes.Distinct().ToList();
            Print(listOfPrimes);
        }

        private static void Print(List<long> listOfPrimes)
        {
            Console.WriteLine("The prime factors are: ");
            foreach (var prime in listOfPrimes)
            {
                Console.Write(prime + " ");
            }

            Console.WriteLine("\nThe numbers will be multiplied as follows: ");

            for (int i = 0, j = 0; i <= _listOfMultiNum.Count - 1; i++)
            {
                Console.WriteLine("{0} :number gets multiplied: {1} times.", listOfPrimes[j++], _listOfMultiNum[i]);
            }

        }

        private static bool CheckNumIfPrime(long numToBeChecked)
        {
            var prime = true;
            var maxDivisor = (int)Math.Sqrt(numToBeChecked);
            var divisor = 2;

            while (divisor <= maxDivisor)
            {
                if (numToBeChecked % divisor == 0)
                {
                    prime = false;
                    break;
                }

                divisor++;
            }

            return prime;
        }

        private static void Main()
        {
            var startTime = DateTime.Now;
            // Works like a charm for big enough numbers, the algorithm is efficient ENOUGH. Has running time of O(n^2)
            //1000000000000
            //1000000000000000
            PrintPrimeFactors(30);
            Console.WriteLine((DateTime.Now.Millisecond - (decimal)startTime.Millisecond) / (decimal)1000.0 + " sec.");
            // Or
            Console.WriteLine(DateTime.Now.Millisecond - (decimal)startTime.Millisecond + " MiliSeconds."); 
        }
    }
}
