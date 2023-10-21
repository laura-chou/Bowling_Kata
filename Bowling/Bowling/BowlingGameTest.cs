using FluentAssertions;
using NUnit.Framework;

namespace Bowling
{
    [TestFixture]
    public class BowlingGameTest
    {
        [Test]
        public void A01_GutterGame()
        {
            var game = new BowlingGame();
            var actual = game.GameScore("-- -- -- -- -- -- -- -- -- --");
            actual.Should().Be(0);
        }
    }
}
