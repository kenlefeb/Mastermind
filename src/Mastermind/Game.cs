using System;
using System.Collections.Generic;
using System.Text;

namespace Mastermind
{
    public class Game
    {
        private static Random _randomizer = new Random();
        private GuessAnalyzer _analyzer;
        private List<Turn> _turns = new List<Turn>();

        public Game() : this(GenerateCode()) { }

        public Game(string code)
        {
            Code = code;
            _analyzer = new GuessAnalyzer(Code);
        }

        private static string GenerateCode(int length = 4)
        {
            var builder = new StringBuilder(length);
            for (var index = 0; index < length; index++)
                builder.Append(_randomizer.Next(1, 6));
            return builder.ToString();
        }

        public string Code { get; set; }

        public string Guess(string guess)
        {
            var turn = new Turn
            {
                Number = _turns.Count + 1,
                Guess = guess,
                Response = _analyzer.Analyze(guess)
            };
            _turns.Add(turn);

            if (turn.Response == "++++")
                return $"Congratulations, you won!\n(in only {turn.Number} turns)";

            if (turn.Number > 9)
                return "Sorry, you lose.";

            return turn.Response;
        }
    }
}