using Bowling.src;
using FluentAssertions;
using NUnit.Framework;

namespace Bowling
{
    [TestFixture]
    public class BowlingGameTest
    {
        private BowlingGame _game;

        [SetUp]
        public void A00_SetUp()
        {
            _game = new BowlingGame();
        }

        [Test]
        [TestCase("-- -- -- -- -- -- -- -- -- --", 0)]
        public void A01_GutterGame(string frame, int expected)
        {
            AssertResultShouldReturn(frame, expected);
        }
        
        [Test]
        [TestCase("11 11 11 11 11 11 11 11 11 11", 20)]
        [TestCase("9- 9- 9- 9- 9- 9- 9- 9- 9- 9-", 90)]
        [TestCase("43 81 72 22 41 35 23 72 14 62", 69)]
        public void A02_AllRollNotKnockedDownAllPins(string frame, int expected)
        {
            AssertResultShouldReturn(frame, expected);
        }
        
        [Test]
        [TestCase("X X X X X X X X X XXX", 300)]
        public void A03_PerfectGame(string frame, int expected)
        {
            AssertResultShouldReturn(frame, expected);
        }

        private void AssertResultShouldReturn(string frame, int expected)
        {
            var actual = _game.GameScore(frame);
            actual.Should().Be(expected);
        }
    }
}
