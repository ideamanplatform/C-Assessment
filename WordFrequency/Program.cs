using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordFrequency
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string line;
			int counter = 0;
			// define word dictionary to hold words and the number of times they occur
			// in a document
			Dictionary<string, int> WordDictionary = new Dictionary<string, int>();
			string[] words;
			string filepath = Console.ReadLine ();


			StreamReader file = new StreamReader (filepath.ToString());

			while ((line = file.ReadLine ()) != null) {
				// Read the file line by line, 
				// Extract words on each line and remove punctuation marks
				words = BreakLineIntoWords(line);
				for (int i = 0; i < words.Length; i++) {
					if (WordDictionary.ContainsKey (words [i])) {
						/*
						 * If the word is contained in the dictionary,
						 * Increment its value by one
						 */
						WordDictionary [words [i]] = WordDictionary [words [i]] + 1;

					} else {
						/*
						 * If the word is not in the dictionary,
						 * add it and attach a value to it
						 */
						if (String.IsNullOrWhiteSpace (words [i])) {
							continue;
						} else {
							WordDictionary.Add (words [i], 1);
						}
					}

				}
				counter++;
			}
			file.Close ();

			// Sort the dictionary using lambda expression
			var sortedWordDictionary = from entry in WordDictionary orderby entry.Value descending select entry;

			foreach (KeyValuePair<string, int> pair in sortedWordDictionary.Take(10))
			{
				Console.WriteLine("{0}: {1}",
					pair.Key,
					pair.Value);
			}

			Console.ReadLine ();
		}

		public static string[] BreakLineIntoWords(string line) {
			// extract email(s) and url(s) from line, store them as separate words, separate string
			// concatinate that string with the words string later

			Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
				RegexOptions.IgnoreCase);
			//find items that matches with our pattern
			MatchCollection emailMatches = emailRegex.Matches(line);

			StringBuilder stringbuilder = new StringBuilder();

			foreach (Match emailMatch in emailMatches)
			{
				stringbuilder.Append(emailMatch.Value + " ");
			}

			// replace extracted emails with empty string
			line = Regex.Replace(line, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", "");

			var WordsWithoutPunctuation = new StringBuilder();

			/*
			 * loop through every character in line
			 * and replace the puncuation charecters
			 */

			foreach (char c in line)
			{
				if (!char.IsPunctuation(c))
					WordsWithoutPunctuation.Append(c);
			}

			line = WordsWithoutPunctuation.ToString() + " " + stringbuilder.ToString();

			// Split the words using space char and return the array
			string[] newLine = line.Split(' ');
			return newLine;
		}
	}
}
