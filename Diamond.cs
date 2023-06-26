using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace DiamondKata
{
     // The final refactored solution to the Diamond Kata
    internal class Diamond 
    {
        public string GetDiamond(char outerChar)
        {

            var newLine = '\n';

            var valueOfCharA = 0;      // ascii value of 'a' or 'A'
            var offsetCharValue = 0;   // offset from valueOfCharA of parameter char 
            var outerCharValue = 0;

            if (Char.IsAsciiLetterLower(outerChar))
            {
                valueOfCharA = ((int)'a');
                outerCharValue = (int)outerChar;
                offsetCharValue = outerCharValue - valueOfCharA;
            }
            else if (Char.IsAsciiLetterUpper(outerChar))
            {
                valueOfCharA = ((int)'A');
                outerCharValue = (int)outerChar;
                offsetCharValue = outerCharValue - valueOfCharA;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Argument is not a valid ASCII letter"); ;
            }

            var outputChars = new StringBuilder();

             // output the upper side of the diamond
            for (var charCount = 0; charCount <= offsetCharValue - 1; charCount++)
            {
                var edgeChar = (Char)(valueOfCharA + charCount);

                 // indent left side of diamond
                AddStringOfSpaces(outputChars,offsetCharValue - charCount);

                outputChars.Append(edgeChar);

                 // Add spaces between two letters on same line
                AddStringOfSpaces(outputChars,(charCount * 2) - 1);

                // output the 'A' char only once in loop
                if (charCount != 0)
                {
                    outputChars.Append(edgeChar);
                }

                outputChars.Append(newLine);
            }

             // output the lower side of the diamond
            for (var charCount = offsetCharValue; charCount >= 0; charCount--)
            {
                var edgeChar = (Char)(valueOfCharA + charCount);

                AddStringOfSpaces(outputChars, offsetCharValue - charCount);

                outputChars.Append(edgeChar);
                 
                 // Add spaces between two letters on same line
                AddStringOfSpaces(outputChars, ((charCount * 2) - 1));

                 // output the 'A' char only once in loop
                if (charCount != 0)
                {
                    outputChars.Append(edgeChar);
                    outputChars.Append(newLine);
                }

            }

            return outputChars.ToString();

        }

        private void AddStringOfSpaces(StringBuilder outputChars, int noOfSpaces)
        {
            if (noOfSpaces <= 0)
            {
                return;
            }

            var space = ' ';

            for (var spacePos = 0; spacePos < noOfSpaces; spacePos++)
            {
                outputChars.Append(space);
            }

        }

        [Test]
        public void test_invalid_input()
        {

            var diamond = new Diamond();

            Assert.Throws<ArgumentOutOfRangeException>(() => diamond.GetDiamond('0'));
            Assert.Throws<ArgumentOutOfRangeException>(() => diamond.GetDiamond('9'));
            Assert.Throws<ArgumentOutOfRangeException>(() => diamond.GetDiamond('$'));
            Assert.Throws<ArgumentOutOfRangeException>(() => diamond.GetDiamond('\0'));

        }

        [Test]
        public void Test_Diamond_Shapes()
        {

            var diamond = new Diamond();

            var result = diamond.GetDiamond('A');
            Assert.That(result, Is.EqualTo("A"));

            result = diamond.GetDiamond('B');
            Assert.That(result, Is.EqualTo(" A\nB B\n A"));

            result = diamond.GetDiamond('C');
            Assert.That(result, Is.EqualTo("  A\n B B\nC   C\n B B\n  A"));

            result = diamond.GetDiamond('D');
            Assert.That(result, Is.EqualTo("   A\n  B B\n C   C\nD     D\n C   C\n  B B\n   A"));

        }
    }
}

