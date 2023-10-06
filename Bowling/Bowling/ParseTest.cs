using FluentAssertions;
using NUnit.Framework;

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
        public void A01_ParserFrameWithHyphenSymbol()
        {
            var actual = _parse.Parser("-- -- -- -- -- -- -- -- -- --");
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
            var actual = _parse.Parser("X X X X X X X X X XXX");
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
