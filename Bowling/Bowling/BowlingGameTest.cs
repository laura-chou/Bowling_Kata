using FluentAssertions;
using NUnit.Framework;

namespace Bowling
{
    [TestFixture]
    public class BowlingGameTest
    {
        private BowlingGame _game;

        [SetUp]
        public void SetUp()
        {
            _game = new BowlingGame();
        }

        [Test]
        [TestCase("-- -- -- -- -- -- -- -- -- --", 0)]
        public void A01_GutterGame(string frame, int expected)
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
