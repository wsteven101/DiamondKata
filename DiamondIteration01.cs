using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondKata
{
    internal class DiamondIteration01
    {
        // Iteration one. Validate the input
        public string Diamond(char outerChar)
        {

            var outerCharValue = 0;
            if (Char.IsAsciiLetterLower(outerChar))
            {
                outerCharValue = (int)outerChar;
            }
            else if (Char.IsAsciiLetterUpper(outerChar))
            {
                outerCharValue = (int)outerChar;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Argument is not a valid ASCII letter"); ;
            }

            var outputChars = (char)outerCharValue;

            return outputChars.ToString();

        }


        [Test]
        public void test_invalid_input()
        {

            var diamond = new DiamondIteration01();

            Assert.Throws<ArgumentOutOfRangeException>(() => diamond.Diamond('0'));
            Assert.Throws<ArgumentOutOfRangeException>(() => diamond.Diamond('9'));
            Assert.Throws<ArgumentOutOfRangeException>(() => diamond.Diamond('$'));
            Assert.Throws<ArgumentOutOfRangeException>(() => diamond.Diamond('\0'));

        }

        [Test]
        public void test_valid_input()
        {

            var diamond = new DiamondIteration01();

            var diamondText = diamond.Diamond('a');
            Assert.That(diamondText, Is.EqualTo("a"));

            diamondText = diamond.Diamond('z');
            Assert.That(diamondText, Is.EqualTo("z"));

            diamondText = diamond.Diamond('A');
            Assert.That(diamondText, Is.EqualTo("A"));

            diamondText = diamond.Diamond('Z');
            Assert.That(diamondText, Is.EqualTo("Z"));
        
        }

    }
}
