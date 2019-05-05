namespace word_unscrambler
{
    class Constants
    {
        public const string OptionsOnHowToEnterScrambledWords = "Enter scrambled word(s) manually or as a file: F - file/M - manual";
        public const string OptionsOnContinuingTheProgram = "Would you like to contiunue? Y/N";

        public const string EnterScrambledWordsViaFile = "Enter full path including the file name: ";
        public const string EnterScrabledWordsManually = "Enter word(s) manually, seperated by commas if multiple: ";

        public const string EnterScrambledWordsOptionNotRecognized = "The option was not recognized.";
        public const string ErrorScrabledWordsCannotBeLoaded = "Scrabled words were not loaded, error occured";
        public const string ErrorProgramWillBeTerminated = "The program will be terminated";

        public const string MatchFound = "Match found for {0}: {1}";
        public const string NoMatchFound = "No matches found";

        public const string Yes = "Y";
        public const string No = "N";

        public const string File = "F";
        public const string Manual = "M";

        public const string WordListFileName = "wordlist.txt";

    }
}
