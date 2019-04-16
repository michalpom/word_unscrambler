using System;
using System.Collections.Generic;
using System.Linq;
using word_unscrambler.Data;
using word_unscrambler.Workers;

namespace word_unscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        private const string wordListFileName = "wordlist.txt";

        static void Main(string[] args)
        {
            bool continueWordUnscramble = true;
            do
            {
                Console.WriteLine("Please enter the option: F for File M for Manual");
                var oprion = Console.ReadLine() ?? string.Empty;

                switch (oprion.ToUpper())
                {
                    case "F":
                        Console.Write("Enter scrambled words file name: ");
                        ExecuteScrambledWorsInFileScenario();
                        break;
                    case "M":
                        Console.Write("Enter scrambled words manually: ");
                        ExecuteScrambledWorsInManualEntryScenario();
                        break;
                    default:
                        Console.Write("Option was not recognised.");
                        break;

                }
                var continueDecision = string.Empty;
                do
                {
                    Console.WriteLine("Do you want to continue? Y/N");
                    continueDecision = (Console.ReadLine() ?? string.Empty);

                } while (!continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase) && !continueDecision.Equals("N", StringComparison.OrdinalIgnoreCase));


                continueWordUnscramble = continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);

            } while (continueWordUnscramble);




        }

        private static void ExecuteScrambledWorsInManualEntryScenario()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambleWords = manualInput.Split(',');
            DisplayMatchedUnscrambledWords(scrambleWords);

        }

        private static void ExecuteScrambledWorsInFileScenario()
        {
            var fileName = Console.ReadLine() ?? string.Empty;
            string[] scrambleWords = _fileReader.Read(fileName);
            DisplayMatchedUnscrambledWords(scrambleWords);

        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambleWords)
        {
            string[] wordList = _fileReader.Read(wordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambleWords, wordList);

            if(matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine("Match found for {0}: {1}", matchedWord.ScrambledWord, matchedWord.Word);
                }
            }
            else
            {
                Console.WriteLine("No matches have been found");
            }

        }
    }
}
