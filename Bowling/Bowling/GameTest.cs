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
        public void A01_GutterGame(string input, int expected)
        {
            AssertResultShouldReturn(input, expected);
        }
        
        [Test]
        [TestCase("11 11 11 11 11 11 11 11 11 11", 20)]
        [TestCase("9- 9- 9- 9- 9- 9- 9- 9- 9- 9-", 90)]
        [TestCase("43 81 72 22 41 35 23 72 14 62", 69)]
        public void A02_AllRollNotKnockedDownAllPins(string input, int expected)
        {
            AssertResultShouldReturn(input, expected);
        }
        
        [TestCase("X X X X X X X X X XXX", 300)]
        public void A03_PerfectGame(string input, int expected)
        {
            AssertResultShouldReturn(input, expected);
        }

        [TestCase("X 11 11 11 11 11 11 11 11 11", 30)]
        [TestCase("11 11 11 X 11 11 11 11 11 11", 30)]
        [TestCase("11 11 11 11 11 11 11 11 11 X26", 36)]
        public void A04_OneStrike(string input, int expected)
        {
            AssertResultShouldReturn(input, expected);
        }
        
        [TestCase("8/ 11 11 11 11 11 11 11 11 11", 29)]
        [TestCase("11 11 3/ 11 11 11 11 11 11 11", 29)]
        [TestCase("11 11 11 11 11 11 11 11 11 2/9", 37)]
        public void A05_OneSpare(string input, int expected)
        {
            AssertResultShouldReturn(input, expected);
        }
        
        [TestCase("52 8/ X 9- X X -/ 81 6/ 6/X", 158)]
        [TestCase("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5", 150)]
        public void A06_RandomGames(string input, int expected)
        {
            AssertResultShouldReturn(input, expected);
        }

        private void AssertResultShouldReturn(string input, int expected)
        {
            var actual = _game.ShowResult(input);
            actual.Should().Be(expected);
        }
    }
}
