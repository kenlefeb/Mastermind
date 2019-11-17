# Programming Exercise

## Original Request

Create a C# console application that is a simple version of Mastermind.  The randomly generated answer should be four (4) digits in length, with each digit between the numbers 1 and 6.  After the player enters a combination, a minus (-) sign should be printed for every digit that is correct but in the wrong position, and a plus (+) sign should be printed for every digit that is both correct and in the correct position.  Nothing should be printed for incorrect digits.  The player has ten (10) attempts to guess the number correctly before receiving a message that they have lost.

Publish the source code to Github and provide your Github profile. 

## Identified Requirements

- C# Console application
- Randomly generated code [1-6]{4}
- Player enters a guess:
  - Display "-" for each digit that is correct but in wrong position
  - Display "+" for each digit that is correct and in correct position
  - Display " " for each incorrect digit
- After 10 incorrect guesses, the player loses
- At end of game, display message indicating whether they won or lost
