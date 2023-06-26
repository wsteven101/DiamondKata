using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondKata
{
    // Iteration 5
    // Add spaces between two letters on the same line of
    // the diamond
    internal class DiamondIteration05
    {

        public string Diamond(char outerChar)
        {

            var newLine = '\n';
            var space = ' ';

            var baseValueOfCharA = 0;
            var offsetCharValue = 0;
            var outerCharValue = 0;

            if (Char.IsAsciiLetterLower(outerChar))
            {
                baseValueOfCharA = ((int)'a');
                outerCharValue = (int)outerChar;
                offsetCharValue = outerCharValue - baseValueOfCharA;
            }
            else if (Char.IsAsciiLetterUpper(outerChar))
            {
                baseValueOfCharA = ((int)'A');
                outerCharValue = (int)outerChar;
                offsetCharValue = outerCharValue - baseValueOfCharA;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Argument is not a valid ASCII letter"); ;
            }

            var outputChars = new StringBuilder();

            // output the upper side of the diamond
            for (var charCount = 0; charCount <= offsetCharValue - 1; charCount++)
            {
                var edgeChar = (Char)(baseValueOfCharA + charCount);

                // indent left side of diamond
                for (var spacePos = 0; spacePos < (offsetCharValue - charCount); spacePos++)
                {
                    outputChars.Append(space);
                }

                outputChars.Append(edgeChar);

                    // output spaces inbetween the letters
                for (var spacePos = 0; spacePos < ((charCount * 2) - 1); spacePos++)
                {
                    outputChars.Append(space);
                }

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
                var edgeChar = (Char)(baseValueOfCharA + charCount);

                // indent left side of diamond
                for (var spacePos = 0; spacePos < (offsetCharValue - charCount); spacePos++)
                {
                    outputChars.Append(space);
                }

                outputChars.Append(edgeChar);

                for (var spacePos = 0; spacePos < ((charCount*2)-1); spacePos++)
                {
                    outputChars.Append(space);
                }

                // output the 'A' char only once in loop
                if (charCount != 0)
                {
                    outputChars.Append(edgeChar);
                    outputChars.Append(newLine);
                }

            }

            return outputChars.ToString();

        }

        [Test]
        public void Test_Indentation_Of_Diamond_Edges()
        {

            var diamond = new DiamondIteration05();

            var result = diamond.Diamond('A');
            Assert.That(result, Is.EqualTo("A"));

            result = diamond.Diamond('B');
            Assert.That(result, Is.EqualTo(" A\nB B\n A"));

            result = diamond.Diamond('C');
            Assert.That(result, Is.EqualTo("  A\n B B\nC   C\n B B\n  A"));

            result = diamond.Diamond('D');
            Assert.That(result, Is.EqualTo("   A\n  B B\n C   C\nD     D\n C   C\n  B B\n   A"));

        }
    }

}
