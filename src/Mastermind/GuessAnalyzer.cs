using System.Text;

namespace Mastermind
{
    public class GuessAnalyzer
    {
        private readonly string _code;

        public GuessAnalyzer(string code)
        {
            _code = code;
        }

        //  Display "-" for each digit that is correct but in wrong position
        public string Analyze(string guess)
        {
            var builder = new StringBuilder(guess.Length);

            for (var index = 0; index < guess.Length; index++)
            {
                var digit = guess[index];
                var response = ' ';

                if (_code.Contains(digit))
                    response = _code[index] == digit
                        ? '+'
                        : '-';

                builder.Append(response);
            }
            return builder.ToString();
        }
    }
}