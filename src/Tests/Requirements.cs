using FluentAssertions;
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
        public void InitializeGame_GeneratesRandomCode()
        {
            var codes = new List<string>();
            for (var count = 0; count < 100; count++)
            {
                codes.Add(new GameState().Code);
            }

            codes.HasDuplicates().Should().BeFalse();
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
        public GameState()
        {
            Code = "1234";
        }
        public string Code { get; }
    }
}
