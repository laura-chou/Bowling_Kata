using NUnit.Framework;
using FluentAssertions;

namespace Bowling
{
    [TestFixture]
    public class ParseTest
    {
        private Parse _parse;

        [SetUp]
        public void SetUp()
        {
            _parse = new Parse();
        }

        [Test]
        public void A01_ParserFrame()
        {
            var input = "-- -- -- -- -- -- -- -- -- --";
            var expected = new List<Rolls>
            {
                new Rolls { Roll1 = new Roll { Pins = 0 }, Roll2 = new Roll { Pins = 0 } },
                new Rolls { Roll1 = new Roll { Pins = 0 }, Roll2 = new Roll { Pins = 0 } },
                new Rolls { Roll1 = new Roll { Pins = 0 }, Roll2 = new Roll { Pins = 0 } },
                new Rolls { Roll1 = new Roll { Pins = 0 }, Roll2 = new Roll { Pins = 0 } },
                new Rolls { Roll1 = new Roll { Pins = 0 }, Roll2 = new Roll { Pins = 0 } },
                new Rolls { Roll1 = new Roll { Pins = 0 }, Roll2 = new Roll { Pins = 0 } },
                new Rolls { Roll1 = new Roll { Pins = 0 }, Roll2 = new Roll { Pins = 0 } },
                new Rolls { Roll1 = new Roll { Pins = 0 }, Roll2 = new Roll { Pins = 0 } },
                new Rolls { Roll1 = new Roll { Pins = 0 }, Roll2 = new Roll { Pins = 0 } },
                new Rolls { Roll1 = new Roll { Pins = 0 }, Roll2 = new Roll { Pins = 0 } },
            };
            AssetResultShouldReturn(input, expected);
        }

        private void AssetResultShouldReturn(string input, List<Rolls> expected)
        {
            var actual = _parse.Parser(input);
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
