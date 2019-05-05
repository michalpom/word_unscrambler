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


        static void Main(string[] args)
        {
            try
            {
                bool continueWordUnscramble = true;
                do
                {
                    Console.WriteLine(Constants.OptionsOnHowToEnterScrambledWords);
                    var oprion = Console.ReadLine() ?? string.Empty;

                    switch (oprion.ToUpper())
                    {
                        case Constants.File:
                            Console.Write(Constants.EnterScrambledWordsViaFile);
                            ExecuteScrambledWorsInFileScenario();
                            break;
                        case Constants.Manual:
                            Console.Write(Constants.EnterScrabledWordsManually);
                            ExecuteScrambledWorsInManualEntryScenario();
                            break;
                        default:
                            Console.Write(Constants.EnterScrambledWordsOptionNotRecognized);
                            break;

                    }
                    var continueDecision = string.Empty;
                    do
                    {
                        Console.WriteLine(Constants.OptionsOnContinuingTheProgram);
                        continueDecision = (Console.ReadLine() ?? string.Empty);

                    } while (!continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) && !continueDecision.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));


                    continueWordUnscramble = continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase);

                } while (continueWordUnscramble);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorProgramWillBeTerminated + ex.Message); ;
            }
        }

        private static void ExecuteScrambledWorsInManualEntryScenario()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambleWords = manualInput.Split(',');
            DisplayMatchedUnscrambledWords(scrambleWords);

        }

        private static void ExecuteScrambledWorsInFileScenario()
        {
            try
            {
                var fileName = Console.ReadLine() ?? string.Empty;
                string[] scrambleWords = _fileReader.Read(fileName);
                DisplayMatchedUnscrambledWords(scrambleWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorScrabledWordsCannotBeLoaded + ex.Message);
            }
        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambleWords)
        {
            string[] wordList = _fileReader.Read(Constants.WordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambleWords, wordList);

            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine(Constants.MatchFound, matchedWord.ScrambledWord, matchedWord.Word);
                }
            }
            else
            {
                Console.WriteLine(Constants.NoMatchFound);
            }

        }
    }
}
