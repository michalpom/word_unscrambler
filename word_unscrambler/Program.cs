using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace word_unscrambler
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueWordUnscramble = true;
            do
            {
                Console.WriteLine("Please enter the option: F for File M for Manual");
                var oprion = Console.ReadLine() ?? string.Empty;

                switch(oprion.ToUpper())
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
                var continueWordUnscrableDecision = string.Empty;
                do
                {
                    Console.WriteLine("Do you want to continue? Y/N");
                    continueWordUnscrableDecision = (Console.ReadLine() ?? string.Empty);

                } while (!continueWordUnscrableDecision.Equals("Y", StringComparison.OrdinalIgnoreCase) && !continueWordUnscrableDecision.Equals("N", StringComparison.OrdinalIgnoreCase));


                continueWordUnscramble = continueWordUnscrableDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);

            } while (continueWordUnscramble);




        }

        private static void ExecuteScrambledWorsInManualEntryScenario()
        {
            
        }

        private static void ExecuteScrambledWorsInFileScenario()
        {
            
        }
    }
}
