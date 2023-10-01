using FluentAssertions;
using NUnit.Framework;

namespace Bowling
{
    [TestFixture]
    public class ParseTest
    {
        [Test]
        public void A01_ParserFrameWithHyphenSymbol()
        {
            var parse = new Parse();
            var actual = parse.Parser("-- -- -- -- -- -- -- -- -- --");
            var expected = new List<Rolls>
            {
                new Rolls{ FirstRoll = new Roll { Pins = 0 }, SecondRoll = new Roll { Pins = 0 } },
                new Rolls{ FirstRoll = new Roll { Pins = 0 }, SecondRoll = new Roll { Pins = 0 } },
                new Rolls{ FirstRoll = new Roll { Pins = 0 }, SecondRoll = new Roll { Pins = 0 } },
                new Rolls{ FirstRoll = new Roll { Pins = 0 }, SecondRoll = new Roll { Pins = 0 } },
                new Rolls{ FirstRoll = new Roll { Pins = 0 }, SecondRoll = new Roll { Pins = 0 } },
                new Rolls{ FirstRoll = new Roll { Pins = 0 }, SecondRoll = new Roll { Pins = 0 } },
                new Rolls{ FirstRoll = new Roll { Pins = 0 }, SecondRoll = new Roll { Pins = 0 } },
                new Rolls{ FirstRoll = new Roll { Pins = 0 }, SecondRoll = new Roll { Pins = 0 } },
                new Rolls{ FirstRoll = new Roll { Pins = 0 }, SecondRoll = new Roll { Pins = 0 } },
                new Rolls{ FirstRoll = new Roll { Pins = 0 }, SecondRoll = new Roll { Pins = 0 } }
            };
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void A02_ParserFrameWithXSymbol()
        {
            var parse = new Parse();
            var actual = parse.Parser("X X X X X X X X X XXX");
            var expected = new List<Rolls>
            {
                new Rolls{ FirstRoll = new Roll { Pins = 10 }, SecondRoll = null, ThirdRoll = null },
                new Rolls{ FirstRoll = new Roll { Pins = 10 }, SecondRoll = null, ThirdRoll = null },
                new Rolls{ FirstRoll = new Roll { Pins = 10 }, SecondRoll = null, ThirdRoll = null },
                new Rolls{ FirstRoll = new Roll { Pins = 10 }, SecondRoll = null, ThirdRoll = null },
                new Rolls{ FirstRoll = new Roll { Pins = 10 }, SecondRoll = null, ThirdRoll = null },
                new Rolls{ FirstRoll = new Roll { Pins = 10 }, SecondRoll = null, ThirdRoll = null },
                new Rolls{ FirstRoll = new Roll { Pins = 10 }, SecondRoll = null, ThirdRoll = null },
                new Rolls{ FirstRoll = new Roll { Pins = 10 }, SecondRoll = null, ThirdRoll = null },
                new Rolls{ FirstRoll = new Roll { Pins = 10 }, SecondRoll = null, ThirdRoll = null },
                new Rolls{ FirstRoll = new Roll { Pins = 10 }, SecondRoll = new Roll { Pins = 10 }, ThirdRoll = new Roll { Pins = 10 } }
            };
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
