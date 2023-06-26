using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondKata
{
    internal class DiamondIteration03
    {
        // Iteration Three
        // Add New Line characters so that each distinct
        // letter appears on a separate line
        public string Diamond(char outerChar)
        {

            var newLine = '\n';
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
            for (var charCount = 0; charCount <= offsetCharValue-1; charCount++)
            {
                var edgeChar = (Char)(baseValueOfCharA + charCount);

                outputChars.Append(edgeChar);

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

                outputChars.Append(edgeChar);

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
        public void Test_New_Lines_Between_Each_Squence_Of_Letters()
        {
        
            var diamond = new DiamondIteration03();

            var result = diamond.Diamond('A');
            Assert.That(result, Is.EqualTo("A"));

            result = diamond.Diamond('B');
            Assert.That(result, Is.EqualTo("A\nBB\nA"));

            result = diamond.Diamond('C');
            Assert.That(result, Is.EqualTo("A\nBB\nCC\nBB\nA"));

            result = diamond.Diamond('D');
            Assert.That(result, Is.EqualTo("A\nBB\nCC\nDD\nCC\nBB\nA"));

        }
    }
}
