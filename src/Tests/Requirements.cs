using FluentAssertions;
using Mastermind;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    [Trait("Category", "Unit")]
    public class Requirements : XunitLoggingBase
    {
        //
        //  Player enters a guess:
        //  After 10 incorrect guesses, the player loses
        //  At end of game, display message indicating whether they won or lost
        //

        public Requirements(ITestOutputHelper output) : base(output) { }

        //  Randomly generated code [1-6]{4}
        [Fact]
        public void InitializeGame_GeneratesValidCode()
        {
            var state = new Game();
            var expectation = new Regex(@"[1-6]{4}");

            expectation.IsMatch(state.Code).Should().BeTrue();
        }

        //  Randomly generated code [1-6]{4}
        [Fact]
        public void InitializeGame_GeneratesRelativelyRandomCode()
        {
            const int total = 100;              // Use a test sample of 100 executions
            const decimal threshold = 0.25M;    // Failure threshold of 25% duplicate codes
            var codes = new List<string>();
            for (var count = 0; count < total; count++)
            {
                codes.Add(new Game().Code);
            }

            codes.DuplicateCount().Should().BeLessThan((int)(total * threshold));
        }

        //  Display "-" for each digit that is correct but in wrong position
        //  Display "+" for each digit that is correct and in correct position
        //  Display " " for each incorrect digit
        [Theory]
        [InlineData("1234", "1000", "+   ")]
        [InlineData("1234", "0100", " -  ")]
        [InlineData("1234", "0010", "  - ")]
        [InlineData("1234", "0001", "   -")]
        [InlineData("1234", "1200", "++  ")]
        [InlineData("1234", "2100", "--  ")]
        [InlineData("1234", "0120", " -- ")]
        [InlineData("1234", "0012", "  --")]
        [InlineData("1234", "1230", "+++ ")]
        [InlineData("1234", "3210", "-+- ")]
        [InlineData("1234", "0123", " ---")]
        [InlineData("1234", "3012", "- --")]
        [InlineData("1234", "1234", "++++")]
        public void AnalyzeGuess_ComposesResponseToGuess(string code, string guess, string expected)
        {
            var analyzer = new GuessAnalyzer(code);
            var actual = analyzer.Analyze(guess);

            actual.Should().Be(expected);
        }

        [Fact]
        public void GuessCounter_EndsGameAfterTenIncorrectGuesses()
        {
            var state = new Game("0000");
            for (var count = 0; count < 9; count++)
            {
                WriteLine(state.Guess("1111"));
            }

            var actual = state.Guess("1111");

            actual.Should().Be("Sorry, you lose.");
        }

        [Fact]
        public void AnalyzeGuess_EndsGameIfAllDigitsAreCorrect()
        {
            throw new NotImplementedException();
        }
    }
}
