using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSemiPrimes
{
    class Solution
    {
        static void Main(string[] args)
        {
            int[] P = { 1, 4, 16 };
            int[] Q = { 26, 10, 20 };
            int N = 26;
            Console.WriteLine(solution(N, P, Q));
        }
        //create a method to get primes

        public static bool getPrimes(int num)
        {
            if (num <= 1) return false;
            if (num <= 3) return true;
            //generate all primes to N(Sieve of Eratosthene)
            for (int i = 2, squarert = (int)Math.Sqrt(num) ; i <= squarert; i++)
                if (num % i == 0) return false;
            return true;
        }
        //create a list method to add the primes
        public static List<int> allPrimes(int numbers)
        {
            List<int> primenos = new List<int>();
            for (int i = 0; i < numbers; i++)
            {
                if (getPrimes(i)) primenos.Add(i);
            }
          
            return primenos;
        }
        //create a method to compute the semiprimes
        public static bool[] getSemiPrimes(int N)
        {
            List<int> primenos = allPrimes(N);
            bool[] semiprimes = new bool[N + 1];
            for (int i = 0; i < primenos.Count; i++)
            {
                if (primenos.ElementAt(i) > N) break;
                for (int j = i; j < primenos.Count; j++)
                {
                    if (primenos.ElementAt(j) > N) break;
                    //find the semiprimes by multiplying i and j
                    int values = primenos.ElementAt(i) * primenos.ElementAt(j);
                    if (values <= N)
                        semiprimes[values] = true;
                }
            }
            return semiprimes;
        }

        public static string solution(int N, int[] P, int[] Q)
        {
            bool[] semiPrimes = getSemiPrimes(N);
            int[] res = new int[P.Length];
            for (int i = 0; i < res.Length; i++)
            {
                for (int j = P[i]; j <= Q[i]; j++)
                {
                    if (semiPrimes[j]) res[i]++;
                }
            }
            var result = String.Join(",", res);
            return result;
        }
       
    }
}
