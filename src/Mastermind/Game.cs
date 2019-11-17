using System;
using System.Text;

namespace Mastermind
{
    public class Game
    {
        private static Random _randomizer = new Random();
        private GuessAnalyzer _analyzer;

        public Game()
        {
            var builder = new StringBuilder(4);
            for (var index = 0; index < 4; index++)
                builder.Append(_randomizer.Next(1, 6));
            Code = builder.ToString();
            _analyzer = new GuessAnalyzer(Code);
        }

        public Game(string code)
        {
            Code = code;
        }

        public string Code { get; }

        public string Guess(string guess)
        {
            return _analyzer.Analyze(guess);
        }
    }
}