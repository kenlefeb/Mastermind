using FluentAssertions;
using Mastermind;
using System;
using System.Collections.Generic;
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
            const decimal threshold = 0.25M;    // Failure threshold of 25% duplicate codes
            var codes = new List<string>();
            for (var count = 0; count < total; count++)
            {
                codes.Add(new GameState().Code);
            }

            codes.DuplicateCount().Should().BeLessThan((int)(total * threshold));
        }

        [Theory]
        [InlineData("1000", "0100", " 1  ")]
        public void AnalyzeGuess_DisplaysMinusForPartiallyCorrectDigit(string code, string guess, string expected)
        {
            var analyzer = new GuessAnalyzer(code);
            var actual = analyzer.Analyze(guess);

            actual.Should().Be(expected);
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
}
