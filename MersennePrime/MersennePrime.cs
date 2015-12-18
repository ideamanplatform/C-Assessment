using System;

namespace MersennePrime
{
	class MersennePrime
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Enter a digit n: ");
			long n = long.Parse (Console.ReadLine ());
			// Check if there are any prime numbers in n

			if (isPrime (n)) {
				/*
					 * check if the number is a Mersenne Prime using
					 * Mp = (2^p) - 1, where p is the prime number
					*/
				if (isMersennePrime (n)) {
					Console.WriteLine (n);
				}
			}
		}

		public static bool isPrime (long p)
		{
			
			bool isPrime = true; 
			for (int i = 0; i <= p; i++) {
				for (long e = 2; e < i; e++) {
					if (i % e == 0) {
						isPrime = false;
						break;
					}
				}
			}

			return isPrime;
		}

		public static bool isMersennePrime (long m)
		{
			bool isMersennePrime = false;
			if (isPrime ((2 ^ m) - 1)) {
				isMersennePrime = true;
			}
			return isMersennePrime;
		}
	}
}
