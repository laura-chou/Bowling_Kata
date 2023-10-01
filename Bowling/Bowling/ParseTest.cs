using FluentAssertions;
using NUnit.Framework;

namespace Bowling
{
    [TestFixture]
    public class ParseTest
    {
        [Test]
        public void A01_ParserFrame()
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
    }
}
