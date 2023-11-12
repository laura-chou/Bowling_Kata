using NUnit.Framework;
using FluentAssertions;
using Bowling.src;

namespace Bowling
{
    [TestFixture]
    public class ParseTest
    {
        private Parse _parse;

        [SetUp]
        public void A00_SetUp()
        {
            _parse = new Parse();
        }

        [Test]
        public void A01_ParserFrameWithHyphenSymbol()
        {
            var input = "-- -- -- -- -- -- -- -- -- --";
            var expected = new List<Rolls>(DuplicateRolls(0, 0, Category.GutterBall));

            AssetResultShouldReturn(input, expected);
        }

        [Test]
        public void A02_ParserFrameWithNumber()
        {
            var input = "11 11 11 11 11 11 11 11 11 11";
            var expected = new List<Rolls>(DuplicateRolls(1, 1, Category.Normal));
            AssetResultShouldReturn(input, expected);
        }
        
        [Test]
        public void A03_ParserFrameWithXSymbol()
        {
            var input = "X X X X X X X X X XXX";
            var expected = new List<Rolls>
            {
              new Rolls { Roll1 = new Roll { Pins = 10, Category = Category.Strike }, Roll2 = null },
              new Rolls { Roll1 = new Roll { Pins = 10, Category = Category.Strike }, Roll2 = null },
              new Rolls { Roll1 = new Roll { Pins = 10, Category = Category.Strike }, Roll2 = null },
              new Rolls { Roll1 = new Roll { Pins = 10, Category = Category.Strike }, Roll2 = null },
              new Rolls { Roll1 = new Roll { Pins = 10, Category = Category.Strike }, Roll2 = null },
              new Rolls { Roll1 = new Roll { Pins = 10, Category = Category.Strike }, Roll2 = null },
              new Rolls { Roll1 = new Roll { Pins = 10, Category = Category.Strike }, Roll2 = null },
              new Rolls { Roll1 = new Roll { Pins = 10, Category = Category.Strike }, Roll2 = null },
              new Rolls { Roll1 = new Roll { Pins = 10, Category = Category.Strike }, Roll2 = null },
              new Rolls { Roll1 = new Roll { Pins = 10, Category = Category.Strike }, Roll2 = new Roll { Pins = 10, Category = Category.Strike }, Roll3 = new Roll { Pins = 10, Category = Category.Strike } }
            };
            AssetResultShouldReturn(input, expected);
        }

        [Test]
        public void A04_ParserFrameWithSlashSymbol()
        {
            var input = "8/ 11 11 11 11 11 11 11 11 11";
            var expected = new List<Rolls>
            {
              new Rolls { Roll1 = new Roll { Pins = 8, Category = Category.Normal }, Roll2 = new Roll { Pins = 2, Category = Category.Spare } },
              new Rolls { Roll1 = new Roll { Pins = 1, Category = Category.Normal }, Roll2 = new Roll { Pins = 1, Category = Category.Normal } },
              new Rolls { Roll1 = new Roll { Pins = 1, Category = Category.Normal }, Roll2 = new Roll { Pins = 1, Category = Category.Normal } },
              new Rolls { Roll1 = new Roll { Pins = 1, Category = Category.Normal }, Roll2 = new Roll { Pins = 1, Category = Category.Normal } },
              new Rolls { Roll1 = new Roll { Pins = 1, Category = Category.Normal }, Roll2 = new Roll { Pins = 1, Category = Category.Normal } },
              new Rolls { Roll1 = new Roll { Pins = 1, Category = Category.Normal }, Roll2 = new Roll { Pins = 1, Category = Category.Normal } },
              new Rolls { Roll1 = new Roll { Pins = 1, Category = Category.Normal }, Roll2 = new Roll { Pins = 1, Category = Category.Normal } },
              new Rolls { Roll1 = new Roll { Pins = 1, Category = Category.Normal }, Roll2 = new Roll { Pins = 1, Category = Category.Normal } },
              new Rolls { Roll1 = new Roll { Pins = 1, Category = Category.Normal }, Roll2 = new Roll { Pins = 1, Category = Category.Normal } },
              new Rolls { Roll1 = new Roll { Pins = 1, Category = Category.Normal }, Roll2 = new Roll { Pins = 1, Category = Category.Normal } }
            };
            AssetResultShouldReturn(input, expected);
        }

        private void AssetResultShouldReturn(string input, List<Rolls> expected)
        {
            var actual = _parse.Parser(input);
            actual.Should().BeEquivalentTo(expected);
        }

        private List<Rolls> DuplicateRolls(int roll1Pins, int roll2Pins, Category catrgory)
        {
            var rollList = new List<Rolls>();
            for (int i = 0; i < 10; i++)
            {
                rollList.Add(new Rolls { Roll1 = new Roll { Pins = roll1Pins, Category = catrgory }, Roll2 = new Roll { Pins = roll2Pins, Category = catrgory } });
            }
            return rollList;
        }
    }
}
