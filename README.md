# Test Driven Development (TDD) and the Diamond Kata

## Description

This Project provides an example of Test Driven development through recycling the tests. It does so through a program developed to produce a diamond shape whose edges are formed of letters.

A user runs the program passing a single letter as a parameter and the program outputs a diamond shape with the input letter representing the widest part of the diamond e.g. a 'B' input produces...

          A
         B B
          A

Instead of red, green, refactor as is the normal TDD flow the problem is broken down into smaller problems to solve. A function is written to solve one of these smaller problems and tested. Subsequently it is refactored to include the next part/problem solution along with the tests. This pattern is then repeated until we have a fully working function passing all the tests.

For example in this project the problem was broken down to...

  1) Checking for a valid letter as input
  2) Produce a single line containing all of the diamond's letters
  3) Add new lines at the end of the letter sequences
  4) Add indentation of spaces to the left side of the diamond
  5) Add spaces between the same letter sequence e.g. 'BB' -> 'B B' 

## Program Structure

To show how the problem was broken down, solved and tested in smaller parts each one of the breakdowns listed above from 1 to 5 has its own C# file.
Normally one would recycle the same file/class/function but to be able to demonstrate the changes within each recycling. Each recycling (iteration) once finished is copied into a separate  C# file and extended to solve the next small problem e.g.

  DiamondIteration01.cs
  DiamondIteration02.cs
  DiamondIteration03.cs
  DiamondIteration04.cs
  DiamondIteration05.cs

The final version is stored in the C# file 'Diamond.cs' and is a copy of 'DiamondIteration05.cs' that has been refactored.

For transparency and simplicity all NUnit code tests are contained within the iteration files i.e. with the code solution files. 
## Running the Program

Click the Run (right arrow head) button in Visual Studio or use the command line to run DiamondKata.exe with a single letter as a parameter e.g.

  DiamondKata.exe 'D'

