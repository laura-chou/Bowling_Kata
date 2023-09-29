using FluentAssertions;
using NUnit.Framework;

namespace Bowling
{
    [TestFixture]
    public class GameTest
    {
        [Test]
        public void A01_GutterGame() 
        {
            var game = new Game();
            var actual = game.ShowResult("-- -- -- -- -- -- -- -- -- --");
            actual.Should().Be(0);
        }
    }
}
