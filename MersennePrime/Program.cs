using System;

namespace MersennePrime
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.Write ("Enter a number : ");
			string StrNumber = Console.ReadLine ();
			long number = long.Parse (StrNumber);
			for (long q = 1; q <= number; q++) {
				if(isPrime(q)){
					
					if(isMersennePrime(q))
						Console.WriteLine ("{0} is a Mersenne Prime Number", q);
				}
			}

			Console.ReadLine ();
		}

		public static bool isPrime(long num) {
			if (num < 2) return false;
			if (num % 2 == 0) return (num == 2);
			long root = (long)Math.Sqrt((double)num);
			for (int i = 3; i <= root; i += 2)
			{
				if (num % i == 0) return false;
			}
			return true;
		}

		public static bool isMersennePrime(long num)
		{
			bool isMersennePrime = false;
			long mersenneNum = ((long)Math.Pow (2, num)) - 1;
			if (isPrime (mersenneNum))
				isMersennePrime = true;

			return isMersennePrime;
		}
	}
}
