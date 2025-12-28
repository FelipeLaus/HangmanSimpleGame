namespace HangmanGame
{
    public class Hangman
    {
        private readonly string secretWord;
        private readonly char[] revealedLetters;
        private readonly HashSet<char> attemptedLetters;
        private int remainingAttempts;
        private const int MAXATTEMPTS = 6;

        public Hangman(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                throw new ArgumentException("Word cannot be null or empty.", nameof(word));

            secretWord = word.ToUpper();
            revealedLetters = new string('_', word.Length).ToCharArray();
            attemptedLetters = new HashSet<char>();
            remainingAttempts = MAXATTEMPTS;
        }

        public char[] GetLetters()
        {
            return revealedLetters;
        }

        public int GetRemainingAttempts()
        {
            return remainingAttempts;
        }

        public char[] TryLatter(char letter)
        {
            letter = char.ToUpper(letter);

            if (attemptedLetters.Contains(letter))
                throw new InvalidOperationException($"Letter '{letter}' has already been attempted.");
            attemptedLetters.Add(letter);

            if (secretWord.Contains(letter))
            {
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i] == letter)
                    {
                        revealedLetters[i] = letter;
                    }
                }
            }
            else
            {
                remainingAttempts--;
            }
            return revealedLetters;
        }

        public char[] TryWord(string word)
        {
            word = word.ToUpper();
            if (word == secretWord)
            {
                for (int i = 0; i < secretWord.Length; i++)
                {
                    revealedLetters[i] = secretWord[i];
                }
            }
            else
            {
                remainingAttempts = MAXATTEMPTS;
            }
            return revealedLetters;
        }
    }
}
