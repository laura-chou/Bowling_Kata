using FluentAssertions;
using NUnit.Framework;

namespace Bowling
{
    [TestFixture]
    public class GameTest
    {
        private Game _game;

        [SetUp]
        public void SetUp() 
        {
            _game = new Game();
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
        public void A02_AllRollNotKnockedDownAllPins(string frame, int expected)
        {
            AssertResultShouldReturn(frame, expected);
        }

        public void AssertResultShouldReturn(string frame, int expected)
        {
            var actual = _game.ShowResult(frame);
            actual.Should().Be(expected);
        }
    }
}
