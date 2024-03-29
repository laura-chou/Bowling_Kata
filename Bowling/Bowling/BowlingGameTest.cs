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
        [TestCase("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5", 150)]
        [TestCase("6/ X 1- X X -8 9/ 35 4- X34", 120)]
        [TestCase("X 9/ X 7/ X 2/ X 5/ X 1/X", 200)]
        [TestCase("14 45 6/ 5/ X -1 7/ 6/ X 27", 125)]
        public void A06_RandomGames(string frame, int expected)
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
