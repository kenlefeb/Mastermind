using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class Requirements : XunitLoggingBase
    {
        /*
		 *  Randomly generated code [1-6]{4}
         *  Player enters a guess:
         *  Display "-" for each digit that is correct but in wrong position
         *  Display "+" for each digit that is correct and in correct position
         *  Display " " for each incorrect digit
         *  After 10 incorrect guesses, the player loses
         *  At end of game, display message indicating whether they won or lost
		 */

        public Requirements(ITestOutputHelper output) : base(output) { }

        [Fact]
        public void InitializeGame_GeneratesValidCode()
        {
            var state = new GameState();
            var expectation = new Regex(@"[1-6]{4}");

            expectation.IsMatch(state.Code).Should().BeTrue();
        }

        [Fact]
        public void InitializeGame_GeneratesRelativelyRandomCode()
        {
            const int total = 100;              // Use a test sample of 100 executions
            const decimal threshold = 0.10M;    // Failure threshold of 10% duplicate codes
            var codes = new List<string>();
            for (var count = 0; count < total; count++)
            {
                codes.Add(new GameState().Code);
            }

            codes.DuplicateCount().Should().BeLessThan((int)(total * threshold));
        }

        [Fact]
        public void AnalyzeGuess_DisplaysMinusForPartiallyCorrectDigit()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void AnalyzeGuess_DisplaysPlusForCorrectDigit()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void AnalyzeGuess_DisplaysSpaceForIncorrectDigit()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void GuessCounter_EndsGameAfterTenIncorrectGuesses()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void AnalyzeGuess_EndsGameIfAllDigitsAreCorrect()
        {
            throw new NotImplementedException();
        }
    }

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
