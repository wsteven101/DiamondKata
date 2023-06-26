using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondKata
{
    internal class DiamondIteration02
    {
        // Iteration two. Produce single line containing all of
        // diamond's characters on a single line and in order
        // of how they will appear on the edges of the diamond
        // e.g. "CBABC"
        public string Diamond(char outerChar)
        {

            var baseValueOfCharA = 0;
            var offsetCharValue = 0;
            var outerCharValue = 0;

            if (Char.IsAsciiLetterLower(outerChar))
            {
                baseValueOfCharA = ((int)'a');
                outerCharValue = (int)outerChar;
                offsetCharValue =  outerCharValue - baseValueOfCharA;
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
            for (var charCount = 0; charCount <= offsetCharValue; charCount++)
            {
                var edgeChar = (Char)(baseValueOfCharA + charCount);
                
                outputChars.Append(edgeChar);

                 // output the 'A' char only once in loop
                if (charCount != 0)
                {
                    outputChars.Append(edgeChar);
                }
            }

             // output the lower side of the diamond
            for (var charCount = offsetCharValue - 1; charCount >= 0; charCount--)
            {
                var edgeChar = (Char)(baseValueOfCharA + charCount);

                outputChars.Append(edgeChar);

                 // output the 'A' char only once in loop
                if (charCount != 0)
                {
                    outputChars.Append(edgeChar);
                }
            }

            return outputChars.ToString();

        }

        [Test]
        public void Test_Single_Line_Of_Ordered_Outer_Edge_Chars_Uppercase()
        {
            var diamond = new DiamondIteration02();

            var result = diamond.Diamond('A');
            Assert.That(result, Is.EqualTo("A"));

            result = diamond.Diamond('B');
            Assert.That(result, Is.EqualTo("ABBA"));

            result = diamond.Diamond('C');
            Assert.That(result, Is.EqualTo("ABBCCBBA"));

            result = diamond.Diamond('D');
            Assert.That(result, Is.EqualTo("ABBCCDDCCBBA"));
        }

        [Test]
        public void Test_Single_Line_Of_Ordered_Outer_Edge_Chars_Lowercase()
        {
            var diamond = new DiamondIteration02();

            var result = diamond.Diamond('a');
            Assert.That(result, Is.EqualTo("a"));

            result = diamond.Diamond('b');
            Assert.That(result, Is.EqualTo("abba"));

            result = diamond.Diamond('c');
            Assert.That(result, Is.EqualTo("abbccbba"));

            result = diamond.Diamond('d');
            Assert.That(result, Is.EqualTo("abbccddccbba"));
        }
    }
}
