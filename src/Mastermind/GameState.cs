using System;
using System.Text;

namespace Mastermind
{
    public class GameState
    {
        private static Random _randomizer = new Random();

        public GameState()
        {
            var builder = new StringBuilder(4);
            for (var index = 0; index < 4; index++)
                builder.Append(_randomizer.Next(1, 6));
            Code = builder.ToString();
        }
        public string Code { get; }
    }
}