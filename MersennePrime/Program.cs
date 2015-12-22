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
			for (long q = 0; q <= number; q++) {
				if(isPrime(q)){
					Console.WriteLine ("{0} is E of Prime Numbers", q);
				}
			}

			Console.ReadLine ();
		}

		public static bool isPrime(long num) {
			int count = 0;
			bool isPrime = true;
			for(long i = 0; i<= num; i++){
				for(long j = 2; j <= i; j++){
					if(i%j == 0)
						count++;
				}
			}

			if (count > 2) {
				isPrime = false;	
			}

			return isPrime;
		}
	}
}
