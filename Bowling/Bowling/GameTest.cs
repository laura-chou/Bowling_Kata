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
        
        [Test]
        [TestCase("X 11 11 11 11 11 11 11 11 11", 30)]
        [TestCase("11 11 11 X 11 11 11 11 11 11", 30)]
        [TestCase("11 11 11 11 11 11 11 11 11 X26", 36)]
        public void A04_OnlyOneStrike(string frame, int expected)
        {
            AssertResultShouldReturn(frame, expected);
        }

        [Test]
        [TestCase("8/ 11 11 11 11 11 11 11 11 11", 29)]
        [TestCase("11 11 3/ 11 11 11 11 11 11 11", 29)]
        [TestCase("11 11 11 11 11 11 11 11 11 2/9", 37)]
        public void A05_OnlyOneSpare(string frame, int expected)
        {
            AssertResultShouldReturn(frame, expected);
        }
        
        [Test]
        [TestCase("52 8/ X 9- X X -/ 81 6/ 6/X", 158)]
        public void A06_RandomGames(string frame, int expected)
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
